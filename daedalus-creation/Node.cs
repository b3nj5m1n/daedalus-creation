using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class Node
    {
        // Stores the coordinates in the grid
        public Vector2 coordinates;
        // Parent nodes are used in certain algorithms
        public Node parent;
        // Has the node been visited or not, used in certain algorithms
        public bool visited;
        // Is the node special, will cause it to be drawn in a different color
        public bool special;
        // Walls sourrounding the node
        public Walls walls;
        // Potential information that is neccessary for certain algorithms
        public dynamic specific;

        public Node(Vector2 Coordinates)
        {
            coordinates = Coordinates;
            parent = null;
            visited = false;
            special = false;
            walls = new Walls();
            specific = null;
        }
    }
}
