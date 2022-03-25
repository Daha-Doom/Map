using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    internal class Points
    {
        private string name;
        private int quantity;
        private double x, y;

        public Points(string _name, int _quantity, double _x, double _y)
        {
            this.name = _name;
            this.quantity = _quantity;
            this.x = _x;
            this.y = _y;
        }
    }
}
