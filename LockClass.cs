using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brownyy
{
    public class LockClass
    {
        /// <summary>
        /// Позиция x
        /// </summary>    
        public int Position_x { get; set; }
        /// <summary>
        /// Позиция y
        /// </summary>
        public int Position_y { get; set; }
        public int Counter { get; set; }
        public LockClass() { }
        public LockClass(int _x, int _y, int a)
        {
            Position_x = _x;
            Position_y = _y;
            Counter = a;
        }
    }
}
