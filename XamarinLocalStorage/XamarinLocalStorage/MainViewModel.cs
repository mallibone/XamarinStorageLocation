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
        private readonly string _rootDirectory;
        private const string StorageFile = "storageFile.txt";

        public MainViewModel()
        {
            LoadCommand = ReactiveCommand.Create(LoadText);
            SaveCommand = ReactiveCommand.Create(SaveText);

            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    _rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    _rootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
                    break;
                case Device.UWP:
                    // UWP: roaming storage
                    // _rootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "RoamingState");
                    // UWP: local storage
                    _rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    break;
                default:
                    // Android
                    _rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
            var filePath = Path.Combine(_rootDirectory, StorageFile);
            if (!File.Exists(filePath)) return;
            Text = File.ReadAllText(filePath);
        }

        private void SaveText()
        {
            var filePath = Path.Combine(_rootDirectory, StorageFile);
            File.WriteAllText(filePath, Text);
        }
    }
}