using System;
using System.Collections.Generic;

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

    public class Sucess
    {
        public string Description { get; set; }
        public Sucess(string Description)
        {
            this.Description = Description;
        }
    }
}
