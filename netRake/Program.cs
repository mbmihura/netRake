using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using System.Reflection;

namespace netRake
{
    class Program
    {
        static List<Control> _controles = new List<Control>();
        static Dictionary<string, Type> _comandos = new Dictionary<string, Type>();

        static public Dictionary<string, Type> Comandos { get { return _comandos;} }

        static void Main(string[] args)
        {

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
               if (type.Namespace == "netRake.Comandos")
                    _comandos.Add(type.Name, type);
            }

            args = new string[] { "Generate", null };

            Type t = _comandos[args[0]];
            ConstructorInfo comando = t.GetConstructor(new Type[] {});
            string[] arg = args.Skip(1).ToArray();
            object var = comando.Invoke(null);

            netRake.Comandos.Generate g = (netRake.Comandos.Generate) var;
            g.Ejecutar(args[1]);
        }
    }
}
