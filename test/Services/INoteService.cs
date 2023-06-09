namespace test.Services
{
    public interface INoteService
    {
        List<Note> Notes { get; }

        bool AddNote(Note note);
        IEnumerable<Note> GetNotes();
        bool RemoveNote(int index);
        Note UpdateNote(Note note);
    }
}