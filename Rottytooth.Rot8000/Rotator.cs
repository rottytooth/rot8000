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

        public static Dictionary<char, char> Mappings { get; set; }

        private static int RotateNum { get; set; }

        static Rotator()
        {
            // We will populate this with all the non-control, non-surrogate characters.
            // When we rotate, we rotate through this list, which points to the valid characters (not control characters that get lost)
            Mappings = new Dictionary<char, char>();

            List<char> validList = new List<char>();

            for (int i = char.MinValue; i < BMP_SIZE; i++)
            {
                char c = (char)i;

                if (!char.IsControl(c) && !char.IsWhiteSpace(c) && !char.IsLowSurrogate(c) && !char.IsHighSurrogate(c))
                {
                    validList.Add(c);
                }
            }

            RotateNum = validList.Count / 2;

            for(int i = 0; i < validList.Count; i++)
            {
                int outnum = (i + RotateNum) % validList.Count;
                Mappings[validList[i]] = validList[outnum];
            }
        }

        public static string Rotate(string toConvert)
        {
            StringBuilder outputString = new StringBuilder();

            for (int count = 0; count < toConvert.Length; count++)
            {
                if (!Mappings.ContainsKey(toConvert[count]))
                {
                    outputString.Append(toConvert[count]);
                    continue;
                }

                outputString.Append(Mappings[toConvert[count]]);
            }

            return outputString.ToString();
        }
    }
}
