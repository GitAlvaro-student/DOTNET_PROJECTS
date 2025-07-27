using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.cs.Modelos
{
    internal class Dono
    {
        public Dono(string name, Pet animal)
        {
            Name = name;
            Animal = animal;
        }

        public string Name { get; set; }
        public Pet Animal { get; set; }
    }
}
