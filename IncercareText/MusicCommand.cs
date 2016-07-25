namespace IncercareText
{
    class MusicCommand : ICommand
    {
        public string NewMusicPath { get; private set; }
        public bool Loop { get; private set; }

        public MusicCommand(string path, bool loop) {
            NewMusicPath = path;
            Loop = loop;
        }
    }
}
