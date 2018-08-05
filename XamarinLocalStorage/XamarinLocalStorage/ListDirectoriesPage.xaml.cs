using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinLocalStorage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListDirectoriesPage : ContentPage
	{
		public ListDirectoriesPage ()
		{
			InitializeComponent ();
		    BindingContext = DirectoryDescriptions();
		}

	    private IEnumerable<DirectoryDesc> DirectoryDescriptions()
	    {
	        var specialFolders = Enum.GetValues(typeof(Environment.SpecialFolder)).Cast<Environment.SpecialFolder>();
	        return specialFolders.Select(s => new DirectoryDesc(s.ToString(), Environment.GetFolderPath(s))).Where(d => !string.IsNullOrEmpty(d.Path));
	    }
	}

    internal class DirectoryDesc
    {
        public DirectoryDesc(string key, string path)
        {
            Key = key;
            
            Path = path == null
                ? ""
                : string.Join(System.IO.Path.DirectorySeparatorChar.ToString(), path.Split(System.IO.Path.DirectorySeparatorChar).Select(s => s.Length > 18 ? s.Substring(0, 5) + "..." + s.Substring(s.Length - 8, 8) : s));
        }

        public string Key { get; set; }
        public string Path { get; set; }
    }
}