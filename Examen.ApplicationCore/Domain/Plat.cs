using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Plat
    {
        [Required(ErrorMessage = "Le nom du plat est obligatoire.")]
        public string Nom { get; set; }
        public int IdPlat { get; set; }
        
        public string TypePlat { get; set; }

        public string Photo { get; set; }

        [Required(ErrorMessage = "Le prix du plat est obligatoire.")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être un nombre positif.")]
        public double Prix { get; set; }

        public virtual List<Menu> menus { get; set; }

        public virtual List<LigneCommande> LigneCommandes { get; set; }

        public int Id { get; set; }

    }
}
