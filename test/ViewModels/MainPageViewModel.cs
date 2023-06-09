using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace test.ViewModels
{
	public partial class MainPageViewModel:BaseViewModel
	{
        [ObservableProperty]
        private ObservableCollection<Note> note = new ObservableCollection<Note>()
		{
			new Note{Index = 0, ColorHex = "#C299F5" },
            new Note{Index = 1, ColorHex = "#90F97D" },
			new Note{Index = 2, ColorHex = "#A8D8F3" },
			new Note{Index = 3, ColorHex = "#FED390"},
		};


        public MainPageViewModel()
		{

		}
	}
}

