using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncercareText
{
    class FontCommand : ICommand
    {
        public string FontName { get; private set; }
        public string HexaColor { get; private set; }
        public float FontSize { get; private set; }

        public FontCommand(string name, string color, float size)
        {
            FontName = name;
            HexaColor = color;
            FontSize = size;
        }
    }
}
