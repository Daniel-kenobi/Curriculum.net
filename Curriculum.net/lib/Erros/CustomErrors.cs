using System;
using System.Collections.Generic;
using Models;

namespace lib.Retornos
{
    public class ErroGenerico
    {
        public string ErrorMessage { get; set; }
        public ErroGenerico(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }

    public class ListError
    {
        public IEnumerable<string> Erros { get; private set; }

        public ListError(IEnumerable<string> Erros)
        {
            this.Erros = Erros;
        }
    }

    public class Token
    {
        public string token{ get; set; }
        public string Description { get; set; }
        public Token(string Description)
        {
            this.Description = Description;
        }
    }

    public class Sucess
    {
        public CurriculumModel Model { get; set; }
    }
}
