using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Animal
    {
        public string gender;
        public bool is_swim;
        public bool is_predator;
        public bool is_herbivore;
        public bool is_eaten;
        public bool is_only_water;
        public byte[] coordinates = new byte[2];
    }

    class Rabbit: Animal
    {
        public string name;
        public char point;
    }
}
