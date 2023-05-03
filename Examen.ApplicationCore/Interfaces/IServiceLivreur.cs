using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceLivreur : IService<Livreur>
    {
        IList<Livreur> GetLivreursDisponibles();
        public double CalculBenefice(Livreur liv, DateTime date);
    }
}
