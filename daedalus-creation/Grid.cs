using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daedalus_creation
{
    class Grid
    {
        Node[,] grid;
        public int[] size;

        public Grid(int[] Size)
        {
            size = Size;
            grid = new Node[size[0], size[1]];
        }

        /// <summary>
        /// Initialize the grid / reset it
        /// </summary>
        public void initalize()
        {
            for (int x = 0; x < size[0]; x++)
            {
                for (int y = 0; y < size[1]; y++)
                {
                    grid[x, y] = new Node(new Vector2(x, y));
                }
            }
        }

        /// <summary>
        /// Remove the grid
        /// </summary>
        public void remove()
        {
            grid = new Node[size[0], size[1]];
        }

        /// <summary>
        /// Get the node upwards of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_up(Node node, bool exists, bool unvisited, bool valid)
        {
            Vector2 new_coordinates = new Vector2(node.coordinates.x, node.coordinates.y);
            new_coordinates.y -= 1;
            Node new_node = node_by_vector(new_coordinates);
            // If the existance of the node is required, test if it exists
            if (exists)
            {
                if (new_node == null)
                {
                    return null;
                }
            }
            // If the node has to be unvisited, test if it has been visited (The existance of the node is a requirement for this)
            if (exists && unvisited)
            {
                if (new_node.visited)
                {
                    return null;
                }
            }
            // If a path between the two nodes has to be valid, test if there is a wall between the two (The existance of the node is a requirement for this)
            if (exists && valid)
            {
                if (new_node.walls.south_active)
                {
                    return null;
                }
            }
            return new_node;
        }

        /// <summary>
        /// Get the node downwards of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_down(Node node, bool exists, bool unvisited, bool valid)
        {
            Vector2 new_coordinates = new Vector2(node.coordinates.x, node.coordinates.y);
            new_coordinates.y += 1;
            Node new_node = node_by_vector(new_coordinates);
            // If the existance of the node is required, test if it exists
            if (exists)
            {
                if (new_node == null)
                {
                    return null;
                }
            }
            // If the node has to be unvisited, test if it has been visited (The existance of the node is a requirement for this)
            if (exists && unvisited)
            {
                if (new_node.visited)
                {
                    return null;
                }
            }
            // If a path between the two nodes has to be valid, test if there is a wall between the two (The existance of the node is a requirement for this)
            if (exists && valid)
            {
                if (node.walls.south_active)
                {
                    return null;
                }
            }
            return new_node;
        }

        /// <summary>
        /// Get the node to the right of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_right(Node node, bool exists, bool unvisited, bool valid)
        {
            Vector2 new_coordinates = new Vector2(node.coordinates.x, node.coordinates.y);
            new_coordinates.x += 1;
            Node new_node = node_by_vector(new_coordinates);
            // If the existance of the node is required, test if it exists
            if (exists)
            {
                if (new_node == null)
                {
                    return null;
                }
            }
            // If the node has to be unvisited, test if it has been visited (The existance of the node is a requirement for this)
            if (exists && unvisited)
            {
                if (new_node.visited)
                {
                    return null;
                }
            }
            // If a path between the two nodes has to be valid, test if there is a wall between the two (The existance of the node is a requirement for this)
            if (exists && valid)
            {
                if (node.walls.east_active)
                {
                    return null;
                }
            }
            return new_node;
        }

        /// <summary>
        /// Get the node to the left of the given one
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public Node get_left(Node node, bool exists, bool unvisited, bool valid)
        {
            Vector2 new_coordinates = new Vector2(node.coordinates.x, node.coordinates.y);
            new_coordinates.x -= 1;
            Node new_node = node_by_vector(new_coordinates);
            // If the existance of the node is required, test if it exists
            if (exists)
            {
                if (new_node == null)
                {
                    return null;
                }
            }
            // If the node has to be unvisited, test if it has been visited (The existance of the node is a requirement for this)
            if (exists && unvisited)
            {
                if (new_node.visited)
                {
                    return null;
                }
            }
            // If a path between the two nodes has to be valid, test if there is a wall between the two (The existance of the node is a requirement for this)
            if (exists && valid)
            {
                if (new_node.walls.east_active)
                {
                    return null;
                }
            }
            return new_node;
        }

        /// <summary>
        /// Get all the surrounding nodes
        /// </summary>
        /// <param name="node">Which node to go off</param>
        /// <param name="exists">Only returns the node if it exists</param>
        /// <param name="unvisited">Only returns the node if it hasn't been visited</param>
        /// <param name="valid">Only returns the node if there are no walls in between of the two</param>
        /// <returns></returns>
        public List<Node> get_surroundings(Node node, bool exists, bool unvisited, bool valid)
        {
            return null;
        }

        /// <summary>
        /// Return the node in the grid at the given position, returns null if not existing
        /// </summary>
        /// <param name="coordinates">Coordinates of the node</param>
        /// <returns></returns>
        public Node node_by_vector(Vector2 coordinates)
        {
            if (coordinates.x >= 0 && coordinates.y >= 0 && coordinates.x < size[0] && coordinates.y < size[1])
            {
                return grid[coordinates.x, coordinates.y];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Remove the wall between two nodes
        /// </summary>
        /// <param name="n1">First Node</param>
        /// <param name="n2">Second Node</param>
        public void remove_wall(Node n1, Node n2)
        {
            Console.WriteLine("Removing wall between " + n1.coordinates.ToString() + " and " + n2.coordinates.ToString());
            Node R = get_right(n1, true, false, false);
            Console.WriteLine(R.coordinates.ToString() + "," + n1.coordinates.ToString() + "," + n2.coordinates.ToString());
            // Test if node 2 is to the right of node 1
            if (R.coordinates.x == n2.coordinates.x && R.coordinates.y == n2.coordinates.y)
            {
                Console.WriteLine("...");
                // Disable east wall of node 1 to make a connection between the two
                n1.walls.east_active = false;
            }
            // Test if node 2 is to the left of node 1
            if (get_left(n1, true, false, false) == n2)
            {
                // Disable east wall of node 2 to make a connection between the two
                n2.walls.east_active = false;
            }
            // Test if node 2 is to the top of node 1
            if (get_up(n1, true, false, false) == n2)
            {
                // Disable south wall of node 2 to make a connection between the two
                n2.walls.south_active = false;
            }
            // Test if node 2 is to the bottom of node 1
            if (get_down(n1, true, false, false) == n2)
            {
                // Disable south wall of node 1 to make a connection between the two
                n1.walls.south_active = false;
            }
        }


    }
}
