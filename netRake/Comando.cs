using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using netRake;
using netRake.Controls;
using System.Reflection;

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
                    Dictionary<string, Type> types = new Dictionary<string, Type>();
                    List<Control> controls = new List<Control>();
                    string currentDirectoyName = Environment.CurrentDirectory;

                    types.Add("string", typeof(TxtBox));
                    types.Add("int", typeof(NumUD));
                    types.Add("datetime", typeof(DtPicker));
                    types.Add("bool", typeof(ChkBox));
                    types.Add("double", typeof(NumUD));
                    types.Add("decimal", typeof(NumUD));

                    int cropIndex = currentDirectoyName.LastIndexOf('\\') +1;
                    currentDirectoyName = currentDirectoyName.Substring(cropIndex,currentDirectoyName.Length - cropIndex);

                    for (int i = 2; i < args.Length; i += 2)
                    {
                        //Extracts Type from the first argument, 
                        Type commandType = types[args[i]];

                        //Creates an objects from that type
                        ConstructorInfo controlConstructorInfo = commandType.GetConstructor(new Type[] {typeof(string) });
                        object controlObj = controlConstructorInfo.Invoke(new object[] {args[i+1]});
                        dynamic control = Convert.ChangeType(controlObj, commandType);

                        controls.Add(control);
                    }

                    new FormCoder(currentDirectoyName, args[1], controls).Create(Environment.CurrentDirectory+"\\");

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

