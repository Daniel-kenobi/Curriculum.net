﻿using SelectPdf;
using Models;
using System.Text;
using lib;
using System;

namespace lib.str
{
    public static class str_lib
    {

        public static dto_cep RetornaCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return new dto_cep();

            dto_cep dto = wsexec.execGetWs<dto_cep>($"http://viacep.com.br/ws/", TimeSpan.FromSeconds(30),
                $"{cep}/json") ?? new dto_cep();

            return dto;
        }

        public static string criaHTML(CurriculumModel infos)
        {
            StringBuilder sb = new StringBuilder();

            infos.cep = RetornaCep(infos.cep.cep);

            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");

            sb.Append("<meta charset=\"UTF-8\"/>");
            sb.Append("<style> body { font-family: Arial, Helvetica, sans-serif; margin: 30px 80px 70px 80px} </style>");

            sb.Append("</head>");
            sb.Append("<body>");

            sb.Append($"<h1 style=\"color:black; text-align: center\"> {infos.Nome} </h1>");

            sb.Append($"<p style=\"font-size: 16px; text-align: center\"><b> {infos.Email} • {infos.telefone}");

            if (!string.IsNullOrEmpty(infos.cep.cep))
                sb.Append($"• {infos.cep.localidade} - {infos.cep.uf} </b></p>");

            sb.Append("<p style = \"color: darkgray; font-size: 14px; text-align: center\"> Me encantaria encontrar uma vaga para essa empresa que é uma instituição que admiro tanto. Além disso, acredito que minha desenvoltura ");
            sb.Append("natural com pessoas, ótima comunicação, e jeito cuidadoso se provarão muito úteis. Gostaria de poder falar sobre como posso contribuir para");
            sb.Append(" essa empresa, e contando com experiência para o meu aperfeiçoamento pessoal, já agradeço pela futura resposta positiva!</p>");

            if (infos.lst_infos_academicas.Count > 0)
            {
                sb.Append("<h2 style=\"color: steelblue;\"> Formação Acadêmica </h2>");

                foreach (var i in infos.lst_infos_academicas)
                {
                    sb.Append($"<h3 style=\"color: black;\"> {i.Nome_instituicao} • {i.Curso}</h3>");
                    sb.Append($"<p style=\"color: darkgray;\">{i.TipoCurso} • Concluído em {i.DataConclusao.ToString("dd/MM/yyyy")}</p>");
                    sb.Append($"<p style=\"color: darkgray;\"> {i.Descricao_aprendizado}</p>");
                }
            }

            if (infos.lst_Historico_Profissional.Count > 0)
            {
                sb.Append("<h2 style=\"color: steelblue;\"> Histórico Profissional </h2>");
                foreach (var i in infos.lst_Historico_Profissional)
                {
                    sb.Append($"<h3 style=\"color: black;\"> {i.Nome_instituicao} • {i.Cargo}</h3>");
                    sb.Append($"<p style=\"color: darkgray;\"> Entrada: {i.DataInicio.ToString("dd/MM/yyyy")} - Saída: {i.DataConclusao.ToString("dd/MM/yyyy")}</p>");
                    sb.Append($"<p style=\"color: darkgray;\"> {i.Descricao_cargo}</p>");
                }
                sb.Append("</body>");
                sb.Append("<footerp style=\"color: black; font-size: 12px; text-align: center\"><p>Agradeço o retorno positívo</p></footer>");
                sb.Append("</html>");
            }
            return sb.ToString();
        }

        public static string criaPDF(string HTML)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument document = converter.ConvertHtmlString(HTML);
            document.Save($"Curricullum.pdf");
            document.Close();
            return HTML;
        }
    }
}

