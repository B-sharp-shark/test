using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Common;
using test.Main.Naigation;

namespace test.ViewModels
{
	public partial class BaseViewModel:ObservableObject,INavigationAware
	{
        public INavService navigationService;
        public INoteService noteService;
        public INavigationParameters keyValuePairs;

        public BaseViewModel(INavService navigationService, INoteService noteService)
        {   
            this.navigationService = navigationService;
            this.noteService = noteService;


        }


        [RelayCommand]
        public async Task GoBack()
        {
            await navigationService.GoBackAsync();
        }

        

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}

