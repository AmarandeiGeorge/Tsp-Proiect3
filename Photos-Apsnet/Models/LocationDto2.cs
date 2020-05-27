using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photos_Apsnet.Models
{
    public class LocationDto2
    {
       
    
      
        public int Id { get; set; }
      
        public string Name { get; set; }

        public virtual ICollection<PhotoDto2> Photos { get; set; }
    }
}

