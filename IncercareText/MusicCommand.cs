namespace IncercareText
{
    class MusicCommand : ICommand
    {
        public string NewMusicPath { get; private set; }
        public bool Loop { get; private set; }
        public bool Stop { get; private set; }

        public MusicCommand(string path, bool loop, bool stop = false) {
            NewMusicPath = path;
            Loop = loop;
            Stop = stop;
        }
    }
}
