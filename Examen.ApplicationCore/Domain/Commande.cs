using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Commande
    {

        public string NumCmd { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCmd { get; set; }
        public bool livree { get; set; }

        public virtual Livreur livreur { get; set; }

        public virtual IList<LigneCommande> LigneCommandes { get; set; }
    }
}
