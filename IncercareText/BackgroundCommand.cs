namespace IncercareText
{
    class BackgroundCommand : ICommand
    {
        public string HexaColor { get; private set; }

        public BackgroundCommand(string color)
        {
            HexaColor = color;
        }
    }
}
