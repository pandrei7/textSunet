using System;
using System.Drawing;
using System.Windows.Forms;

namespace IncercareText
{
    public partial class Form1 : Form
    {
        private FileParser parser;
        private bool isRewinded;
        private bool storyEnded;

        private MusicPlayer musicPlayer;

        // Aeshetics
        private Aesthetics currentStoryTitleAesthetics;
        private Aesthetics previousStoryTitleAesthetics;

        private Aesthetics currentStoryTextboxAesthetics;
        private Aesthetics previousStoryTextboxAesthetics;

        private string currentStoryTitle;
        private string previousStoryTitle;

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            parser = new FileParser("../../test.txt");

            musicPlayer = new MusicPlayer();

            // We subscribe to the CommandIssued event of the file parser
            // so that we can execute commands as soon as they are parsed
            parser.CommandIssued += musicPlayer.OnCommandIssued;
            parser.CommandIssued += this.OnCommandIssued;

            storyEnded = false;
            advanceStory();

            // Don't allow the rewind button to be clicked on the first section
            rewindButton.Enabled = false;

            // Initialize aesthetics
            updateCurrentAesthetics();
            previousStoryTextboxAesthetics = currentStoryTextboxAesthetics;
            previousStoryTitleAesthetics = currentStoryTitleAesthetics;

            currentStoryTitle = storyTitleLabel.Text;
            previousStoryTitle = currentStoryTitle;
        }

        private void advanceButton_Click_1(object sender, EventArgs e)
        {
            // Instead of 'advancing' the aesthetics...
            // (since I can't actually do that)
            if (!isRewinded)
            {
                // Save the current aesthetics, because they
                // may change while parsing the next section
                saveCurrentAesthetics();
                previousStoryTitle = currentStoryTitle;
            }
            else
            {
                // Load the saved aesthetics
                storyTextbox.Font = currentStoryTextboxAesthetics.Font;
                storyTextbox.BackColor = currentStoryTextboxAesthetics.BackColor;
                storyTextbox.ForeColor = currentStoryTextboxAesthetics.ForeColor;

                storyTitleLabel.Font = currentStoryTitleAesthetics.Font;
                storyTitleLabel.ForeColor = currentStoryTitleAesthetics.ForeColor;

                storyTitleLabel.Text = previousStoryTitle;
            }
            advanceStory();
        }

        private void advanceStory()
        {
            // If the last action wasn't 'rewind', advance the story
            if (!isRewinded)
            {
                // I had to use another string for the next section
                // because i couldn't check if storyTextbox.Text was null
                string nextSection = parser.NextSection();
                if(nextSection == null)
                    storyEnded = true;
            }

            storyTextbox.Text = parser.CurrentSection;

            // Reset rewinding 'mechanism'
            isRewinded = false;
            rewindButton.Enabled = true;

            // Disable advanceButton if necessary
            if (storyEnded)
                advanceButton.Enabled = false;
        }

        private void rewindButton_Click_1(object sender, EventArgs e)
        {
            rewindAesthetics();
            storyTitleLabel.Text = previousStoryTitle;
            rewindStory();
        }

        private void rewindStory()
        {
            storyTextbox.Text = parser.PreviousSection;
            isRewinded = true;
            rewindButton.Enabled = false;

            // Reset advance button (only necessary after the story ended)
            advanceButton.Enabled = true;
        }

        private void OnCommandIssued(object source, CommandIssuedArgs args)
        {
            var backgroundCommand = args.Command as BackgroundCommand;
            if(backgroundCommand != null)
            {
                storyTextbox.BackColor = colorFromHexa(backgroundCommand.HexaColor);
            }

            var titleCommand = args.Command as TitleCommand;
            if(titleCommand != null)
            {
                storyTitleLabel.Text = titleCommand.Value;

                // Change the font of the label.
                // If the command contains valid values, I use those.
                // Otherwise, I use the already-existing values.
                string fontName = storyTitleLabel.Font.Name;
                if (!titleCommand.FontName.Equals(""))
                    fontName = titleCommand.FontName;

                float fontSize = storyTitleLabel.Font.Size;
                if (titleCommand.FontSize > 0)
                    fontSize = titleCommand.FontSize;

                storyTitleLabel.Font = new Font(fontName, fontSize);

                if (!titleCommand.HexaColor.Equals(""))
                    storyTitleLabel.ForeColor = colorFromHexa(titleCommand.HexaColor);

            }

            var fontCommand = args.Command as FontCommand;
            if(fontCommand != null)
            {
                string name = storyTextbox.Font.Name;
                if (!fontCommand.FontName.Equals(""))
                    name = fontCommand.FontName;

                float size = storyTextbox.Font.Size;
                if (fontCommand.FontSize > 0)
                    size = fontCommand.FontSize;

                storyTextbox.Font = new Font(name, size);

                if (!fontCommand.HexaColor.Equals(""))
                    storyTextbox.ForeColor = colorFromHexa(fontCommand.HexaColor);

            }

            var formTitleCommand = args.Command as FormTitleCommand;
            if (formTitleCommand != null)
            {
                this.Text = formTitleCommand.Value;
            }

            // Save the changes made by this function.
            updateCurrentAesthetics();
        }

        private void updateCurrentAesthetics()
        {
            currentStoryTextboxAesthetics = new Aesthetics(storyTextbox.Font, storyTextbox.BackColor, storyTextbox.ForeColor);
            currentStoryTitleAesthetics = new Aesthetics(storyTitleLabel.Font, storyTitleLabel.BackColor, storyTitleLabel.ForeColor);
        }

        private void saveCurrentAesthetics()
        {
            previousStoryTextboxAesthetics = currentStoryTextboxAesthetics;
            previousStoryTitleAesthetics = currentStoryTitleAesthetics;
        }

        private void rewindAesthetics()
        {
            storyTextbox.Font = previousStoryTextboxAesthetics.Font;
            storyTextbox.BackColor = previousStoryTextboxAesthetics.BackColor;
            storyTextbox.ForeColor = previousStoryTextboxAesthetics.ForeColor;

            storyTitleLabel.Font = previousStoryTitleAesthetics.Font;
            storyTitleLabel.ForeColor = previousStoryTitleAesthetics.ForeColor;
        }

        private Color colorFromHexa(string hexa)
        {
            ColorConverter converter = new ColorConverter();
            return (Color)converter.ConvertFromString(hexa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
