using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netRake;

namespace netRake
{
     interface IComando
    {
         void Execute(string[] args);
    }
}

namespace netRake.Commands
{
    class generate : IComando
    {

        public generate()
        {
            Console.WriteLine("se genero!"); //TODO: for debug, delete in producction
        }

        public void Execute(string[] args)
        {
            switch (args[0])
            {
                case "form":
                    List<Control> controls = new List<Control> ();
                    string currentDirectoyName = Environment.CurrentDirectory;
                    int cropIndex = currentDirectoyName.LastIndexOf('\\') +1;
                    currentDirectoyName = currentDirectoyName.Substring(cropIndex,currentDirectoyName.Length - cropIndex);
                    new FormCoder(currentDirectoyName, args[1], controls).Create(Environment.CurrentDirectory);
                    break;
                default:
                    throw new IncorrectArgumentException(this, args[0]);
            }
        }
    }

    class help : IComando
    {
        public void Execute(string[] args)
        {
            switch (args[0])
            {
                case null:
                    Console.WriteLine("Available commands:");

                    foreach (string classname in Program.Commands.Keys)
                        Console.WriteLine("  " + classname);
                    break;
                default:
                    throw new IncorrectArgumentException(this, args[0]);

            }
        }
    }
}

