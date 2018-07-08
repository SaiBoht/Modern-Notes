using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppliaction
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
     

        //uses Id equals -1 to indicate a note which is not saved
        public Note()
        {
            Id = -1;
        }
    }
}
