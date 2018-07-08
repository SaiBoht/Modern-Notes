using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClientAppliaction
{
    public class Repository : IRepository
    {
        static HttpClient client = new HttpClient();

        public Repository()
        {
            //sets up basics needed to communicate with the API
            client.BaseAddress = new Uri("http://localhost:58213");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// Does api call to save a note
        /// Throws exeption on fail
        /// </summary>
        /// <param name="note"></param>
        public async Task<Boolean> SaveNote(int id, string name, string text)
        {
            Note note = new Note { Id = id, Name = name, Text = text };
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Notes/" + note.Id, note);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else throw new Exception();
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Does api call to save a new note
        /// Throws exeption on fail 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public async Task<Boolean> SaveNewNote(string name, string text)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Notes", new Note { Name = name, Text = text });
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else throw new Exception();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Does API call to delete a note
        /// Returns true if deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Boolean> DeleteNote(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/notes/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else throw new Exception();
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// API call to retrive all notes 
        /// if error in call returns an empty list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetNotes()
        {
            List<Note> noteList = new List<Note>();
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Notes");
                if (response.IsSuccessStatusCode)
                {
                    noteList = await response.Content.ReadAsAsync<List<Note>>();
                    return noteList;
                }
                else throw new Exception();
            }
            catch
            {
                return noteList;
            }
        }
    }
}
