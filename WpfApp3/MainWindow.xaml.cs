using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using MaterialDesignThemes;
using System.Threading;
using System.Windows.Controls.Primitives;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread1(false);

        }
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            LBox.ItemsSource = null;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            var dir = dialog.ShowDialog();
            string path = "";
            if (dir == CommonFileDialogResult.Ok)
            {
                vars.files = Directory.GetFiles(dialog.FileName);
                List<string> filess = new List<string>();
                List<string> filesss = new List<string>();
                path = vars.files[0];
                int a = 0;
                foreach (string file in vars.files)
                {
                    if (file.Contains(".mp3") | file.Contains(".wav") | file.Contains(".m4a"))
                    {
                        filess.Add(file);
                        a++;
                    }
                }
                string k;
                foreach (string file in filess)
                {
                    FileInfo f = new FileInfo(file);
                    k = f.Name;
                    filesss.Add(k);
                }
                LBox.ItemsSource = filesss;
                vars.ind = 0;
            }
            track.LoadedBehavior = MediaState.Manual;
            track.Source = new Uri(path);
            track.Position = TimeSpan.Zero;
            track.Play();
            vars.isplay = true;
        }
        public void Thread1(bool isClosed)
        {
            
            Thread thr1 = new Thread(_ =>
            {
                while (true)
                {
                    
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        if (track.Position.Seconds<10)
                        {
                            FBox.Text = Convert.ToString(track.Position.Minutes) + ":0" + Convert.ToString(track.Position.Seconds);
                        }
                        else
                        {
                            FBox.Text = Convert.ToString(track.Position.Minutes) + ":" + Convert.ToString(track.Position.Seconds);
                        }
                        if (track.NaturalDuration.HasTimeSpan == true)
                        {
                            if (((Math.Floor(track.NaturalDuration.TimeSpan.TotalSeconds) % 60) - track.Position.Seconds) < 10)
                            {
                                SBox.Text = " ";
                                SBox.Text = "-" + Convert.ToString((Math.Floor(track.NaturalDuration.TimeSpan.TotalMinutes)) - track.Position.Minutes) + ":0" + Convert.ToString((Math.Floor(track.NaturalDuration.TimeSpan.TotalSeconds) % 60) - track.Position.Seconds);
                            }
                            else
                            {
                                SBox.Text = " ";
                                SBox.Text = "-" + Convert.ToString((Math.Floor(track.NaturalDuration.TimeSpan.TotalMinutes)) - track.Position.Minutes) + ":" + Convert.ToString((Math.Floor(track.NaturalDuration.TimeSpan.TotalSeconds) % 60) - track.Position.Seconds);
                            }
                        } 
                        if (vars.isplay) { TimeSlider.Value = track.Position.Ticks; }
                        
                    }));
                    Thread.Sleep(1000);
                }
            });
            if (!isClosed) { thr1.Start(); }
/*            else { thr1.Abort(); }*/
            
        }
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (vars.isplay)
            {
                track.Pause();
                PauseButton.Background = Brushes.Violet;
                vars.isplay = false;
            }
            else
            {
                track.Play();
                PauseButton.Background = Brushes.WhiteSmoke;
                vars.isplay = true;
            }
        }

        private void PreviousTButton_Click(object sender, RoutedEventArgs e)
        {
            vars.ind--;
            if (vars.ind < 0)
            {
                vars.ind = vars.files.Length - 1;
            }
            track.Source = new System.Uri(vars.files[vars.ind]);
            track.Position = TimeSpan.Zero;
            track.Play();
        }

        private void NextTButton_Click(object sender, RoutedEventArgs e)
        {
            vars.ind++;
            if (vars.ind > vars.files.Length - 1)
            {
                vars.ind = 0;
            }
            track.Source = new System.Uri(vars.files[vars.ind]);
            track.Position = TimeSpan.Zero;
            track.Play();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            if (vars.replay == true)
            {
                vars.replay = false;
                RestartButton.Background = Brushes.WhiteSmoke;
            }
            else if (vars.replay == false)
            {
                vars.replay = true;
                RestartButton.Background = Brushes.Violet;
            }
            if (track.Position == track.NaturalDuration)
            {
                track.Position = TimeSpan.Zero;
                track_MediaEnded(sender, e);
            }
        }

        private void LBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vars.ind = LBox.SelectedIndex;
            track.Source = new System.Uri(vars.files[vars.ind]);
            track.Position = TimeSpan.Zero;
            track.Play();
        }


        private void track_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (!vars.replay)
            {
                vars.ind++;
                if (vars.shuffle)
                {
                    Random rnd = new Random();
                    vars.ind = rnd.Next(0, vars.files.Length - 1);
                }
            }
            if (vars.isplay && vars.ind > vars.files.Length - 1)
            {
                vars.ind = 0;
            }
            track.Source = new System.Uri(vars.files[vars.ind]);
            track.Position = TimeSpan.Zero;
            track.Play();
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            if (vars.shuffle == true)
            {
                vars.shuffle = false;
                ShuffleButton.Background = Brushes.WhiteSmoke;
            }
            else if (vars.shuffle == false)
            {
                vars.shuffle = true;
                ShuffleButton.Background = Brushes.Violet;
            }
            if (track.Position == track.NaturalDuration)
            {
                track.Position = TimeSpan.Zero;
                track_MediaEnded(sender, e);
            }
        }

        private void track_MediaOpened(object sender, RoutedEventArgs e)
        {
            track.Volume = 1;
            VolumeSlider.Value = track.Volume*100;
            TimeSlider.Maximum = track.NaturalDuration.TimeSpan.Ticks;
            VolumeSlider.Maximum = 100;
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (vars.isplay)
            {
                track.Position = new TimeSpan(Convert.ToInt32(TimeSlider.Value));
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (vars.isplay)
            {
                track.Volume = VolumeSlider.Value/100;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Thread1(true);
        }
    }
}
