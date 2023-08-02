using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using test.Main.Naigation;


namespace test.ViewModels
{
	public partial class MainPageViewModel:BaseViewModel
	{
        [ObservableProperty]
        private List<NoteType> noteTypes = Enum.GetValues(typeof(NoteType))
                            .Cast<NoteType>()
                            .ToList();
        [ObservableProperty]
        private ObservableCollection<Note[]> notes;

        private Note SelectedNote;
        private int SelectedNoteViewRow;
        private int SelectedNoteViewCol;

        [RelayCommand]
        private async Task GoToNoteDetail(Note selectedNote)
        {
            navigationService.AddTabAsync("");
            return;
            //Try to update or delete
            if (selectedNote != null)
            {
                int row = 0;
                SelectedNote = selectedNote;
                foreach (var item in Notes)
                {
                    if (item[0] == SelectedNote || item[1] == SelectedNote)
                    {
                        SelectedNoteViewRow = row;
                        SelectedNoteViewCol = (item[0] == SelectedNote) ? 0 : 1;

                        break;
                    }
                    row++;
                }
            }
            
            await navigationService.CreateBuilder()
                .AddParameter("NoteDetail", selectedNote)
                .AddSegment<NoteDetailPageViewModel>()
                .NavigateAsync();
        }
        public MainPageViewModel(INavService navigationService, INoteService noteService) : base(navigationService, noteService)
        {
            Notes = new ObservableCollection<Note[]>();

            int col = 0;
            Note[] noteArr = new Note[2];
            foreach (var note in noteService.Notes)
            {
                noteArr[col] = note;
                if (col == 1)
                {
                    col = 0;
                    Notes.Add(noteArr);
                    noteArr = new Note[2];
                    continue;
                }
                col++;
            }

            if (noteService.Notes.Count % 2 != 0)
            {
                noteArr = new Note[1];
                noteArr[0] = noteService.Notes.Last();
                Notes.Add(noteArr);
            }

            //Load other tabs
            
        }

        public void AddToNoteArray()
        {

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            

            Note noteParam;
            parameters.TryGetValue<Note>("AddNote", out noteParam);
            Note[] noteArr = new Note[2];




            //A selection was earlier made
            if (noteParam != null)
            {
                if (noteService.AddNote(noteParam))
                {
                    Notes = new ObservableCollection<Note[]>();

                    int col = 0;
                    noteArr = new Note[2];
                    foreach (var note in noteService.Notes)
                    {
                        noteArr[col] = note;
                        if (col == 1)
                        {
                            col = 0;
                            Notes.Add(noteArr);
                            OnPropertyChanged(nameof(Notes));
                            noteArr = new Note[2];
                            continue;
                        }
                        col++;
                    }

                    if (noteService.Notes.Count % 2 != 0)
                    {
                        noteArr = new Note[1];
                        noteArr[0] = noteService.Notes.Last();
                        Notes.Add(noteArr);
                    }

                    if (DeviceInfo.Platform == DevicePlatform.iOS)
                    {
                        OnPropertyChanged(nameof(Notes));
                        var last = Notes.ElementAt(Notes.Count - 1);
                        Notes.RemoveAt(Notes.Count - 1);
                        OnPropertyChanged(nameof(Notes));
                        Notes.Add(last);
                        OnPropertyChanged(nameof(Notes));
                        Notes = Notes;
                    }
                    //if columns of note will be odd after addition
                    /*if (noteService.Notes.Count % 2 != 0)
                    {
                        noteArr = new Note[1];
                        noteArr[0] = noteParam;
                        Notes.Add(noteArr);
                    }
                    else
                    {
                        //get lastnote
                        noteArr = new Note[2];
                        noteArr[0] = Notes.Last()[0];
                        noteArr[1] = noteParam;
                        OnPropertyChanged(nameof(Notes));
                        Notes.RemoveAt(Notes.Count - 1);
                        OnPropertyChanged(nameof(Notes));
                        Notes.Add(noteArr);
                    }*/
                }
                
            }

            parameters.TryGetValue<Note>("UpdateNote", out noteParam);
            if (noteParam != null && noteService.UpdateNote(SelectedNote,noteParam) != null)
            {
                Notes = new ObservableCollection<Note[]>();

                int col = 0;
                noteArr = new Note[2];
                foreach (var note in noteService.Notes)
                {
                    noteArr[col] = note;
                    if (col == 1)
                    {
                        col = 0;
                        Notes.Add(noteArr);
                        OnPropertyChanged(nameof(Notes));
                        noteArr = new Note[2];
                        continue;
                    }
                    col++;
                }

                if (noteService.Notes.Count % 2 != 0)
                {
                    noteArr = new Note[1];
                    noteArr[0] = noteService.Notes.Last();
                    Notes.Add(noteArr);
                }
                /*int index = noteService.Notes.IndexOf(noteParam);
                var viewNoteIndex = index == 0 ? 0 : (index / 2);
                noteArr = Notes.ElementAt(viewNoteIndex);
                Notes.Remove(noteArr);

                noteArr[index % 2 == 0 ? 0 : 1] = noteParam;
                Notes.Insert(viewNoteIndex, noteArr);*/
            }


            parameters.TryGetValue<Note>("DeleteNote", out noteParam);
            //Select action sent
            if (noteParam != null && noteService.RemoveNote(noteParam.Title))
            {
                Notes = new ObservableCollection<Note[]>();

                int col = 0;
                noteArr = new Note[2];
                foreach (var note in noteService.Notes)
                {
                    noteArr[col] = note;
                    if (col == 1)
                    {
                        col = 0;
                        Notes.Add(noteArr);
                        OnPropertyChanged(nameof(Notes));
                        noteArr = new Note[2];
                        continue;
                    }
                    col++;
                }

                if (noteService.Notes.Count % 2 != 0)
                {
                    noteArr = new Note[1];
                    noteArr[0] = noteService.Notes.Last();
                    Notes.Add(noteArr);
                    OnPropertyChanged(nameof(Notes));
                }
                if (DeviceInfo.Platform == DevicePlatform.iOS)
                {
                    OnPropertyChanged(nameof(Notes));
                    var last = Notes.ElementAt(Notes.Count - 1);
                    Notes.RemoveAt(Notes.Count - 1);
                    OnPropertyChanged(nameof(Notes));
                    Notes.Add(last);
                    OnPropertyChanged(nameof(Notes));
                }
                //Note was successfully remove in the db, now update view
                /*var rangeStartIndex = (SelectedNoteViewRow * 2 + SelectedNoteViewCol);// use zeroth index, determine the 
                var listRange = noteService.Notes.GetRange(rangeStartIndex, noteService.Notes.Count - rangeStartIndex);

                if (SelectedNoteViewCol == 1)
                {
                    listRange.Insert(0, Notes[SelectedNoteViewRow][0]);
                }


                int stopAt = Notes.Count;
                if (SelectedNoteViewRow == 0)
                {
                    Notes = new ObservableCollection<Note[]>();
                }
                else
                {
                    for (int i = SelectedNoteViewRow; i < stopAt; i++)
                    {
                        Notes.RemoveAt(Notes.Count-1);
                    }
                }


                int col = 0;
                noteArr = new Note[2];
                foreach (var note in listRange)
                {
                    noteArr[col] = note;
                    if (col == 1)
                    {
                        col = 0;
                        Notes.Add(noteArr);
                        noteArr = new Note[2];
                        continue;
                    }
                    col++;
                }

                if (listRange.Count % 2 != 0    )
                {
                    noteArr = new Note[1];
                    noteArr[0] = listRange.Last();
                    Notes.Add(noteArr);
                }*/
            }

            if (SelectedNote !=  null)
            {
                

                
                SelectedNote = null;
            }
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                OnPropertyChanged(nameof(Notes));
                var last = Notes.ElementAt(Notes.Count - 1);
                Notes.RemoveAt(Notes.Count - 1);
                OnPropertyChanged(nameof(Notes));
                Notes.Add(last);
                OnPropertyChanged(nameof(Notes));
            }

        }

    }
}

