using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestfulAPI.DAL;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    public class NotesController : ApiController
    {
        IDBRepository _repository;

        public NotesController(IDBRepository repo)
        {
            _repository = repo;
        }
        public NotesController()
        {
            _repository = new DBRepository();
        }

        // GET: api/Notes
        public async Task<List<Note>> GetNotesAsync()
        {

            return await _repository.GetNotes();
        }

        // GET: api/Notes/5
        [ResponseType(typeof(Note))]
        public async Task<IHttpActionResult> GetNote(int id)
        {
            Note note = await _repository.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // PUT: api/Notes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNote(int id, Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != note.Id)
            {
                return BadRequest();
            }
            if (!await NoteExistsAsync(id))
            {
                return NotFound();
            }
            
            try
            {
                await _repository.editNote(note);
                return StatusCode(HttpStatusCode.OK);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        // POST: api/Notes
        [ResponseType(typeof(Note))]
        public async Task<IHttpActionResult> PostNote(Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repository.saveNote(note);
                return CreatedAtRoute("DefaultApi", new { id = note.Id }, note);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Notes/5
        [ResponseType(typeof(Note))]
        public async Task<IHttpActionResult> DeleteNote(int id)
        {
            if (!await NoteExistsAsync(id))
            {
                return NotFound();
            }

            Note note = await _repository.GetNote(id);
            await _repository.DeleteNote(note);

            return Ok(note);
        }

       

        private async Task<bool> NoteExistsAsync(int id)
        {
            if (await _repository.GetNote(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}