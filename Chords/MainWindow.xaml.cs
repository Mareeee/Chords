using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace SoundPlayerApp
{
    public partial class MainWindow : Window
    {
        private MediaPlayer _mediaPlayer;
        private string _selectedFilePath;

        public MainWindow()
        {
            InitializeComponent();
            _mediaPlayer = new MediaPlayer();
        }

        private void UploadChord_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files (*.wav;*.mp3)|*.wav;*.mp3";
            openFileDialog.Title = "Select a Sound File";

            if (openFileDialog.ShowDialog() == true)
            {
                _selectedFilePath = openFileDialog.FileName;
                _mediaPlayer.Open(new Uri(_selectedFilePath));
                PlayChord.IsEnabled = true;
            }
        }
        private void PlayChord_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedFilePath != null)
            {
                _mediaPlayer.Position = TimeSpan.Zero;
                _mediaPlayer.Play();
            }
            else
            {
                MessageBox.Show("No chord selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
