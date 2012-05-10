using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using System.Reflection;
using netRake.Commands;

namespace netRake
{
    class Program
    {
        static List<Control> _controls = new List<Control>();
        static Dictionary<string, Type> _comands = new Dictionary<string, Type>();

        static public Dictionary<string, Type> Commands { get { return _comands;} }

        static void Main(string[] args)
        {
            //Creates dictionary with commands defined through reflection of classes in command's namespace (netRake.Commands)
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
               if (type.Namespace == typeof(help).Namespace)
                    _comands.Add(type.Name, type);
            }

            //HACK: handy, automatic way to introduce a command during development. Eliminate in production.
            args = new string[] { "generate", "form", "myForm" };

            //Extracts Type from the first argument, 
            Type commandType = _comands[args[0]];

            //Creates an objects from that type
            ConstructorInfo commandConstructorInfo = commandType.GetConstructor(new Type[] { });
            object commandObj = commandConstructorInfo.Invoke(null);
            dynamic command = Convert.ChangeType(commandObj, commandType);

            //Execute using the rest of the arguments
            command.Execute(args.Skip(1).ToArray());

        }
    }
}
