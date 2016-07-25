using System;
using System.IO;
using System.Windows.Forms;

namespace IncercareText
{
    class FileParser
    {
        private StreamReader reader;

        public string CurrentSection { get; private set; }
        public string PreviousSection { get; private set; }

        public string Separator { get; set; } = "[STOP]";
        public string EndingString { get; set; } = "Sfarsit";

        // For handling commands found inside the file (while parsing)
        public delegate void CommandIssuedEventHandler(object source, CommandIssuedArgs args);
        public event CommandIssuedEventHandler CommandIssued;

        public FileParser(string filename)
        {
            // Open the StreamReader
            try
            {
                reader = new StreamReader(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            CurrentSection = PreviousSection = "";
        }

        public string NextSection()
        {
            // Save the current section
            PreviousSection = CurrentSection;

            string line = reader.ReadLine();

            // If we reached EOF, we should return null
            if (line == null)
            {
                // We set the CurrentSection to an 'ending' string
                CurrentSection = EndingString;
                return null;
            }

            // Build the next section
            CurrentSection = "";
            while (line != null && line.CompareTo(Separator) != 0)
            {
                if (CommandParser.IsCommand(line))
                {
                    OnCommandIssued(CommandParser.BuildCommand(line));
                }
                else
                {
                    CurrentSection += line + "\n";
                }
                line = reader.ReadLine();
            }

            return CurrentSection;
        }

        protected virtual void OnCommandIssued(ICommand command)
        {
            // THe same as: if(CommandIssued != null) ...
            CommandIssued?.Invoke(this, new CommandIssuedArgs(command));
        }
    }
}
