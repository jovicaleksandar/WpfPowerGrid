using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Point
    {
        string x;
        string y;

        public Point(string x, string y)
        {
            this.x = x;
            this.y = y;
        }
        public Point() { }

        public string X { get => x; set => x = value; }
        public string Y { get => y; set => y = value; }
    }
}
