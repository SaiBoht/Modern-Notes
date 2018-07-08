using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.DAL
{
    public interface IDBRepository
    {
        Task saveNote(Note note);
        Task editNote(Note note);
        Task DeleteNote(Note note);
        Task <List<Note>> GetNotes();
        Task<Note> GetNote(int id);
    }
}
