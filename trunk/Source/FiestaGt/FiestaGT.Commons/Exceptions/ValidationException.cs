using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiestaGT.Commons.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
