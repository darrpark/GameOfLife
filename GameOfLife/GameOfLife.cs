using System;

namespace GameOfLife
{
    class GameOfLife
    {
        /* Minimum rows/cols is 5 */
        const int MARS_ROWS = 8;
        const int MARS_COLS = MARS_ROWS;
        const int BLOCK_SIZE = 2;
        const int MAX_TIME = 40;
        const string ALIVE = "@";
        const string DEAD = ".";

        /* int findNumNeighbors:
         * Given some coordinate x and y, checks its 8 neighboring spaces
         * and returns the number of alive neighbors (used in nextState)
         *  1) Each cell has eight neighboring spaces; iterate over them using x+- and y+-
         */
        static int findNumNeighbors(bool[,] state, int r, int c)
        {
            // Remember to protect against out of bounds errors

            int numNeighbors = 0;

            for (int rowAdj = r - 1; rowAdj <= r + 1; rowAdj++)
            {
                for (int colAdj = c - 1; colAdj <= c + 1; colAdj++)
                {
                    if (!(r == rowAdj && c == colAdj) && state[(rowAdj + MARS_ROWS) % MARS_COLS, (colAdj + MARS_ROWS) % MARS_COLS])
                    {
                        numNeighbors++;
                    }
                }
            }
            return numNeighbors;
        }

        /* bool[,] getNextState:
         * Given a current state, returns a new 2D boolean array
         * which represents the next state:
         *  1) Initialize next state array
         *  2a) Iterate through currState, and evaluate each cell as alive or dead
         *  2b) Update the cell's next state in nextState
         *  3) Return the fully evaluated nextState (don't make changes directly to currState)
         */
        static bool[,] getNextState(bool[,] currState)
        {
            bool[,] nextState = new bool[MARS_ROWS, MARS_COLS];

            // REPLACE THIS
            for (int i = 0; i < MARS_ROWS; i++)
            {
                for (int j = 0; j < MARS_COLS; j++)
                {
                    int numNeighbors = findNumNeighbors(currState, i, j);
                    if (currState[i, j] == true)
                    {
                        if (numNeighbors == 0 || numNeighbors == 1)
                            nextState[i, j] = false;
                        if (numNeighbors >= 4)
                            nextState[i, j] = false;
                        if (numNeighbors == 2 || numNeighbors == 3)
                            nextState[i, j] = true;
                    }
                    else
                    {
                        if (numNeighbors == 3)
                            nextState[i, j] = true;
                    }
                }
            }

            return nextState;
        }

        /* void displayState:
         * Takes the current state, and outputs it to the console based on the parameters set above.
         */
        static void displayState(bool[,] state)
        {
            Console.Clear();
            for (int r = 0; r < MARS_ROWS; r++)
            {
                for (int i = 0; i < BLOCK_SIZE; i++)
                {
                    for (int c = 0; c < MARS_COLS; c++)
                    {
                        for (int j = 0; j < BLOCK_SIZE; j++)
                        {
                            Console.Write(" "); // Cell density
                            Console.Write(state[r, c] ? ALIVE : DEAD);
                        }
                        Console.Write("  "); // Spacing between cells
                    }
                    Console.WriteLine(); // Taller cells
                }
                Console.WriteLine(); // Next row
            }
        }
        
        static void Main(string[] args)
        {
            /* User state selection */
            int INIT_STATE;
            while (true)
            {
                Console.Write("Which case would you like to view?\n");
                Console.Write("1) Still\n2) Oscillator\n3) Glider\n\n");
                Console.Write("Your Choice: ");
                INIT_STATE = Convert.ToInt32(Console.ReadLine());

                if (INIT_STATE <= 0 || INIT_STATE > 3)
                {
                    Console.WriteLine("\nTry again bozo.\n");
                } else
                {
                    break;
                }
            }

            /* Choosing initial state */
            bool[,] Mars = new bool[MARS_ROWS, MARS_COLS];
            switch (INIT_STATE)
            {
                case 1:
                    Mars[1, 1] = Mars[1, 2] = Mars[2, 1] = Mars[2, 2] = true;
                    break;
                case 2:
                    Mars[2, 1] = Mars[2, 2] = Mars[2, 3] = true;
                    break;
                case 3:
                    Mars[3, 1] = Mars[3, 2] = Mars[3, 3] = Mars[1, 2] = Mars[2, 3] = true;
                    break;
                default:
                    break;
            }

            /* Display animation */
            for (int i = 0; i < MAX_TIME; i++)
            {
                displayState(Mars);
                Mars = getNextState(Mars);
                System.Threading.Thread.Sleep(250);
            }
        }
    }
}
