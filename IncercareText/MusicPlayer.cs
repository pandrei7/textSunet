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
                if (command.Stop)
                {
                    player.controls.stop();
                }
                else
                {
                    PlayFile(command.NewMusicPath, command.Loop);
                }
            }
        }
    }
}
