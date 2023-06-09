using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace test.ViewModels.Base
{
	public partial class BaseViewModel:ObservableObject,INavigationAware
	{
        public INavigationService navigationService;
        public INoteService noteService;
        public INavigationParameters keyValuePairs;

        public BaseViewModel(INavigationService navigationService, INoteService noteService)
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

