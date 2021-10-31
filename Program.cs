using System;

namespace GameOfLife
{
    class GameOfLife
    {
        const int MARS_WIDTH = 25;
        const int MARS_HEIGHT = 25;

        /* Given some coordinate x and y, check the 8 neighboring spaces and return number of alive neighbors */
        int findNumNeighbors(bool[,] state, int x, int y)
        {
            // Remember to protect against out of bounds errors
            return -1;
        }

        /* Given a current state, return a new 2D boolean array which represents the next state */
        bool[,] getNextState(bool[,] currState)
        {
            bool[,] nextState = new bool[MARS_WIDTH, MARS_HEIGHT];

            return nextState;
        }

        static void Main(string[] args)
        {
            string INIT_MARS = "glider";

            bool[,] Mars = new bool[MARS_WIDTH, MARS_HEIGHT];
            bool e = Mars[2, 3];
        }
    }
}
