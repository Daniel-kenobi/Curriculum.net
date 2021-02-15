using SelectPdf;
using Models;
using System.Text;

namespace lib.str
{
    public static class str_lib
    {
        public static string criaHTML(CurriculumModel infos)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");

            sb.Append("<meta charset=\"UTF-8\"/>");
            sb.Append("<style> body { text-align: center; font-family: Arial, Helvetica, sans-serif;} </style>");

            sb.Append("</head>");
            sb.Append("<body>");

            sb.Append($"<h1 style=\"color:black\"> {infos.Nome} </h1>");


            sb.Append("<p style=\"font-size: 16px;\"><b> EMAIL • TELEFONE • CIDADE - ESTADO </b></p>");
            sb.Append("<p style = \"color: darkgray; font-size: 14px; \"> Me encantaria encontrar uma vaga para essa empresa que é uma instituição que admiro tanto. Além disso, acredito que minha desenvoltura");
            sb.Append("natural com pessoas, ótima comunicação, e jeito cuidadoso se provarão muito úteis.Gostaria de poder falar sobre como possocontribuir para");
            sb.Append("essa empresa, e contando com experiência para o meu aperfeiçoamento pessoal, já agradeço pela futura resposta positiva! </p>");

            if (infos.lst_infos_academicas.Count > 0)
            {
                sb.Append("<h2 style=\"color: steelblue;\"> Formação Acadêmica </h2>");

                foreach (var i in infos.lst_infos_academicas)
                {
                    sb.Append($"<h3 style=\"color: black;\"> {i.Nome_instituicao} </h3>");
                    sb.Append($"<p style=\"color: darkgray;\"> {i.Descricao_aprendizado}</p>");
                }
            }

            if (infos.lst_Historico_Profissional.Count > 0)
            {
                sb.Append("<h2 style=\"color: steelblue;\"> Histórico Profissional </h2>");


                foreach (var i in infos.lst_Historico_Profissional)
                {
                    sb.Append($"<h3 style=\"color: black;\"> {i.Nome_instituicao}</h3>");
                    sb.Append($"<p style=\"color: darkgray;\"> {i.Descricao_cargo}</p>");

                }

                sb.Append("</body>");
                sb.Append("</html>");
            }
            return sb.ToString();
        }

        public static string criaPDF(string HTML)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument document = converter.ConvertHtmlString(HTML);
            document.Save("teste.pdf");
            document.Close();
            return HTML;
        }

    }
}

