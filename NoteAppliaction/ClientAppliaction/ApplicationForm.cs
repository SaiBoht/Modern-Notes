using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAppliaction
{
    public partial class ApplicationForm : Form
    {
        public IRepository repository;

        //Variables
        public Note note;
        public List<Note> notes;

        //for testing purposes only
        public bool mbOption = true;
        public bool mbShown = false;



        public ApplicationForm()
        {
            InitializeComponent();
            //Initializes note and notes variables to be used in the client
            note = new Note();
            notes = new List<Note>();

            //initializes httpClient
            repository = new Repository();

            //Updates the list at the start 
            //of the client to show an up to date list
            UpdateList();
        }
        public ApplicationForm(IRepository repo)
        {
            InitializeComponent();
            //Initializes note and notes variables to be used in the client
            note = new Note();
            notes = new List<Note>();

            //initializes httpClient
            repository = repo;

            //Updates the list at the start 
            //of the client to show an up to date list
            //UpdateList();
        }

        /// <summary>
        /// Saves current note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_click(object sender, EventArgs e)
        {
            Note_SaveAsync(note.Id, txt_noteName.Text, txt_noteContent.Text);
        }

        /// <summary>
        /// Deletes current selected note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Note_deleteAsync(note.Id);
        }

        /// <summary>
        /// Clears text fields and note data for a new note to be made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_New_Click(object sender, EventArgs e)
        {
            txt_noteName.Text = "";
            txt_noteContent.Text = "";
            note = new Note();
        }
        /// <summary>
        /// Updates the list of notes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateList_ClickAsync(object sender, EventArgs e)
        {
            UpdateList();
        }


        /// <summary>
        /// Updates view on item selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_notes_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //tries to get selected item
                int i = listView_notes.SelectedIndices[0];

                //updates current active note
                note.Id = Convert.ToInt32(listView_notes.Items[i].SubItems[1].Text);
                note.Name = listView_notes.Items[i].SubItems[0].Text;
                note.Text = listView_notes.Items[i].SubItems[2].Text;

                //updates client view
                txt_noteName.Text = note.Name;
                txt_noteContent.Text = note.Text;
            }
            catch
            {
             

            }
        }
        /// <summary>
        /// Updates the list of notes in the application, updated after changes.
        /// </summary>
        public async void UpdateList()
        {
            listView_notes.Clear();
            notes = await GetNotesAsync();
            if (notes.Count != 0)
            {
                foreach (Note n in notes)
                {
                    String[] row = { n.Name, n.Id.ToString(), n.Text };
                    listView_notes.Items.Add(new ListViewItem(row));
                }
            }
            
        }



        public async Task Note_SaveAsync(int id, string name, string text)
        {
            bool result;
         

            //checks if new note
            if (id == -1)
            {
                //apiCall save new
                result = await repository.SaveNewNote(name, text);
                if (!result)
                {
                    //show error in message
                    MessageBoxHelper(mbOption, "Failed to save new note");
                }
            }
            else
            {
                //apiCall save edit
                result = await repository.SaveNote(id,name,text);
                if (!result)
                {
                    //show error message
                    MessageBoxHelper(mbOption, "Failed to save edit to note");
                }
            }

            //updates current note data
            note.Name = name;
            note.Text = text;
            //updates list to show reflect changes made
            UpdateList();
        }
        public async Task Note_deleteAsync(int id)
        {
            if (id != -1)
            {

                //apiCall delete note on Id
                bool response = await repository.DeleteNote(id);
                if (response)
                {
                    //updates list to show reflect changes made
                    UpdateList();

                    //clears temp & view data
                    note = new Note();
                    txt_noteContent.Text = "";
                    txt_noteName.Text = "";
                }
                else
                {
                    //Show error box
                    MessageBoxHelper(mbOption, "Failed to delete note");
                }
            }
        }
        
        public async Task<List<Note>> GetNotesAsync()
        {
            List<Note> noteList=new List<Note>();
            //apiCall getNotes from sever
            noteList = await repository.GetNotes();
            notes = noteList;

            return notes;
        }

        public void MessageBoxHelper(bool option, string message)
        {
            if (option)
            {
                MessageBox.Show(message);
            }
            //for testing purposes only
            mbShown = true;
        }

    }
}
