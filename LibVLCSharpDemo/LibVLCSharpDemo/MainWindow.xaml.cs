using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LibVLCSharpDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibVLC _libVLC;
        List<string> VideoList = new List<string>();
        int currentIndex = 0;
        DispatcherTimer Timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            VideoList.Add(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Videos", "1.mp4"));
            VideoList.Add(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Videos", "2.mp4"));
            Timer.Interval = TimeSpan.FromSeconds(20);
            Timer.Tick += Timer_Tick;
            _libVLC = new LibVLC(enableDebugLogs: true);
            VideoView.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libVLC);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (VideoView.MediaPlayer.IsPlaying)
                {
                    VideoView.MediaPlayer.Pause();
                }
            }
            catch (Exception ex)
            {
            }
            PlayNext();
        }
        private void PlayNext()
        {
            try
            {
                Timer.Stop();

                Play(VideoList[currentIndex]);
                currentIndex++;
                if (currentIndex >= VideoList.Count)
                {
                    currentIndex = 0;
                }
                Timer.Start();

            }
            catch (Exception ex)
            {
            }
        }
        private void Play(string VideoPath)
        {
            try
            {
                using (var media = new Media(_libVLC, new Uri(VideoPath)))
                {
                    media.AddOption(new MediaConfiguration { EnableHardwareDecoding = true});
                    VideoView.MediaPlayer.Play(media);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlayNext();
        }
    }
}
