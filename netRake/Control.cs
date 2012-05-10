using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace netRake
{
    abstract class Control
    {
        private string _nombre;
        public string Nombre { get; set; }

        public abstract string instanciacion();

        public abstract string configuracionPropiedades();

        public abstract string declaracionVariables();

    }
}
