using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rottytooth.Rot8000
{
    public static class Rotator
    {
        public const int BMP_SIZE = 0x10000; // 65536

        public static List<char> Mappings { get; set; }

        private static int RotateNum { get; set; }

        static Rotator()
        {
            // We will populate this with all the non-control, non-surrogate characters.
            // When we rotate, we rotate through this list, which points to the valid characters (not control characters that get lost)
            Mappings = new List<char>();

            for (int i = char.MinValue; i <= BMP_SIZE; i++)
            {
                char c = (char)i;

                if (!char.IsControl(c) && !char.IsWhiteSpace(c) && !char.IsLowSurrogate(c) && !char.IsHighSurrogate(c))
                {
                    Mappings.Add(c);
                }
            }

            RotateNum = Mappings.Count / 2;
        }

        public static string Rotate(string toConvert)
        {
            StringBuilder outputString = new StringBuilder();

            for (int count = 0; count < toConvert.Length; count++)
            {
                int charloc = Mappings.FindIndex(x => x == toConvert[count]);

                // if it's out of range or a control character, don't rotate it, but add to the string
                if (charloc < 0)
                {
                    outputString.Append(toConvert[count]);
                    continue;
                }

                charloc += RotateNum;
                charloc %= Mappings.Count;

                outputString.Append(Mappings[charloc]);

            }

            return outputString.ToString();
        }
    }
}
