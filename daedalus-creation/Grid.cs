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
            return null;
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
            return null;
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
            return null;
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
            return null;
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

    }
}
