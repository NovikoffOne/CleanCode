using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class Enable
    {
        public void Enable(bool enable)
        {
            if (enable == true)
                _effects.StartEnableAnimation();
            else
                Disable();
        }

        public void Disable()
        {
            _pool.Free(this);
        }
    }
}
