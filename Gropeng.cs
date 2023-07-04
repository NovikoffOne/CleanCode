using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class Gropeng
    {

    }

    class Player
    {
        public Weapon Weapon = new Weapon();
        public Movement Movement = new Movement();

        public string Name { get; private set; }
        public int Age { get; private set; }
        
        public void Move()
        {
            //Do move
        }

        public void Attack()
        {
            //attack
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }

    class Weapon
    {
        public int WeaponDamage { get; private set; }
        public float WeaponCooldown { get; private set; }
    }

    class Movement
    {
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }
    }
}
