using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class slv_astar : solver
    {
        /// <summary>
        /// Initalize object
        /// </summary>
        /// <param name="Grid">Grid instance</param>
        /// <param name="Config">0 = Always chooose the newest node (Mimics recurive backtracker), 1 = Choose at random (Mimic Prim's algorithm)</param>
        /// <param name="starting_point">Node to start from</param>
        public slv_astar(Grid Grid, Vector2 starting_point, Vector2 end_point) : base(Grid, starting_point, end_point)
        {
        }


        public override List<Node> solve()
        {
            // Open, list containing all the nodes that haven't been evaluated yet
            List<Node> set_o = new List<Node>();
            // Closed, list containing all the Nodes that have already been evaluated
            List<Node> set_c = new List<Node>();

            // Add the starting Node to the set
            Node start = grid.node_by_vector(starting_point);
            Node destination = grid.node_by_vector(end_point);
            set_o.Add(start);

            grid.set_specific(new slv_astar_specific());

            // Main loop, runs until the open list is empty and hence the maze is unsolvable
            while (set_o.Count > 0)
            {
                // Set current node to the node with the lowest f cost from the open set
                Node current = set_o[0];
                // Loop over every node in the open set
                foreach (Node n in set_o)
                {
                    // If the nodes f cost is lower than the one of the current node
                    if (n.specific.f_cost < current.specific.f_cost)
                    {
                        // Set current node to the node with a lower f cost
                        current = n;
                    }
                }
                // Remove current node from open set and add it to the closed set since it's being evaluated
                set_o.Remove(current);
                set_c.Add(current);
                // A path has been found, exit the loop
                if (current == destination)
                {
                    // Retrace the path from current node (Destination) to the starting node
                    return retrace_path_astar(destination, start);
                }
                // Get all the neighbours of the current node that can be accessed from the current node
                foreach (Node neighbour in grid.get_surroundings(current, true, false, true))
                {
                    int newCostToNeighbour = current.specific.g_cost + GetDistance(current, neighbour);
                    // Only continue if the node hasn't already been visited
                    if (!set_c.Contains(neighbour))
                    {
                        // Calculate h, g & f cost for the neighbour
                        neighbour.specific.g_cost = newCostToNeighbour;
                        neighbour.specific.h_cost = GetDistance(neighbour, destination);
                        neighbour.specific.f_cost = neighbour.specific.g_cost + neighbour.specific.h_cost;
                        // Set the parent of the neighbour to the current node
                        neighbour.parent = current;
                        // Add the neighbour to the open set if it isn't already in it
                        if (!set_o.Contains(neighbour))
                        {
                            set_o.Add(neighbour);
                        }
                    }
                }
            }

            // There is no solution
            return null;
        }

        private int GetDistance(Node current, Node neighbour)
        {
            int dstX = Math.Abs(current.coordinates.x - neighbour.coordinates.x);
            int dstY = Math.Abs(current.coordinates.y - neighbour.coordinates.y);

            return (dstX + dstY) / 2;
        }

        private List<Node> retrace_path_astar(Node n1, Node n2)
        {
            List<Node> path = new List<Node>();
            // Add the destination node to the list
            path.Add(n1);
            // Loop runs until the last element in the list is the starting node
            while (path[path.Count - 1].parent != null)
            {
                // Get the parent node of the current node
                Node parent = path[path.Count - 1].parent;
                // Add that node to the path
                path.Add(parent);
            }
            return path;
        }
    }
    
    class slv_astar_specific
    {
        public int f_cost = 0;
        public int g_cost = 0;
        public int h_cost = 0;
    }

}
