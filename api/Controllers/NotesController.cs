using core.Entities;
using core.Interfaces;
using infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController(INoteRepository noteRepository) : ControllerBase
    {
        [HttpPost]
        public IActionResult AddNote(Note note)
        {
            noteRepository.CreateNote(note);
            return Ok(note);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Note>>> GetAllNotes()
        {
            var notes = await noteRepository.GetAllNotesAsync();  // Await the async method
            return Ok(notes);  // Return the result
        }
        [HttpGet("{id:int}")]
        public async Task<Note?> GetNoteById(int id)
        {
            var note = await noteRepository.GetNoteByIdAsync(id);

            if(note == null) return null;

            return note;
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNoteById(Note noteForUpdate, int id)
        {
            if (id != noteForUpdate.Id) return BadRequest();

            var note = await noteRepository.GetNoteByIdAsync(id);

            if (note == null) return BadRequest();

            note.Title = noteForUpdate.Title;
            note.Content = noteForUpdate.Content;
            note.Time = noteForUpdate.Time;

            noteRepository.UpdateNote(note);
            return Ok(note);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNoteById(int id)
        {
            if(id ==null) return BadRequest();

            var note=await noteRepository.GetNoteByIdAsync(id);

            if (note == null) return BadRequest();
            
            noteRepository.DeleteNote(note);
            
            return Ok(note);
        }

    }
}
