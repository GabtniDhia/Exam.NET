using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Livreur
    {
        public string Nom { get; set; }
        public int IdLivreur { get; set; }

        public Status Status { get; set; }
        
        public virtual List<Commande> Commandes { get; set; }
    }

    public enum Status { 
        Libre, 
        EnRoute 
    }

}
