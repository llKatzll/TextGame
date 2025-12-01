namespace TextGame
{
    internal class Program
    {
        static int _cursorX = 0;
        static int _cursorY = 0;

        static string _playerGender = ""; //male /female /another
        static string _playerName = "";

        // karma : 악행수치 divine : 선행수치  게임의 흐름을 바꾼다.

        static int _karma = 0;
        static int _divine = 0;

        static int _level = 1;
        static int _hp = 100;
        static int _atk = 5;
        static int _def = 40;
        static int _dgd = 30;

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

            int _gotMad = 0;

            bool _loopAsk = false;

            while (!_loopAsk)
            {
                //버퍼에 쌓인 키 전부 버리기 (무브스텍 제거)
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Console.WriteLine("What is your gender?");
                Thread.Sleep(500);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 1);
                Console.WriteLine("1. Male");
                Thread.Sleep(500);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 2);
                Console.WriteLine("2. Female");
                Thread.Sleep(500);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 3);
                Console.WriteLine("3. Another");
                Thread.Sleep(200);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 5);
                Console.WriteLine("※ You can reply with number");

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Console.Clear();

                Thread.Sleep(1500);

                switch (_insert.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Ok.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        Console.Clear();
                        break;
                    case '2':
                        Console.WriteLine("Ok.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        Console.Clear();
                        break;
                    case '3':
                        Console.WriteLine("What.");
                        Thread.Sleep(500);
                        Console.WriteLine("Well, I can understand you.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        Console.Clear();
                        break;
                    default:
                        if(_gotMad == 1)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("Really?");
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.WriteLine("Try Again.");
                            _gotMad += 1;
                            Thread.Sleep(500);
                            Console.Clear();
                            break;
                        }
                        if (_gotMad == 2)
                        {
                            Thread.Sleep(500);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Last Chance.");
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Try Again.");
                            _gotMad += 1;
                            Thread.Sleep(300);
                            Console.Clear();
                            break;
                        }
                        if (_gotMad == 3)
                        {
                            Thread.Sleep(200);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            for (int i = 0; i < 50; i++)
                            {
                                Thread.Sleep(2);
                                Console.WriteLine("DELETE");
                            }
                            Thread.Sleep(100);
                            Environment.Exit(0);
                        }
                        Console.WriteLine("Don't be shy.");
                        Thread.Sleep(500);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int i = 0; i < 25; i++)
                        {
                            Thread.Sleep(2);
                            Console.WriteLine("PRESS ONLY '1,2,3'");
                        }
                        Thread.Sleep(100);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();
                        Thread.Sleep(10);
                        Console.WriteLine(".");
                        Thread.Sleep(20);
                        Console.WriteLine(".");
                        Thread.Sleep(30);
                        Console.WriteLine(".");
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.WriteLine("Try Again.");
                        _gotMad += 1;
                        Thread.Sleep(300);
                        Console.Clear();
                        break;
                }
            }

            Thread.Sleep(500);
            Console.WriteLine("Next.");
            Thread.Sleep(500);
            Console.Clear();

            bool _askingName = false;

            while (!_askingName)
            {
                //버퍼에 쌓인 키 전부 버리기 (무브스텍 제거)
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Console.Clear();
                Console.WriteLine("What is your name?");
                Console.Write("Type your name : ");
                _playerName = Console.ReadLine();

                Console.Clear();
                Thread.Sleep(1500);
                Console.WriteLine(_playerName + ".");
                Thread.Sleep(300);
                Console.WriteLine("Is this really your name?");

                Console.WriteLine("\n 1. Yes \n 2. No");

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Console.Clear();

                switch (_insert.KeyChar)
                {
                    case '1':
                        Thread.Sleep(300);
                        Console.WriteLine("Ok," + _playerName + ".");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Such a good name.");
                        Thread.Sleep(1000);
                        _askingName = true;
                        Console.Clear();
                        break;
                    case '2':
                        Console.Clear();
                        Thread.Sleep(300);
                        Console.WriteLine("Huh?- well, Let's change.");
                        Thread.Sleep(1200);
                        Console.Clear();
                        break;
                }
            }
            Thread.Sleep(300);
            Console.WriteLine(_playerName + ".");
            Thread.Sleep(200);

        }
    }
}
