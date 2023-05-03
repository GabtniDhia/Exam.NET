using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class LigneCommande
    {
        public int Quantite { get; set; }

        public string CommandeFk { get; set; }
        public int PlatFk { get; set; }

        [ForeignKey("CommandeFk")]
        public virtual Commande Commande { get; set; }
        public virtual Plat Plat { get; set; }
    }
}
