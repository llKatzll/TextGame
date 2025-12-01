namespace TextGame
{
    internal class Program
    {
        static int _cursorX = 0;
        static int _cursorY = 0;

        static string _playerGender = "";
        static string _playerName = "";

        // karma : 악행수치 divine : 선행수치  게임의 흐름을 바꾼다.

        int _karma = 0;
        int _divine = 0;

        int _level = 1;
        int _hp = 100;
        int _atk = 5;
        int _def = 40;
        int _dgd = 30;


        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.Title = "Average Text Game";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(_cursorX,_cursorY);

            GameStart();
            
        }

        static void GameStart()
        {
            Thread.Sleep(1000);

            Console.WriteLine("Hello.");
            Thread.Sleep(1600);
            Console.Clear();

            Console.WriteLine("Before start, Let me ask something.");
            Thread.Sleep(1600);
            Console.Clear();

            Console.WriteLine("What is your gender?");
            Thread.Sleep(1000);
            Console.SetCursorPosition(_cursorX + 1, _cursorY + 1);
            Console.WriteLine("1. Male");
            Thread.Sleep(1000);
            Console.SetCursorPosition(_cursorX + 1, _cursorY + 2);
            Console.WriteLine("2. Female");
            Thread.Sleep(1000);
            Console.SetCursorPosition(_cursorX + 1, _cursorY + 3);
            Console.WriteLine("3. Another");
            Thread.Sleep(1000);
            Console.SetCursorPosition(_cursorX + 1, _cursorY + 5);
            Console.WriteLine("※ You can reply with number");

            ConsoleKeyInfo _insert = Console.ReadKey();
            
            Console.Clear();

            Thread.Sleep(1500);

            switch (_insert.KeyChar)
            {
                case '1':
                    Console.WriteLine("Ok.");
                    Thread.Sleep(1000);
                    break;
                case '2':
                    Console.WriteLine("Ok.");
                    Thread.Sleep(1000);
                    break;
                case '3':
                    Console.WriteLine("What.");
                    Thread.Sleep(500);
                    Console.WriteLine("Well, I can understand you.");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("Don't be shy.");
                    Thread.Sleep(500);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;

            }

            

        }


    }
}
