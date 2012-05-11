using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace netRake
{
    abstract class Control
    {
        //TODO: Refactor/Abract to allow clases recieve parameters interrelated such as location, tabIndex.
        public string Name { get; set; }

        public abstract string instanciacion();
        public abstract string configuracionPropiedades();
        public abstract string declaracionVariables();
    }
    abstract class LabaledControl : Control
    {
        public string NameLbl { get; set; }
        public string NameControl { get; set ; }

        public override string instanciacion()
        {
            return "this." + NameLbl + @" = new System.Windows.Forms.Label();";
        }

        public override string configuracionPropiedades()
        {
            return
           "this." + NameLbl + @".AutoSize = true;
            this." + NameLbl + @".Location = new System.Drawing.Point(136, 35);
            this." + NameLbl + @".Name = " + "\"" + NameLbl + "\"" + @";
            this." + NameLbl + @".Size = new System.Drawing.Size(35, 13);
            this." + NameLbl + @".TabIndex = 1;
            this." + NameLbl + ".Text = \"" + Name + ":\";";
        }

        public override string declaracionVariables()
        {
            return "private System.Windows.Forms.Label " + NameLbl + ";";
        }

    }
}
namespace netRake.Controls
{

    class txtBox : LabaledControl
    {
        public override string instanciacion()
        {
            return
           "this." + NameControl + @" = new System.Windows.Forms.TextBox();" +
            base.instanciacion();
        }
        public override string configuracionPropiedades()
        {
            return
           "this." + NameControl + @".Location = new System.Drawing.Point(118, 124);
            this." + NameControl + @".Name = " + "\"" + NameControl + "\"" + @"; 
            this." + NameControl + @".Size = new System.Drawing.Size(157, 20);
            this." + NameControl + @".TabIndex = 2;" +
            base.configuracionPropiedades();
        }
        public override string declaracionVariables()
        {
            return
           "private System.Windows.Forms.TextBox " + NameControl + @";" +
            base.declaracionVariables();
        }
    }
    class chkBox : LabaledControl
    {
        public override string instanciacion()
        {
            return
           "this." + NameControl + @" = new System.Windows.Forms.CheckBox();" +
            base.instanciacion();
        }
        public override string configuracionPropiedades()
        {
            return
           "this." + NameControl + @".AutoSize = true;
            this." + NameControl + @".Location = new System.Drawing.Point(291, 75);
            this." + NameControl + @".Name = " + "\"" + NameControl + "\"" + @";
            this." + NameControl + @".Size = new System.Drawing.Size(80, 17);
            this." + NameControl + @".TabIndex = 4;
            this." + NameControl + @".UseVisualStyleBackColor = true;" +
            base.configuracionPropiedades();
        }
        public override string declaracionVariables()
        {
            return
           "private System.Windows.Forms.CheckBox" + NameControl + @";" +
            base.declaracionVariables();
        }
    }
    class dtPicker : LabaledControl
    {
        public override string instanciacion()
        {
            return
           "this." + NameControl + @" = new System.Windows.Forms.DateTimePicker();" +
            base.instanciacion();
        }
        public override string configuracionPropiedades()
        {
            return
           "this." + NameControl + @".Location = new System.Drawing.Point(410, 162);
            this." + NameControl + @".Name = " + "\"" + NameControl + "\"" + @";
            this." + NameControl + @".Size = new System.Drawing.Size(111, 20);
            this." + NameControl + @".TabIndex = 6;" +
            base.configuracionPropiedades();
        }
        public override string declaracionVariables()
        {
            return
           "private System.Windows.Forms.DateTimePicker " + NameControl + @";" +
            base.declaracionVariables();
        }
    }
    class numUD : LabaledControl
    {
        public override string instanciacion()
        {
            return
           "this." + NameControl + @" = new System.Windows.Forms.NumericUpDown();" +
            base.instanciacion();
        }
        public override string configuracionPropiedades()
        {
            return
           "this." + NameControl + @".Location = new System.Drawing.Point(434, 125);
            this." + NameControl + @".Name = " + "\"" + NameControl + "\"" + @";
            this." + NameControl + @".Size = new System.Drawing.Size(38, 20);
            this." + NameControl + @".TabIndex = 8;" +
            base.configuracionPropiedades();
        }
        public override string declaracionVariables()
        {
            return
           "private System.Windows.Forms.DateTimePicker " + NameControl + @";" +
            base.declaracionVariables();
        }
    }
}
