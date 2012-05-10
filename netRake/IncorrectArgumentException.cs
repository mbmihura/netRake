using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace netRake
{
    class IncorrectArgumentException : Exception
    {
        IComando _comando;
        string _argumento;

        public IncorrectArgumentException(IComando comando, string argumento)
        {
            _comando = comando;
            _argumento = argumento;
        }
    }
}
