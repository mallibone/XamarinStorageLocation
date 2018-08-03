using System;
using System.IO;
using System.Windows.Input;
using ReactiveUI;
using Xamarin.Forms;

namespace XamarinLocalStorage
{
    public class MainViewModel : ReactiveObject
    {
        private string _text;
        private readonly string _directoryPath;
        private const string StorageFile = "storageFile.txt";

        public MainViewModel()
        {
            LoadCommand = ReactiveCommand.Create(LoadText);
            SaveCommand = ReactiveCommand.Create(SaveText);

            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "Library");
                    break;
                case Device.UWP:
                    // UWP: roaming storage
                    // _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "RoamingState");
                    // UWP: local storage
                    _directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    break;
                default:
                    // Android
                    _directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
            }

            LoadText();
        }

        public ICommand LoadCommand { get; }

        public ICommand SaveCommand { get; }

        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }

        private void LoadText()
        {
            var filePath = Path.Combine(_directoryPath, StorageFile);
            if (!File.Exists(filePath)) return;
            Text = File.ReadAllText(filePath);
        }

        private void SaveText()
        {
            var filePath = Path.Combine(_directoryPath, StorageFile);
            File.WriteAllText(filePath, Text);
        }
    }
}