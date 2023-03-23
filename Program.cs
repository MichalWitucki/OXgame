using System;

namespace OXgame
{
    internal class Program
    {
        static string[,] board = new string[3, 3] { { "7", "8", "9" }, { "4", "5", "6" }, { "1", "2", "3" } };
        static Random random = new Random();
        static void Main(string[] args)
        {
            string playerSymbol, cpuSymbol;
            Console.Write("Witaj w grze kółko i krzyżyk. Wybierz swój symbol (O lub X): ");
            playerSymbol = SetSymbol().ToUpper();
            if (playerSymbol == "X")
                cpuSymbol = "O";
            else cpuSymbol = "X";
            DrawBoard();
            Game(random.Next(0,2),playerSymbol, cpuSymbol);
            
             
            

        }

        static string SetSymbol()  // orzel reszka
        {
            string symbol;
             do
             {
                symbol = Console.ReadLine();
                if (symbol.ToUpper() != "X" && symbol.ToUpper() != "O")
                {
                    Console.Write("Zły wybór. Wybierz (O lub X):");
                    continue;
                }
                break;
                
            }
            while (true);
            return symbol;
        }

        static void DrawBoard()
        {
            
            Console.WriteLine();
            for (int x = 0; x < board.GetLength(0); x++) 
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Console.Write($" {board[x,y]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

      
        static void Game(int whoStarts, string playerSymbol, string cpuSymbol)
        {
            Console.WriteLine(whoStarts); // usun
            if (whoStarts == 0)
            {
                Console.WriteLine("Zaczyna gracz.");
                do
                {
                    PlayerTurn(playerSymbol);
                    CpuTurn(cpuSymbol);
                    DrawBoard();
                }
                while (true);
            }
            else
            {
                Console.WriteLine("Zaczyna komputer.");
                do
                {
                    CpuTurn(cpuSymbol);
                    DrawBoard();
                    PlayerTurn(playerSymbol);
                    
                }
                while (true);
            }
                

        }

        static void PlayerTurn(string playerSymbol)
        {
            bool successfullTurn = false;
            do
            {
                Console.Write("Wybierz numer wolnego pola: ");
                if (!int.TryParse(Console.ReadLine(), out int playerChoice) || playerChoice < 1 || playerChoice > 9)
                {
                    Console.Write("Zły wybór. Wybierz pole od 1 - 9: ");
                }
                else 
                    successfullTurn = CheckChoice(playerChoice, playerSymbol);                   
                
            }
            while (successfullTurn == false);
        }

        static void CpuTurn(string cpuSymbol)
        {
            bool successfullTurn = false;
            int cpuChoice;
            do
            {
                cpuChoice = random.Next(1, 10);
                successfullTurn = CheckChoice(cpuChoice, cpuSymbol);
            }
            while (successfullTurn == false);
            Console.WriteLine($"Komputer wybiera: {cpuChoice}");

        }

        static bool CheckChoice(int choice, string symbol)
        {
            switch (choice)
            {
                case 1:
                    if (board[2, 0] != "1")
                        return false;   
                    else
                    {
                        board[2, 0] = symbol;
                        return true;
                    }

                case 2:
                    if (board[2, 1] != "2")
                        return false;
                    else
                    {
                        board[2, 1] = symbol;
                        return true;
                    }
                case 3:
                    if (board[2, 2] != "3")
                    return false;
                    else
                    {
                        board[2, 2] = symbol;
                        return true;
                    }
                case 4:
                    if (board[1, 0] != "4")
                    return false;
                    else
                    {
                        board[1, 0] = symbol;
                        return true;
                    }
                case 5:
                    if (board[1, 1] != "5")
                    return false;
                    else
                    {
                        board[1, 1] = symbol;
                        return true;
                    }
                case 6:
                    if (board[1, 2] != "6")
                    return false;
                    else
                    {
                        board[1, 2] = symbol;
                        return true;
                    }
                case 7:
                    if (board[0, 0] != "7")
                    return false;
                    else
                    {
                        board[0, 0] = symbol;
                        return true;
                    }
                case 8:
                    if (board[0, 1] != "8")
                    return false;
                    else
                    {
                        board[0, 1] = symbol;
                        return true;
                    }
                case 9:
                    if (board[0, 2] != "9")
                    return false;
                    else
                    {
                        board[0, 2] = symbol;
                        return true;
                    }
                 default: return false;

            }
        }


    }
}