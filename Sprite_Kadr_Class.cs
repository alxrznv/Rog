using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brownyy
{
        public class KadrClass
        {
            /// <summary>
            /// Позиция x
            /// </summary>
            public int Position_x { get; set; }
            /// <summary>
            /// Позиция y
            /// </summary>
            public int Position_y { get; set; }
            /// <summary>
            /// Номер кадра
            /// </summary>
            public int NumberAnimation { get; set; }
            public string Kadr { get; set; }
            public KadrClass() { }
            public KadrClass(int _x, int _y, string kadr)
            {
                Position_x = _x;
                Position_y = _y;
                Kadr = kadr;
            }
        }
}
