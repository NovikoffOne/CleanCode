using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class Weapon
    {
        private int _bullets;
        private int _bulletPerShot;
        private int _noBullet;

        public bool CanShoot() => _bullets > _noBullet;

        public void Shoot() => _bullets -= _bulletPerShot;
    }
}
