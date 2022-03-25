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
        private int quantity, id;
        private double x, y;

        public Points(int _id, string _name, int _quantity, double _x, double _y)
        {
            this.id = _id;
            this.name = _name;
            this.quantity = _quantity;
            this.x = _x;
            this.y = _y;
        }

        public int GetID()
        { 
            return id; 
        }

        public string GetName()
        {
            return name;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }
    }
}
