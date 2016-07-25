using System;
using System.IO;

namespace IncercareText
{
    public class CommandParser
    {
        public static bool IsCommand(string s)
        {
            if (s.Length <= 5 || s[0] != '[' || s[s.Length - 1] != ']')
                return false;

            // Now we check the existing command-types
            if (s.IndexOf("BACKGROUND") != -1)
                return true;
            if (s.IndexOf("MUSIC") != -1)
                return true;
            if (s.IndexOf("FORMTITLE") != -1)
                return true;
            if (s.IndexOf("TITLE") != -1)
                return true;
            if (s.IndexOf("FONT") != -1)
                return true;

            return false;
        }

        private static string getValueOfArgument(string s, string arg)
        {
            string value = "";

            int startPos = s.IndexOf(arg);
            if(startPos != -1)
            {
                // !!! Might throw an error if there isn't any '"'
                startPos = s.IndexOf("\"", startPos) + 1;
                int endingPos = s.IndexOf("\"", startPos);

                value = s.Substring(startPos, endingPos - startPos);
            }

            return value;
        }

        public static ICommand BuildCommand(string s)
        {
            if(s.IndexOf("MUSIC") != -1)
            {
                string musicPath = makeMusicPlayerPath(getValueOfArgument(s, "filename"));
                bool loop = (s.IndexOf("loop") != -1);
                return new MusicCommand(musicPath, loop);
            }
            else if(s.IndexOf("BACKGROUND") != -1)
            {
                string color = getValueOfArgument(s, "color");
                // Insert the 'alpha' value after the '#' sign.
                // (the background doesn't support transparency)
                color = color.Insert(color.IndexOf("#") + 1, "FF");
                return new BackgroundCommand(color);
            }
            else if (s.IndexOf("FORMTITLE") != -1)
            {
                string newTitle = getValueOfArgument(s, "value");
                return new FormTitleCommand(newTitle);
            }
            else if(s.IndexOf("TITLE") != -1)
            {
                string newTitle = getValueOfArgument(s, "value");
                string fontName;
                string fontColor;
                float fontSize;

                getFontArguments(s, out fontName, out fontColor, out fontSize);
                return new TitleCommand(newTitle, fontName, fontColor, fontSize);
            }
            else if(s.IndexOf("FONT") != -1)
            {
                string name;
                string color;
                float size;

                getFontArguments(s, out name, out color, out size);
                return new FontCommand(name, color, size);
            }

            return null;
        }

        private static void getFontArguments(string s, out string name, out string color, out float size)
        {
            name = getValueOfArgument(s, "fontName");

            color = getValueOfArgument(s, "color");
            if (!color.Equals(""))
                color = color.Insert(color.IndexOf("#") + 1, "FF");

            if (!float.TryParse(getValueOfArgument(s, "size"), out size))
                size = 0;
        }

        private static string makeMusicPlayerPath(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.LastIndexOf(@"\"));
            path = path.Remove(path.LastIndexOf(@"\"));
            path += @"\" + filename;
            return path;
        }
    }
}
