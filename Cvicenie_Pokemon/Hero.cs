using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_Pokemon
{
    public class Hero
    {
        public int Health { get; set; }    //aktualne hp
        public int Health_Max { get; set; }    //maximalne hp
        public int Damage { get; set; }
        public int Energy_Max { get; set; }
        public int Energy { get; set; }

        public Hero(int health, int health_Max, int damage, int energy_max, int energy)
        {
            Health = health; 
            Health_Max = health_Max;
            Damage = damage;
            Energy_Max = energy_max;
            Energy = energy;
        }
    }
}
