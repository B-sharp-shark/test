using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Navigation;

namespace test.ViewModels
{
	public partial class NoteDetailPageViewModel : BaseViewModel
	{
		[ObservableProperty]
		private Note note = new Note();

        
        [ObservableProperty]
        private bool update = false;

        [RelayCommand]
        private async Task AddNote()
        {
            var navParameters = new NavigationParameters
            {
                { "Note", Note }
            };
            await ClosePage(navParameters);
        }

        [RelayCommand]
        private async Task Delete()
        {
            var navParameters = new NavigationParameters
            {
                { "DeleteNote", Note }
            };

            if (await pageDialogService.DisplayAlertAsync("Confirm", "Do you want to delete","Yes","No"))
            {
                await ClosePage(navParameters);
            }
        }

        [RelayCommand]
        private async Task UpdateNote()
        {
            var navParameters = new NavigationParameters
            {
                { "Note", Note }
            };
            await ClosePage(navParameters);
        }

        [RelayCommand]
        public async Task CloseNote()
        {
            var navParameters = new NavigationParameters
            {
                { "Note", null }
            };
            await ClosePage(navParameters);
        }

        private async Task ClosePage(NavigationParameters navParameters)
        {
            await navigationService.GoBackAsync(navParameters);
        }
        IPageDialogService pageDialogService;
        public NoteDetailPageViewModel(INavigationService navigationService,INoteService noteService, IPageDialogService pageDialogService) :base(navigationService, noteService)
		{
            this.pageDialogService = pageDialogService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            Note noteParam;
            parameters.TryGetValue<Note>("NoteDetail", out noteParam);

            if (noteParam!= null)
            {
                Note = JsonSerializer.Deserialize<Note>(JsonSerializer.Serialize(noteParam));
                Update = true;
            }
        }
    }
}

