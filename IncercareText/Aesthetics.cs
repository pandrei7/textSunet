using System.Drawing;

namespace IncercareText
{
    class Aesthetics
    {
        public Font Font { get; private set; }
        public Color BackColor { get; private set; }
        public Color ForeColor { get; private set; }

        public Aesthetics(Font font, Color backColor, Color foreColor)
        {
            // I used 'this' because of Font...
            this.Font = font;
            this.BackColor = backColor;
            this.ForeColor = foreColor;
        }
    }
}
