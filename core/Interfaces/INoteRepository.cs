using core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface INoteRepository
    {
        Task<IReadOnlyList<Note>> GetAllNotesAsync();
        Task<Note?> GetNoteByIdAsync(int id);

        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
}
