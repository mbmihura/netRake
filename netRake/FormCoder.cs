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
            _espacioDeNombre = espacioDeNombres.Substring(0, 1).ToUpper() + espacioDeNombres.Substring(1); //TODO: refactor method
            _clase = clase.Substring(0,1).ToUpper() + clase.Substring(1);
            _controles = controles;
         }
        public void Create(string filePath)
        {
            StringBuilder declareComponentVariables = new StringBuilder();
            StringBuilder initializeComponentbody = new StringBuilder();

            Console.WriteLine("Creating " + _clase + " in " + _espacioDeNombre + ".Forms"+ Environment.NewLine + "Synthesizing code...");
            foreach (Control c in _controles)
            {
                declareComponentVariables.AppendLine(c.declaracionVariables());
                initializeComponentbody.AppendLine(c.instanciacion());
            }
            initializeComponentbody.AppendLine("this.SuspendLayout();");

            foreach (Control c in _controles)
            {
                initializeComponentbody.AppendLine("//" + Environment.NewLine + "// " + c.Name + Environment.NewLine + "//");
                initializeComponentbody.AppendLine(c.configuracionPropiedades());

            }
            
            string fileName = filePath + _clase + ".Designer.cs";
            StreamWriter file = new StreamWriter(fileName);
            file.WriteLine(@"namespace " + _espacioDeNombre + @".Forms
{
    partial class " + _clase + @"
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name=" + "\"disposing\">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>" + @"
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            " + initializeComponentbody.ToString() + @"
            // 
            // "+_clase+@"
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = " + "\"" + _clase + "\"" + @";
            this.Text = " + "\"" + _clase + "\"" + @";
            this.ResumeLayout(false);
        }

        #endregion

         " + declareComponentVariables.ToString() + @"
    }
}");
            file.Close();
            Console.WriteLine("Saved as " + fileName);

            fileName = filePath + _clase + ".cs";
            file = new StreamWriter(fileName);
            file.WriteLine(@"using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace " + _espacioDeNombre + @".Forms
{
    public partial class " + _clase + @" : Form
    {
        public " + _clase + @"()
        {
            InitializeComponent();
        }
    }
}");
            file.Close();
            Console.WriteLine("Saved as " + fileName);
}
    }
}
