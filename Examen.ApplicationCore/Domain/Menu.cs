using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Menu
    {
       
        public int Id { get; set; }

        public DateTime DateMenu { get; set; }
   
        public virtual List<Plat> Plats { get; set; }

    }
}
