using System;

namespace Rog{

    public class Potion{
        public int Points {get; set;}
        public int Cost {get; set;}
        public int Duration {get; set;}
        public Potion(){
            Points = 20;
            Cost = 20;
        }
    }
}