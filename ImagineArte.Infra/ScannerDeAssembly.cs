using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImagineArte.Infra
{
    public static class ScannerDeAssembly
    {
        public static List<Type> ObterTipos(params string[] assemblies)
        {
            List<Type> tipos = new List<Type>();

            foreach (var name in assemblies)
            {
                tipos.AddRange(Assembly.Load(name)
                    .GetTypes()
                    .Where(type => type.IsAssignableFrom(type)
                        && !type.IsAbstract
                        && !type.IsInterface
                        && !type.Name.StartsWith("<>"))
                    .ToList());
            }

            return tipos;
        }
    }
}
