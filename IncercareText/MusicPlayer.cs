namespace IncercareText
{
    class MusicPlayer
    {
        private WMPLib.WindowsMediaPlayer player;

        public MusicPlayer()
        {
            player = new WMPLib.WindowsMediaPlayer();
        }

        public void PlayFile(string filepath, bool loop)
        {
            player.URL = filepath;
            (player.settings as WMPLib.IWMPSettings).setMode("loop", loop);
            player.controls.play();
        }

        public void OnCommandIssued(object source, CommandIssuedArgs args)
        {
            var command = args.Command as MusicCommand;
            if(command != null)
            {
                PlayFile(command.NewMusicPath, command.Loop);
            }
        }
    }
}
