using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rottytooth.Rot8000
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim() == "/js")
                {
                    string transitions = JsonConvert.SerializeObject(Rotator.ValidityTransitions);

                    File.WriteAllText(
                        AppDomain.CurrentDomain.BaseDirectory + @"\valid-code-point-transitions.json",
                        transitions);
                }
                else
                {
                    Console.WriteLine(Rotator.Rotate(args[0]));
                }
            }
        }
    }
}
