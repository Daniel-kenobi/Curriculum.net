﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Objeto principal onde se encontra todas as informações e encapsula todos os objetos 
    /// do curriculo
    /// </summary>
    [Serializable]
    public class CurriculumModel
    {

        #region Dados_Básicos

        /// <summary>Chave primária identificadora do currículo - OFF</summary>
        [Required(ErrorMessage = "ID iválida")]
        public Int64 ID { get; set; } // interno

        /// <summary>Nome do dono do currículo</summary>
        [Required(ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }

        /// <summary>Email do dono do currículo </summary>
        [Required(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        /// <summary>Telefone do dono do currículo</summary>
        [Required(ErrorMessage = "Telefone Inválido")]
        public string telefone { get; set; }

        /// <summary>Cep do dono do currículo</summary>
        public dto_cep cep { get; set; }

        /// <summary>Frase motivacional do currículo</summary>
        public string FraseMotivacional { get; set; }
        #endregion

        // Redes sociais
        #region REDES SOCIAIS

        /// <summary>Linkedin do dono do currículo</summary>
        public string Linkedin { get; set; }

        /// <summary>Github do dono do currículo </summary>
        public string Github { get; set; }

        /// <summary>Instagram do dono do currículo </summary>
        public string Instagram { get; set; }
        #endregion

        #region Listas
        // LISTA DE INFORMAÇÕES ACADEMICAS E DE HISTÓRICO PROFISSIONAIS

        /// <summary>Lista informações academicas - estudos, faculdades...</summary>
        public List<InfosAcademicas> lst_infos_academicas { get; set; }

        /// <summary>Lista de hitórico profissional - Locais de trabalho, freelances...</summary>
        public List<HistoricoProfissional> lst_Historico_Profissional { get; set; }

        /// <summary>Lista de habilidades que você possui e aprendeu </summary>
        public List<SoftSkills> lst_soft_skills { get; set; }
        #endregion
    }

    /// <summary>objeto das informações academicas</summary>
    [Serializable]
    public class InfosAcademicas
    {
        /// <summary>Nome da intituição academica</summary>
        public string Nome_instituicao { get; set; }

        /// <summary>Tipo do curso (Ensino médio, ensino superior, curso técnico</summary>
        public string TipoCurso { get; set; }

        /// <summary>Nome do curso (Ciencias da computação, ADS, Segurança da informação</summary>
        public string Curso { get; set; }

        /// <summary>O que você aprendeu no curso e quais habilidades desenvolveu</summary>
        public string Descricao_aprendizado { get; set; }

        /// <summary>Data de início do curso</summary>
        public DateTime DataInicio { get; set; }

        /// <summary>Data da conclusão do curso</summary>
        public DateTime DataConclusao { get; set; }
    }

    /// <summary>Objeo do histórico profissional</summary>
    [Serializable]
    public class HistoricoProfissional
    {
        /// <summary>Nome da instituição</summary>
        public string Nome_instituicao { get; set; }

        /// <summary>Cargo desempenhado na empresa </summary>
        public string Cargo { get; set; }

        /// <summary>Descrição do cargo. O que você fazia neste cargo e o que aprendeu</summary>
        public string Descricao_cargo { get; set; }


        /// <summary>Data de início neste cargo</summary>
        public DateTime DataInicio { get; set; }

        /// <summary>Data de saida deste cargo </summary>
        public DateTime DataSaida { get; set; }
    }

    /// <summary>Objeto de retorno da viacep</summary>
    [Serializable]
    public class dto_cep
    {
        /// <summary>CEP da residencia</summary>
        public string cep { get; set; }

        /// <summary>Rua do dono do currículo</summary>
        public string logradouro { get; set; }

        /// <summary>Complemento</summary>
        public string complemento { get; set; }

        /// <summary>Bairro do dono do currículo</summary>
        public string bairro { get; set; }

        /// <summary>Cidade do dono do currículo </summary>
        public string localidade { get; set; }

        /// <summary>UF do dono do currículo</summary>
        public string uf { get; set; }
    }

    /// <summary>Objeto das habilidades</summary>
    [Serializable]
    public class SoftSkills
    {
        /// <summary>Nome da sua habilidade</summary>
        public string Nome { get; set; }

        /// <summary>Descrição da sua habilidade</summary>
        public string descricao { get; set; }
    }
}
