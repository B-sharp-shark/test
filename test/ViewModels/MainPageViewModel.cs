using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace test.ViewModels
{
	public partial class MainPageViewModel:BaseViewModel
	{
        [ObservableProperty]
        private ObservableCollection<Note> notes;

        private Note SelectedNote;

        [RelayCommand]
        private async Task GoToNoteDetail(Note selectedNote)
        {
            SelectedNote = selectedNote;
            await navigationService.CreateBuilder()
                .AddParameter("NoteDetail", selectedNote)
                .AddSegment<NoteDetailPageViewModel>()
                .NavigateAsync();
        }
        public MainPageViewModel(INavigationService navigationService, INoteService noteService) : base(navigationService, noteService)
        {
            Notes = new ObservableCollection<Note>(noteService.Notes);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Note noteParam;
            parameters.TryGetValue<Note>("Note", out noteParam);

            //A selection was earlier made
            if (noteParam != null)
            {
                if (noteParam.Index == 0)
                {
                    if (noteService.AddNote(noteParam))
                    {
                        Notes.Add(noteParam);
                    }
                }
                else
                {
                    if (noteService.UpdateNote(noteParam) != null)
                    {
                        int index = Notes.IndexOf(SelectedNote);
                        Notes.Remove(SelectedNote);
                        Notes.Insert(index, noteParam);
                    }
                }
            }

            parameters.TryGetValue<Note>("DeleteNote", out noteParam);
            if (noteParam != null)
            {
                if (noteService.RemoveNote(noteParam.Index))
                {
                    int index = Notes.IndexOf(SelectedNote);
                    Notes.Remove(SelectedNote);

                    //Reassign the index of the remaining notes

                    for (int i = index; i < Notes.Count; i++)
                    {
                        var reArrange = Notes.ElementAt(i);
                        Notes.Remove(reArrange);
                        reArrange.Index = reArrange.Index - 1;
                        Notes.Insert(index, reArrange);
                    }
                    Notes = Notes;
                }
            }
        }

    }
}

