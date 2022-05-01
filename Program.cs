/*
CSE 210 Assignment: "01 Ponder & Prove: Developer (Tic-Tac-Toe)"
Colby Hale;
*/

using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string Player1 = "X";
            string Player2 = "O";
            string CurrentPlayer = Player1;
            List<string> grid = new List<string>();
            bool ValidSpot = false;
            int NumberOfTurns = 1;
            bool StillPlaying = true;
            int ChosenSpot = 0;

            CreateGrid(grid);

            while (StillPlaying == true)
            {
                ValidSpot = false;
                while (ValidSpot == false)
                {
                    Console.Write($"{CurrentPlayer}, pick a spot! (1-9): ");
                    ChosenSpot = int.Parse(Console.ReadLine());
                    ValidSpot = CheckForValidSpot(grid, ChosenSpot, ValidSpot, Player1, Player2);
                }
                DrawGrid(grid, ChosenSpot, CurrentPlayer);
                StillPlaying = CheckForWin(grid, CurrentPlayer, StillPlaying);
                StillPlaying = CheckForDraw(NumberOfTurns, StillPlaying);
                
                if (CurrentPlayer == Player1)
                {
                    CurrentPlayer = Player2;
                }
                else
                {
                    CurrentPlayer = Player1;
                }
                NumberOfTurns += 1;
            }

        }
        static bool CheckForWin(List<string> grid, string CurrentPlayer, bool StillPlaying)
        {
            // I do not apologize for this.
            if (grid[7] == CurrentPlayer && grid[8] == CurrentPlayer && grid[9] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[4] == CurrentPlayer && grid[5] == CurrentPlayer && grid[6] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[1] == CurrentPlayer && grid[2] == CurrentPlayer && grid[3] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[7] == CurrentPlayer && grid[4] == CurrentPlayer && grid[1] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[8] == CurrentPlayer && grid[5] == CurrentPlayer && grid[2] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[9] == CurrentPlayer && grid[6] == CurrentPlayer && grid[3] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[7] == CurrentPlayer && grid[5] == CurrentPlayer && grid[3] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            else if (grid[9] == CurrentPlayer && grid[5] == CurrentPlayer && grid[1] == CurrentPlayer)
            {
                Console.WriteLine($"{CurrentPlayer} wins!");
                StillPlaying = false;
            }
            return StillPlaying;
        }

        static bool CheckForDraw(int NumberOfTurns, bool StillPlaying)
        {
            if (NumberOfTurns == 9)
            {
                Console.WriteLine("It's a draw!");
                StillPlaying = false;
            }
            return StillPlaying;
        }

        static object CreateGrid(List<string> grid)
        {
            int count = 0;
            while (count < 10)
            {
                grid.Add(count.ToString());
                count += 1;
            }

            string board = @$" {grid[7]} | {grid[8]} | {grid[9]}
---+---+---
 {grid[4]} | {grid[5]} | {grid[6]}
---+---+---
 {grid[1]} | {grid[2]} | {grid[3]}";
            Console.WriteLine(board);

            return grid;
        }

        static bool CheckForValidSpot(List<string> grid, int ChosenSpot, bool ValidSpot, string Player1, string Player2)
        {
            if (grid[ChosenSpot] != Player1 && grid[ChosenSpot] != Player2 && ChosenSpot > 0 && ChosenSpot < 10)
            {
                ValidSpot = true;
            }
            else
            {
                Console.WriteLine("Invalid spot. Pick again!");
            }

            return ValidSpot;
        }

        static void DrawGrid(List<string> grid, int ChosenSpot, string CurrentPlayer)
        {
            grid[ChosenSpot] = CurrentPlayer;
            string board = @$" {grid[7]} | {grid[8]} | {grid[9]}
---+---+---
 {grid[4]} | {grid[5]} | {grid[6]}
---+---+---
 {grid[1]} | {grid[2]} | {grid[3]}";
            Console.WriteLine(board);
        }
    }
}