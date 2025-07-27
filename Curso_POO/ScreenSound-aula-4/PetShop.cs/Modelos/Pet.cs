using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.cs.Modelos
{
    internal class Pet
    {
        public Pet(string name, string raca, Dono dono)
        {
            Name = name;
            Raca = raca;
            Dono = dono;
        }

        public string Name { get; set; }
        public string Raca { get; set; }
        public Dono Dono { get; set; }
    }
}
