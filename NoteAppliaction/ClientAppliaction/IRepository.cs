using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppliaction
{
    public interface IRepository
    {
        Task<Boolean> SaveNote(int id, string name, string text);

        Task<Boolean> SaveNewNote(string name, string text);

        Task<Boolean> DeleteNote(int id);

        Task<List<Note>> GetNotes();
    }
}
