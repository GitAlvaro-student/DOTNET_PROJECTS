using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.cs.Modelos
{
    internal class Consulta
    {
        public Consulta(Pet animal, Medico medico, Dono dono)
        {
            Animal = animal;
            Medico = medico;
            Dono = dono;
        }

        public Pet Animal { get; set; }
        public Medico Medico { get; set; }
        public Dono Dono { get; set; }
    }
}
