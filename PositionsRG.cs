using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brownyy
{
    public class PositionsRG
    {
        /// <summary>
        /// Позиция x Red
        /// </summary>    
        public int Position_xR { get; set; }
        /// <summary>
        /// Позиция y Red
        /// </summary>
        public int Position_yR { get; set; }
        /// <summary>
        /// Позиция x Green
        /// </summary>    
        public int Position_xG { get; set; }
        /// <summary>
        /// Позиция y Green
        /// </summary>
        public int Position_yG { get; set; }
        public int Counter { get; set; }
        public bool Win { get; set; }
        public PositionsRG() { }
        public PositionsRG(int _xR, int _yR, int _xG, int _yG, int counter, bool win)
        {
            Position_xR = _xR;
            Position_yR = _yR;
            Position_xG = _xG;
            Position_yG = _yG;
            Counter = counter;
            Win = win;
        }
      
    }
}
