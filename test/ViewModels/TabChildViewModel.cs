using System;
using test.Main.Naigation;

namespace test.ViewModels
{
	public class TabChildViewModel:BaseViewModel
	{
		public TabChildViewModel(INavService navigationService, INoteService noteService) : base(navigationService, noteService)
        {
		}
	}
}

