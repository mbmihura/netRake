using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netRake;

namespace netRake
{
     interface IComando
    {
         void Ejecutar(string args);
    }
}

namespace netRake.Comandos
{
    class Generate : IComando
    {

        public Generate()
        {
            Console.WriteLine("se genero!");
        }

        public void Ejecutar(string args)
        {
            switch (args)
            {
                case null:
                    Console.WriteLine("Working dir: "+ Environment.CurrentDirectory);
                    break;
                default:
                    throw new IncorrectArgumentException(this, args);
            }
        }
    }

    class help : IComando
    {
        public void Ejecutar(string args)
        {
            switch (args)
            {
                case null:
                    Console.WriteLine("Available commands:");

                    foreach (string classname in Program.Comandos.Keys)
                        Console.WriteLine("  " + classname);
                    break;
                default:
                    throw new IncorrectArgumentException(this, args);
            }
        }
    }
}

