using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class CurriculumModel
    {

        #region Dados_Básicos
        // OBRIGATÓRIOS
        [Required(ErrorMessage = "ID iválida")]
        public Int64 ID { get; set; } // interno

        [Required(ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone Inválido")]
        public string telefone { get; set; }

        // COMUNS
        public dto_cep cep { get; set; }
        public string FraseMotivacional { get; set; }
        #endregion

        // LISTA DE INFORMAÇÕES ACADEMICAS E DE HISTÓRICO PROFISSIONAIS
        public List<InfosAcademicas> lst_infos_academicas { get; set; }
        public List<HistoricoProfissional> lst_Historico_Profissional { get; set; }
    }

    [Serializable]
    public class InfosAcademicas
    {
        public string Nome_instituicao { get; set; }
        public string TipoCurso { get; set; }
        public string Curso { get; set; }
        public string Descricao_aprendizado { get; set; }
        public string funcao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
    }

    [Serializable]
    public class HistoricoProfissional
    {
        public string Nome_instituicao { get; set; }
        public string Cargo { get; set; }
        public string Descricao_cargo { get; set; }
        public string funcao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
    }

    [Serializable]
    public class dto_cep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
    }
}
