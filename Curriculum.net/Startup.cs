using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

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
            // CONFIGURANDO OS CONTROLLERS, CUSTOMIZANDO O PADR�O MICROSOFT
            services.AddControllers().ConfigureApiBehaviorOptions(x =>
            // SUPRIMO O VALIDADOR DO MODELSTATE 
            x.SuppressModelStateInvalidFilter = true
                );

            // configurando o swagger 
            // ADICIONANDO O SERVI�O DO SWAGGER
            services.AddSwaggerGen(x => // FUN��O ANONIMA(LAMBDA) X � IGUAL A SwaggerGenOptions
            {
                string XMLname = "CurricullumDocumentation.xml"; // Nome da XML a ser lida
                string XMLPath = Path.Combine(AppContext.BaseDirectory, XMLname); // combina��o entre local da api(local da xml) e nome da XML
                x.IncludeXmlComments(XMLPath); // XML � adicionada ao contexto da aplica��o
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // HABILITO O USO DA AUTENTICA��O (JWT - JSON WEB TOKEN) 
            app.UseAuthentication();
            // aciono o uso do swagger
            app.UseSwagger();
            // Aciono a parte gr�fica (UI) do swagger
            app.UseSwaggerUI(
                x =>
                {
                    // CRIO UM ENDPOINT PARA O INDEX DO SWAGGER
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Curricullum.net API v1");
                    x.RoutePrefix = string.Empty; // ADICIONANDO STRING.EMPTY NO PREFIXO DE ROTA DO SWAGGER
                    // EU FA�O COM QUE, ASSIM QUE A API FOR CHAMADA O INDEX DO SWAGGER SEJA ABERTO
                });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
