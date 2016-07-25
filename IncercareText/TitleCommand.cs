using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncercareText
{
    class TitleCommand : ICommand
    {
        public string Value { get; private set; }
        public string FontName { get; private set; }
        public string HexaColor { get; private set; }
        public float FontSize { get; private set; }

        public TitleCommand(string title, string name, string color, float size)
        {
            Value = title;
            FontName = name;
            HexaColor = color;
            FontSize = size;
        }
    }
}
