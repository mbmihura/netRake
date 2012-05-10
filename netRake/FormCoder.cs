using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace netRake
{
    class FormCoder
    {
        private string _espacioDeNombre, _clase;
        List<Control> _controles;

        public FormCoder(string espacioDeNombres, string clase, List<Control> controles)
        { 
            _espacioDeNombre = espacioDeNombres;
            _clase = clase;
            _controles = controles;

        }
        public void Create(string path)
        {
            StringBuilder declareComponentVariables = new StringBuilder();
            StringBuilder initializeComponentbody = new StringBuilder();
            foreach (Control c in _controles)
            {
                declareComponentVariables.AppendLine(c.declaracionVariables());
                initializeComponentbody.AppendLine(c.instanciacion());
            }
            initializeComponentbody.AppendLine("this.SuspendLayout();");
            foreach (Control c in _controles)
            {
                initializeComponentbody.AppendLine("//" + Environment.NewLine + "// " + c.Nombre + Environment.NewLine + "//");
                initializeComponentbody.AppendLine(c.configuracionPropiedades());

            }



            StreamWriter file = new StreamWriter("");
            file.WriteLine("namespace " + _espacioDeNombre + @"
{{
    partial class " + _clase + @"
    {{
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name=" + "\"disposing\">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>" +
        @"protected override void Dispose(bool disposing)
        {{
            if (disposing && (components != null))
            {{
                components.Dispose();
            }}
            base.Dispose(disposing);
        }}

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {{
            " + initializeComponentbody.ToString() + @"
        }}

        #endregion

         " + declareComponentVariables.ToString() + @"
    }}
}}");
}
    }
}
