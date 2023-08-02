namespace test.Services
{
    public interface INoteService
    {
        List<Note> Notes { get; }

        bool AddNote(Note note);
        IEnumerable<Note> GetNotes();
        bool RemoveNote(string title);
        Note UpdateNote(Note old, Note note);
        bool NoteExists(Note note);
    }
}