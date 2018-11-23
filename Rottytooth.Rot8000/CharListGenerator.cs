using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rottytooth.Rot8000
{
    public class CharListGenerator
    {
        private Dictionary<int, bool> _validSwitch;

        public void BuildChanges()
        {
            bool isValid = false;
            _validSwitch = new Dictionary<int, bool>();

            for (int i = char.MinValue; i < Rotator.BMP_SIZE; i++)
            {
                char c = (char)i;

                if (!char.IsControl(c) && !char.IsWhiteSpace(c) && !char.IsLowSurrogate(c) && !char.IsHighSurrogate(c))
                {
                    if (!isValid)
                    {
                        _validSwitch.Add(i, true);
                        isValid = true;
                    }
                }
                else
                {
                    if (isValid)
                    {
                        _validSwitch.Add(i, false);
                        isValid = false;
                    }
                }
            }

            int k = 0; k++;
        }
    }
}
