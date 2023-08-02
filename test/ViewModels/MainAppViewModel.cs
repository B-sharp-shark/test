using System;
using test.Main.Naigation;

namespace test.ViewModels
{
	public partial class MainAppViewModel: BaseViewModel
    {
		public MainAppViewModel(INavService navigationService, INoteService noteService):base(navigationService, noteService)
		{

		}
	}
}

