using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data
{
    public class NoteRepository(DataContext context) : INoteRepository
    {
        public void CreateNote(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
        }

        public void DeleteNote(Note note)
        {
            context.Notes.Remove(note);
            context.SaveChanges();
        }

        public async Task<IReadOnlyList<Note>> GetAllNotesAsync()
        {
            var notes=await context.Notes.ToListAsync();
            return notes;

        }

        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            var note=await context.Notes.FindAsync(id);
            return note;
        }

        public void UpdateNote(Note note)
        {
            context.Notes.Update(note);
            context.SaveChanges();
        }
    }
}
