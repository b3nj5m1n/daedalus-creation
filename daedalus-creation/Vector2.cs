﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class Vector2
    {
        public int x;
        public int y;

        public Vector2(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public override string ToString()
        {
            return "(" + x + "|" + y + ")";
        }
    }
}
