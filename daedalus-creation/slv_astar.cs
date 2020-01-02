using System;
using System.Collections.Generic;
using System.Drawing;
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
            grid.set_specific(new slv_astar_specific());

        }


        // The set of discovered nodes that may need to be (re-)expanded.
        // Initially, only the start node is known.
        List<Node> openSet = new List<Node>();


        public override bool step()
        {
            openSet.Add(Start);

            // For node n, gScore[n] is the cost of the cheapest path from start to n currently known.
            Start.specific.g_cost = 0;

            // For node n, fScore[n] := gScore[n] + h(n).
            Start.specific.set_f_cost();

            while (openSet.Count > 0)
            {
                Node current = get_lowest();
                renderer.draw_node(current, Color.FromArgb(current.specific.f_cost%255, current.specific.f_cost % 255, current.specific.f_cost % 255));
                if (current == Destination)
                {
                    return false;
                }

                openSet.Remove(current);
                List<Node> neighbours = grid.get_surroundings(current, true, true, true);
                if (neighbours != null)
                {
                    foreach (Node neighbour in neighbours)
                    {
                        neighbour.visited = true;
                        // d(current,newCostToNeighbour) is the weight of the edge from current to newCostToNeighbour
                        // tentative_gScore is the distance from start to the newCostToNeighbour through current
                        int newCostToNeighbour = current.specific.g_cost + distance(current, neighbour);
                        if (newCostToNeighbour < neighbour.specific.g_cost || !openSet.Contains(neighbour))
                        {
                            // This path to newCostToNeighbour is better than any previous one. Record it!
                            neighbour.parent = current;
                            neighbour.specific.g_cost = newCostToNeighbour;
                            neighbour.specific.h_cost = distance(neighbour, Destination);
                            neighbour.specific.set_f_cost();
                            if (!openSet.Contains(neighbour))
                            {
                                openSet.Add(neighbour);
                            }
                        }
                    }
                }
            }
            // Open set is empty but goal was never reached
            return false;

        }

        public override List<Node> get_path()
        {
            Node c_node = Destination;
            List<Node> result = new List<Node>();
            while (c_node != Start)
            {
                result.Add(c_node);
                c_node = c_node.parent;
            }
            result.Add(c_node);
            return result;
        }

        private Node get_lowest()
        {
            Console.WriteLine("Trying to switch");
            Node n = openSet[0];
            Console.WriteLine("F_cost to beat: " + n.specific.f_cost);
            foreach (Node n_ in openSet)
            {
                Console.WriteLine("Alternative: " + n_.specific.f_cost);
                if (n_.specific.f_cost > n.specific.f_cost)
                {
                    Console.WriteLine("Swtichign");
                    n = n_;
                }
            }
            return n;
        }

        private int distance(Node n1, Node n2)
        {
            int x = Math.Abs(n1.coordinates.x - n2.coordinates.x);
            int y = Math.Abs(n1.coordinates.y - n2.coordinates.y);
            return (int) (Math.Pow(x, 2) + Math.Pow(y, 2));
            return (int)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }


    }

    class slv_astar_specific
    {
        public int f_cost = 0;
        public int g_cost = 0;
        public int h_cost = 0;

        public bool set_f_cost()
        {
            f_cost = h_cost;// + g_cost;
            return true;
        }

        public override string ToString()
        {
            return f_cost + "; " + g_cost + "; " + h_cost;
        }
    }

}
