using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class Triangle
    {
        public static bool IsTriangle(double side_a, double side_b, double side_c)
        {
            return (side_a > 0 && side_b > 0 && side_c > 0 && (side_a + side_b >= side_c) && (side_a + side_c >= side_b) && (side_b + side_c >= side_a));
        }
    }
}

