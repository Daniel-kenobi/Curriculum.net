using lib.Interfaces;
using Models;
using System;
using lib.str;

namespace lib.bll
{
    public class bll_Curricullum : IBllInterface<CurriculumModel>
    {
        /* // TESTE
          public string bll_vld(CurriculumModel adt)
        {
            List<string> erros = new List<string>();

            if (adt == null)
                erros.Add("Erro interno");

            if (string.IsNullOrEmpty(adt.Nome))
               erros.Add("Nome vazio");

            if (string.IsNullOrEmpty(adt.telefone) && string.IsNullOrEmpty(adt.Email))
               erros.Add("Contatos inválidos");

            string lst_erros = string.Empty;
            if (erros.Count > 0)
            {
                foreach(var i in erros)
                {
                    lst_erros += $"Erro: {i} \n";
                }
            }
            return lst_erros;
        }
         */
        public void bll_vld(CurriculumModel adt)
        {
            if (adt == null)
                throw new Exception("Erro interno");

            if (string.IsNullOrEmpty(adt.Nome))
                throw new Exception("Nome vazio");

            if (string.IsNullOrEmpty(adt.telefone) && string.IsNullOrEmpty(adt.Email))
                throw new Exception("Contatos inválidos");
        }

        public bool bll_criaCurriculum(CurriculumModel adt)
        {
            try
            {
                bll_vld(adt);
                str_lib.criaPDF(str_lib.criaHTML(adt));
                return true;
            }
            catch
            {
                throw;
            }
        }

        public string bll_retornaHTMLCurricullum(CurriculumModel adt)
        {
            try
            {
                bll_vld(adt);
                return str_lib.criaHTML(adt);
            }
            catch
            {
                throw;
            }
        }
    }
}
