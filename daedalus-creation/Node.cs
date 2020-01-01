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
        Vector2 coordinates;
        // Parent nodes are used in certain algorithms
        Node parent;
        // Has the node been visited or not, used in certain algorithms
        bool visited;
        // Is the node special, will cause it to be drawn in a different color
        bool special;
        // Walls sourrounding the node
        Walls walls;
        // Potential information that is neccessary for certain algorithms
        dynamic specific;

        Node(Vector2 Coordinates)
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
