using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photos_Apsnet.Models
{
    public class PhotoDto2
    {
        public int Id { get; set; }
       
        public string Titlu { get; set; }
       
        public string Descriere { get; set; }
      
        public string Eveniment { get; set; }
 
        public System.DateTime Data { get; set; }
      
        public string[] Other { get; set; }
    
        public string Path { get; set; }
      
        public int LocationId { get; set; }

      
        public virtual ICollection<PersonDto2> People { get; set; }
  
        public virtual LocationDto2 Location { get; set; }
    }
}
