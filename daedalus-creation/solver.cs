using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    abstract class solver
    {
        public Grid grid;
        public Vector2 starting_point;
        public Vector2 end_point;

        public solver(Grid Grid, Vector2 Starting_point, Vector2 End_point)
        {
            grid = Grid;
            starting_point = Starting_point;
            end_point = End_point;
        }

        public virtual List<Node> solve()
        {
            return null;
        }


    }
}
