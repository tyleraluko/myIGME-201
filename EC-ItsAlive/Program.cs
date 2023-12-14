using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 * Tyler Aluko
 * IGME.201 - Extra Credit, It's Alive
 * This console application enhances code for Conway's "The Game of Life," so that it includes an "Organism Editor."
 * Allows the user to define initial states of the organism by setting cells to alive and dead states via an interface.
 * Additionally, it allows the loading and saving of initial states from and to user defined files.
 * 
 * Observed Issues:
 * -> Animation does not play properly, instead displaying various broken question marks.
 */
namespace EC_ItsAlive
{


    public enum EAliveState
    {
        alive,
        dead
    }

    // define possible infected states
    public enum EInfectedState
    {
        infected,
        vaccinated,
        organic
    }

    // all neighbors of a cell
    public enum EDirection
    {
        right,
        down,
        left,
        up,
        topleft,
        topright,
        bottomleft,
        bottomright
    }

    // use a "by value" structure type to store the current and next state of each cell
    public struct StructCellState
    {
        // the infected state
        public EInfectedState infectedState;

        // the private alive state in this state structure
        private EAliveState aliveState;

        // a property to apply logic to the infected state based on changing the alive state
        public EAliveState AliveState
        {
            get
            {
                // return the current alive state
                return this.aliveState;
            }

            set
            {
                // update private alive state member
                this.aliveState = value;

                // if the alive state is now dead
                if (this.aliveState == EAliveState.dead)
                {
                    // reset the infected state to organic (its original state)
                    this.infectedState = EInfectedState.organic;
                }
            }
        }
    }

    // the Cell class to hold the state of each cell in our organism
    public class Cell
    {
        // the max # of infected and vaccinated cells we want in our organism
        const int MAX_VIRUSES = 50;
        const int MAX_VACCINES = 50;

        // the number of infected and vaccinated cells in the whole organism
        // static so that these variables are accessible across all Cell objects
        public static int nViruses;
        public static int nVaccines;

        // dynamically calculate how many neighbors each cell has based on the number of directions in EDirection
        public static int MAX_NEIGHBORS = Enum.GetNames(typeof(EDirection)).Length;

        // the array of neighbor cells for this cell
        // create the neighbor array for this cell
        // this needs to be done in the constructor because MAX_NEIGHBORS is calculated at runtime
        public Cell[] neighbor = new Cell[MAX_NEIGHBORS];

        // the next cell to the "right" of this cell.  
        // This allows us to have all our cells in a 1D list which we will use in our recursive method below
        public Cell nextCell;

        // store the current and next cell states using our structures
        // which are "by value" fields and allow using the "=" operator to copy one structure into another
        // note that you need to use Deep or Shallow copying to copy class objects
        // therefore structures can be more efficient storage
        public StructCellState currentCellState;
        public StructCellState nextCellState;

        static Random rand = new Random();

        // the Cell constructor which accepts the total # of cells in the organism 
        // and the probability for a cell to be alive when it is created
        public Cell(int maxCells, int probability = 4)
        {
            // initialize the infected and alive states of the cell
            currentCellState.infectedState = EInfectedState.organic;
            currentCellState.AliveState = EAliveState.dead;

            // calculate probable alive state
            probability = rand.Next(0, probability);

            if (probability == 0)
            {
                // it is alive!
                currentCellState.AliveState = EAliveState.alive;

                if (nViruses < MAX_VIRUSES)
                {
                    // calculate a probability of being infected
                    if (rand.Next(0, maxCells) < maxCells / MAX_VIRUSES)
                    {
                        // it is infected!
                        currentCellState.infectedState = EInfectedState.infected;
                        ++nViruses;
                    }
                }

                // if not infected yet and not all vaccines administered yet
                if (currentCellState.infectedState == EInfectedState.organic && nVaccines < MAX_VACCINES)
                {
                    // calculate a probability of being vaccinated
                    if (rand.Next(0, maxCells) < maxCells / MAX_VACCINES)
                    {
                        // it is vaccinated!
                        currentCellState.infectedState = EInfectedState.vaccinated;
                        ++nVaccines;
                    }
                }
            }
        }

        public void SetNextState()
        {
            // counters for states of the neighboring cells
            int nAlive = 0;
            int nInfected = 0;
            int nVaccinated = 0;

            // loop through the array of all neighbors
            for (int cntr = 0; cntr < MAX_NEIGHBORS; ++cntr)
            {
                // set a "by reference" variable equal to the current neighbor
                Cell neighborCell = this.neighbor[cntr];

                // if there is a neighbor in this direction
                if (neighborCell != null)
                {
                    if (neighborCell.currentCellState.infectedState == EInfectedState.infected)
                    {
                        ++nInfected;
                    }

                    if (neighborCell.currentCellState.infectedState == EInfectedState.vaccinated)
                    {
                        ++nVaccinated;
                    }

                    if (neighborCell.currentCellState.AliveState == EAliveState.alive)
                    {
                        ++nAlive;
                    }
                }
            }

            nextCellState.infectedState = currentCellState.infectedState;
            nextCellState.AliveState = currentCellState.AliveState;

            if (nAlive < 2 || nAlive > 3)
            {
                nextCellState.AliveState = EAliveState.dead;

            }
            else
            {
                if (nAlive == 3)
                {
                    nextCellState.AliveState = EAliveState.alive;
                }
            }

            /*if (currentCellState.AliveState == EAliveState.alive &&
                nextCellState.AliveState == EAliveState.alive)
            {
                if (nInfected > 0 && nInfected > nVaccinated &&
                    currentCellState.infectedState != EInfectedState.vaccinated)
                {
                    nextCellState.infectedState = EInfectedState.infected;
                }
                else if (nVaccinated > 0)
                {
                    nextCellState.infectedState = EInfectedState.vaccinated;
                }
            }*/

            //extra credit addition - (hopefully) correctly set infected state when the cell is alive and has infected neighbors
            if (currentCellState.AliveState == EAliveState.alive)
            {
                if (nInfected > 0 && nInfected >= nVaccinated)
                {
                    nextCellState.infectedState = EInfectedState.infected;
                }
                else if (nVaccinated > 0)
                {
                    nextCellState.infectedState = EInfectedState.vaccinated;
                }
            }

        }
    }
    static internal class Program
    {
        public static int MAX_ROWS = 30;
        public static int MAX_COLS = 80;

        public static Cell[,] organism = new Cell[MAX_ROWS, MAX_COLS];

        public static bool bExit = false;

        static void Main(string[] args)
        {

            for (int row = 0; row < MAX_ROWS; ++row)
            {
                for (int col = 0; col < MAX_COLS; ++col)
                {
                    organism[row, col] = new Cell(MAX_ROWS * MAX_COLS);
                }
            }

            for (int row = 0; row < MAX_ROWS; ++row)
            {
                for (int col = 0; col < MAX_COLS; ++col)
                {
                    for (int nCntr = 0; nCntr < Cell.MAX_NEIGHBORS; ++nCntr)
                    {
                        Cell neighborCell = null;

                        switch (nCntr)
                        {
                            case (int)EDirection.right:
                                // right neighbor = [row, col + 1]
                                // this also calculates the nextCell to the "right"
                                if (col < MAX_COLS - 1)
                                {
                                    neighborCell = organism[row, col + 1];
                                    organism[row, col].nextCell = organism[row, col + 1];
                                }
                                else if (row < MAX_ROWS - 1)
                                {
                                    organism[row, col].nextCell = organism[row + 1, 0];
                                }
                                break;

                            case (int)EDirection.down:
                                // down neighbor = [row+1,col]
                                if (row < MAX_ROWS - 1)
                                {
                                    neighborCell = organism[row + 1, col];
                                }
                                break;

                            case (int)EDirection.left:
                                // left neighbor = [row,col-1]
                                if (col > 0)
                                {
                                    neighborCell = organism[row, col - 1];
                                }
                                break;

                            case (int)EDirection.up:
                                // up neighbor = [row-1,col]
                                if (row > 0)
                                {
                                    neighborCell = organism[row - 1, col];
                                }
                                break;

                            case (int)EDirection.bottomright:
                                // bottomright neighbor = [row+1,col+1]
                                if (row < MAX_ROWS - 1 && col < MAX_COLS - 1)
                                {
                                    neighborCell = organism[row + 1, col + 1];
                                }
                                break;

                            case (int)EDirection.topright:
                                // topright neighbor = [row-1,col+1]
                                if (row > 0 && col < MAX_COLS - 1)
                                {
                                    neighborCell = organism[row - 1, col + 1];
                                }
                                break;

                            case (int)EDirection.bottomleft:
                                // bottomleft neighbor = [row+1,col-1]
                                if (row < MAX_ROWS - 1 && col > 0)
                                {
                                    neighborCell = organism[row + 1, col - 1];
                                }
                                break;

                            case (int)EDirection.topleft:
                                // topleft neighbor = [row-1,col-1]
                                if (row > 0 && col > 0)
                                {
                                    neighborCell = organism[row - 1, col - 1];
                                }
                                break;
                        }

                        organism[row, col].neighbor[nCntr] = neighborCell;
                    }
                }
            }

            //extra credit addition
            IOrganismEditor organismEditor = new OrganismEditor(); //organism editor in main

            while (!bExit)
            {
                Console.WriteLine("Press 'E' to enter Organism Editor or any other key to continue.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.E)
                {
                    organismEditor.EditOrganism(organism);
                }
                else
                {
                    RunGameLoop(organism);
                }
            }

            // since we will use Unicode characters, set the console to display Unicode
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // assign a delegate method to handle when CTRL+C is pressed
            // in order to exit our infinite game loop
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancel);

            while (!bExit)
            {
                // print the current state of the organism
                PrintOrganism(organism, MAX_ROWS, MAX_COLS);

                // calculate the next state of every cell based on the current state of every cell
                CalculateNextGeneration(organism[0, 0]);

                // sleep for 100 milliseconds between each generation
                System.Threading.Thread.Sleep(100);
            }
        }

        //extra credit addition - game animations aren't looping anymore :(
        private static void RunGameLoop(Cell[,] organism)
        {
            while (!bExit)
            {
                //print current state of organism
                PrintOrganism(organism, MAX_ROWS, MAX_COLS);

                //calculate next state of every cell based on current state of every cell
                CalculateNextGeneration(organism[0, 0]);

                //sleep to allow for minor observation between gens
                System.Threading.Thread.Sleep(100);
            }
        }

        // recursive method to calculate the next state of every cell based on the current state of all neighbors
        public static void CalculateNextGeneration(Cell thisCell)
        {
            // base case is if we reached thisCell.nextCell == null
            if (thisCell != null)
            {
                // calculate the next state for the current cell
                thisCell.SetNextState();

                // recurse through the whole linked list of thisCell.nextCell (moves through all cells to the "right")
                // every time we recurse into our method we go down one rung of a ladder into a hole
                // and each rung needs to retain the data stored in thisCell to be remembered when we climb back up the ladder
                CalculateNextGeneration(thisCell.nextCell);

                // all next states have been calculated for the organism
                // now we can start climbing back up the ladder and updating the current state of each cell to the next state

                // unfold the calling stack for every cell
                // and set the current state = the next state 
                // (these are structures, so they can be copied by value)
                thisCell.currentCellState = thisCell.nextCellState;
            }
        }


        public static void ConsoleCancel(object sender, ConsoleCancelEventArgs e)
        {
            // CTRL+C sets bExit = true
            bExit = true;
        }

        public static void PrintOrganism(Cell[,] organism, int maxRows, int maxCols)
        {
            string output = "----------------------------------------------------------------------------------\n";

            for (int row = 0; row < maxRows; ++row)
            {
                output += "|";
                for (int col = 0; col < maxCols; ++col)
                {
                    Cell thisCell = organism[row, col];
                    if (thisCell.currentCellState.AliveState == EAliveState.alive)
                    {
                        switch ((int)thisCell.currentCellState.infectedState)
                        {
                            case (int)EInfectedState.organic:
                                output += "\x25cb";
                                break;

                            case (int)EInfectedState.vaccinated:
                                output += "\x25ca";
                                break;

                            case (int)EInfectedState.infected:
                                output += "\x25cf";
                                break;
                        }
                    }
                    else
                    {
                        output += " ";
                    }
                }

                output += "|\n";
            }

            output += "----------------------------------------------------------------------------------";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(output);
        }

    }

    //extra credit additions - start

    //organism editor interface
    public interface IOrganismEditor
    {
        void EditOrganism(Cell[,] organism);
    }

    //organism editor interface implemented into class
    public class OrganismEditor : IOrganismEditor
    {
        
        public void EditOrganism(Cell[,] organism)
        {

            bool exitEditor = false;

            while (!exitEditor)
            {
                //user key selection for organism editor
                while (!exitEditor)
                {
                    DisplayOrganismEditorMenu();

                    ConsoleKeyInfo key = Console.ReadKey(true);
                    Console.Clear();

                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            SetCellState(organism, EAliveState.alive);
                            break;

                        case ConsoleKey.D2:
                            SetCellState(organism, EAliveState.dead);
                            break;

                        case ConsoleKey.D3:
                            LoadInitialStateFromFile(organism);
                            break;

                        case ConsoleKey.D4:
                            SaveInitialStateToFile(organism);
                            break;

                        case ConsoleKey.D5:
                            exitEditor = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }

                if (!exitEditor)
                {
                    Console.WriteLine("Organism Editor");
                    Console.WriteLine("Chose an editing option.");
                    Console.WriteLine();
                    Console.WriteLine("1. Set cell to alive.");
                    Console.WriteLine("2. Set cell to dead.");
                    Console.WriteLine("3. Load initial state from file.");
                    Console.WriteLine("4. Save initial state to file.");
                    Console.WriteLine("5. Exit Organism Editor");
                }
            }

        }

        //to be called when the editor is not exited
        private static void DisplayOrganismEditorMenu()
        {
            Console.WriteLine("Organism Editor");
            Console.WriteLine("Chose an editing option.");
            Console.WriteLine();
            Console.WriteLine("1. Set cell to alive.");
            Console.WriteLine("2. Set cell to dead.");
            Console.WriteLine("3. Load initial state from file.");
            Console.WriteLine("4. Save initial state to file.");
            Console.WriteLine("5. Exit Organism Editor");
        }

        //allows user to set individual cell states by row and column number
        private static void SetCellState(Cell[,] organism, EAliveState state)
        {
            Console.Write("Enter row number: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter column number: ");
            int col = int.Parse(Console.ReadLine());

            if (row >= 0 && row < Program.MAX_ROWS && col >= 0 && col < Program.MAX_COLS)
            {
                organism[row, col].currentCellState.AliveState = state;
            }
            else
            {
                Console.WriteLine("Invalid cell coordinates.");
            }
        }

        //loads initial organism state from user chosen file
        private static void LoadInitialStateFromFile(Cell[,] organism)
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();

            //handles any potential exceptions or errors
            try
            {
                string[] lines = File.ReadAllLines(fileName); //read from specified file

                for (int row = 0; row < Program.MAX_ROWS && row < lines.Length; ++row) //iterate over each row
                {
                    for (int col = 0; col < Program.MAX_COLS && col < lines[row].Length; ++col) //iterate over each column
                    {
                        char cellChar = lines[row][col]; //call character representing state of cell in file

                        //sets living state of corresponding cell in organism grid
                        organism[row, col].currentCellState.AliveState = (cellChar == '1') ? EAliveState.alive : EAliveState.dead;
                    }
                }

                Console.WriteLine("Initial state loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading initial state: {ex.Message}");
            }
        }

        //
        private static void SaveInitialStateToFile(Cell[,] organism)
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();

            //handles any potential exceptions or errors
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName)) //open to specified file
                {
                    for (int row = 0; row < Program.MAX_ROWS; ++row) //iterate over rows
                    {
                        for (int col = 0; col < Program.MAX_COLS; ++col) //iterate over columns
                        {
                            //read character representation of alive state of current cell
                            char cellChar = (organism[row, col].currentCellState.AliveState == EAliveState.alive) ? '1' : '0';
                            writer.Write(cellChar); //send character to file
                        }
                        writer.WriteLine(); //move to next line in file
                    }
                }

                Console.WriteLine("Initial state saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving initial state: {ex.Message}");
            }
        }
    }

    //extra credit additions - end


}
