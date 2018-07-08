using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestfulAPI.DAL
{
    public class DBRepository: IDBRepository
    {
        private RestfulAPIContext db;
        public DBRepository(RestfulAPIContext context)
        {
            db = context;
        }
        public  DBRepository()
        {
            db = new RestfulAPIContext();
        }

        public async Task saveNote(Note note)
        {
            db.Notes.Add(note);
            await db.SaveChangesAsync();
        }

        public async Task editNote(Note note)
        {

            Note temp = await db.Notes.FindAsync(note.Id);
            temp.Name = note.Name;
            temp.Text = note.Text;
            db.Entry(temp).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteNote(Note note)
        {

            db.Notes.Remove(note);
            await db.SaveChangesAsync();
        }

        public async Task<List<Note>> GetNotes()
        {
            return await db.Notes.ToListAsync();
        }

        public async Task<Note> GetNote(int id)
        {
            return await db.Notes.FindAsync(id);
        }
    }
}