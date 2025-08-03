using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rottytooth.Rot8000
{
    public static class Rotator
    {
        public const int BMP_SIZE = 0x10000; // 65536

        public static Dictionary<char, char> Mappings { get; set; }

        private static int RotateNum { get; set; }

        /// <summary>
        /// List of transitions in code point validity, to build JS version
        /// </summary>
        public static Dictionary<int, bool> ValidityTransitions { get; set; }


        static Rotator()
        {
            // We will populate this with all the non-control, non-surrogate characters.
            // When we rotate, we rotate through this list, which points to the valid characters (not control characters that get lost)
            Mappings = new Dictionary<char, char>();

            ValidityTransitions = new Dictionary<int, bool>();

            List<char> validList = new List<char>();

            bool isValid = false;

            for (int i = char.MinValue; i < BMP_SIZE; i++)
            {
                char c = (char)i;

                if (!char.IsControl(c) && !char.IsWhiteSpace(c) && !char.IsLowSurrogate(c) && !char.IsHighSurrogate(c))
                {
                    validList.Add(c);
                    TestAndSwitchValidity(i, ref isValid, false);
                }
                else
                {
                    TestAndSwitchValidity(i, ref isValid, true);
                }
                if (i == 57343)
                {
                    int k = 0; k++;
                }
            }

            RotateNum = validList.Count / 2;

            for(int i = 0; i < validList.Count; i++)
            {
                int outnum = (i + RotateNum) % validList.Count;
                Mappings[validList[i]] = validList[outnum];
            }
        }

        // if the previous code pooint was invalid and this is valid, add marker, and same 
        // in other direction
        public static void TestAndSwitchValidity(int i, ref bool v, bool compare)
        {
            if (v == compare)
            {
                ValidityTransitions.Add(i, !v);
                v = !v;
            }
        }

        public static string Rotate(string toConvert)
        {
            StringBuilder outputString = new StringBuilder();

            for (int count = 0; count < toConvert.Length; count++)
            {
                // if it is not in the mappings list, just add it directly (no rotation)
                if (!Mappings.ContainsKey(toConvert[count]))
                {
                    outputString.Append(toConvert[count]);
                    continue;
                }

                // otherwise, rotate it and add it to the string
                outputString.Append(Mappings[toConvert[count]]);
            }

            return outputString.ToString();
        }
    }
}
