using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{

    public class ServiceCommande : Service<Commande>, IServiceCommande
    {
        public ServiceCommande(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double GetPrixCommandes(Commande cmd)
        {
            double price = 0;

            foreach (var ligneCommande in cmd.LigneCommandes)
            {
                price += ligneCommande.Plat.Prix * ligneCommande.Quantite;
            }

            return price;
        }
    }
}
