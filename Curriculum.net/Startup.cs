using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Curriculum.net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CONFIGURANDO OS CONTROLLERS, CUSTOMIZANDO O PADRÃO MICROSOFT
            services.AddControllers().ConfigureApiBehaviorOptions(x =>
            // SUPRIMO O VALIDADOR DO MODELSTATE 
            x.SuppressModelStateInvalidFilter = true
                );

            // configurando o swagger 
            // ADICIONANDO O SERVIÇO DO SWAGGER
            services.AddSwaggerGen(x => // FUNÇÃO ANONIMA(LAMBDA) X É IGUAL A SwaggerGenOptions
            {
                string XMLname = "CurricullumDocumentation.xml"; // Nome da XML a ser lida
                string XMLPath = Path.Combine(AppContext.BaseDirectory, XMLname); // combinação entre local da api(local da xml) e nome da XML
                x.IncludeXmlComments(XMLPath); // XML é adicionada ao contexto da aplicação
            });

            // Configurando o middleware e os services para utilizar o JwtBearer como DefaultAuthenticationScheme

            // COnsigo o valor em byte[] do JwtConfigurations::Secret
            var Hash = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    // HTTPS é obrigatório ? setei falso!
                    x.RequireHttpsMetadata = false;
                    // Parametro para salvar o token em cachê
                    x.SaveToken = true;
                    // crio um novo parametro para a valdiação do token e configuro o mesmo
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Hash),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseHttpsRedirection();
            // HABILITO O USO DA AUTENTICAÇÃO (JWT - JSON WEB TOKEN) 
            // o "USE AUTHENTICATION TEM QUE VIR ANTES DO AUTHORIZATION
            app.UseAuthentication();
            app.UseAuthorization();

           
            // aciono o uso do swagger
            app.UseSwagger();
            // Aciono a parte gráfica (UI) do swagger
            app.UseSwaggerUI(
                x =>
                {
                    // CRIO UM ENDPOINT PARA O INDEX DO SWAGGER
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Curricullum.net API v1");
                    x.RoutePrefix = string.Empty; // ADICIONANDO STRING.EMPTY NO PREFIXO DE ROTA DO SWAGGER
                    // EU FAÇO COM QUE, ASSIM QUE A API FOR CHAMADA O INDEX DO SWAGGER SEJA ABERTO
                    x.DocumentTitle = "Curricullum.net";
                    x.InjectStylesheet("/swagger/custom.css");
                });

            // habilito o uso de arquivos estáticos - custom.css
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
