using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceLivreur : Service<Livreur>, IServiceLivreur
    {
        public ServiceLivreur(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double CalculBenefice(Livreur liv, DateTime date)
        {
            double benefice = 0;
            foreach (var item in liv.Commandes)
            {
                if (item.DateCmd == date)
                {
                    benefice += item.LigneCommandes.Sum(l => l.Plat.Prix * l.Quantite) * 0.05;
                }
            }
            return benefice;
        }

        public IList<Livreur> GetLivreursDisponibles()
        {
            return GetAll().Where(l => l.Status == Status.Libre).ToList();
        }
    }
}
