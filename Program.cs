namespace TextGame
{
    internal class Program
    {
        static int _cursorX = 0;
        static int _cursorY = 0;

        static string _playerGender = ""; //male /female /another
        static string _playerName = "";
        static int _age = 0;
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
            Console.Title = "Severed Realm";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorVisible = false;

            Console.SetCursorPosition(_cursorX,_cursorY);

            GameStart();
            
        }



        static void GameStart()
        {
            Thread.Sleep(1000);

            Console.WriteLine("안녕하세요.");
            Thread.Sleep(1600);
            Console.Clear();

            Console.WriteLine("시작하기 전에, 간단한 질문 몇 가지만 할게요.");
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

                Console.WriteLine("성별이 어떻게 되시나요?");
                Thread.Sleep(500);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 1);
                Console.WriteLine("1. 남성");
                Thread.Sleep(500);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 2);
                Console.WriteLine("2. 여성");
                Thread.Sleep(500);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 3);
                Console.WriteLine("3. 그 외");
                Thread.Sleep(50);
                Console.SetCursorPosition(_cursorX + 1, _cursorY + 5);
                Console.WriteLine("※ 해당하는 숫자키를 누름으로써 답변할 수 있습니다.");

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Console.Clear();

                Thread.Sleep(1500);

                switch (_insert.KeyChar)
                {
                    case '1':
                        Console.WriteLine("감사합니다.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        _playerGender = "male";
                        Console.Clear();
                        break;
                    case '2':
                        Console.WriteLine("감사합니다.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        _playerGender = "female";
                        Console.Clear();
                        break;
                    case '3':
                        Console.WriteLine("음.");
                        Thread.Sleep(500);
                        Console.WriteLine("알겠습니다.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        _playerGender = "another";
                        Console.Clear();
                        break;
                    default:
                        if(_gotMad == 1)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("하하..");
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.WriteLine("다시해주세요.");
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
                            Console.WriteLine("마지막 기회입니다.");
                            Thread.Sleep(500);
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("다시 해");
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
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int i = 0; i < 25; i++)
                        {
                            Thread.Sleep(2);
                            Console.WriteLine("'1,2,3'중 하나만 눌러");
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
                        Console.WriteLine("다시해주세요.");
                        _gotMad += 1;
                        Thread.Sleep(300);
                        Console.Clear();
                        break;
                }
            }

            _loopAsk = false;
            Thread.Sleep(500);
            Console.WriteLine("다음.");
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
                Console.WriteLine("이름이 어떻게 되시나요?");
                Console.Write("당신의 이름을 입력하세요 : ");
                _playerName = Console.ReadLine();

                Console.Clear();
                Thread.Sleep(1500);
                Console.WriteLine(_playerName + ".");
                Thread.Sleep(300);
                Console.WriteLine("이게 정말 당신의 이름이 맞나요?");

                Console.WriteLine("\n 1. Yes \n 2. No");

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Console.Clear();

                switch (_insert.KeyChar)
                {
                    case '1':
                        Thread.Sleep(300);
                        Console.WriteLine("네," + _playerName + ".");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("좋은 이름이네요.");
                        Thread.Sleep(1000);
                        _askingName = true;
                        Console.Clear();
                        break;
                    case '2':
                        Console.Clear();
                        Thread.Sleep(300);
                        Console.WriteLine("그럼 바꿀 기회를 드리죠.");
                        Thread.Sleep(1200);
                        Console.Clear();
                        break;
                }
            }
            Thread.Sleep(300);
            Console.WriteLine(_playerName + ".");
            for(int i = 0;i < 3; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
            //--- 핵심 시작 전 단계
            Console.Clear();
            Thread.Sleep(1100);
            Console.WriteLine("흠 이것만 물을게요.");
            Thread.Sleep(1000);
            Console.Clear();

            while (!_loopAsk)
            {
                Console.WriteLine("연세는 어찌 되시나요?");

                Console.Clear();
                Console.Write("당신의 나이를 입력하세요 :");
                string ageInput = Console.ReadLine();

                bool _isBig = int.TryParse(ageInput, out _age);
                Thread.Sleep(300);
                Console.Clear();

                if (!_isBig)
                {
                    Console.Clear();
                    Console.WriteLine("다시해주세요. (값이 너무 크거나 숫자외의 값을 입력하셨어요)");
                    Thread.Sleep(300);
                    Console.Clear();
                }

                if (int.Parse(ageInput) <= 10)
                {
                    Console.Clear();
                    Thread.Sleep(300);

                    Console.WriteLine("진심인가요?");
                    Thread.Sleep(300);
                    Console.WriteLine("구");
                    Thread.Sleep(150);
                    Console.WriteLine("구");
                    Thread.Sleep(150);
                    Console.WriteLine("가");
                    Thread.Sleep(150);
                    Console.WriteLine("가");
                    Thread.Sleep(150);
                    Console.WriteLine("?");
                    Thread.Sleep(1000);
                    Console.WriteLine("다시해주세요.");
                    Thread.Sleep(300);
                    Console.Clear();
                }
                else if(int.Parse(ageInput) > 0 && int.Parse(ageInput) <= 20)
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine("젊으시네요.");
                    Thread.Sleep(500);
                    _age = int.Parse(ageInput);
                    Console.Clear();
                    break;
                }
                else if (int.Parse(ageInput) > 100)
                {
                    Console.Clear();
                    Thread.Sleep(500);
                    Console.WriteLine("믿기지 않네요.");
                    Thread.Sleep(1200);
                    _age = int.Parse(ageInput);
                    Console.Clear();
                    break;
                }
                else if(int.Parse(ageInput) <= 99)
                {
                    _age = int.Parse(ageInput);
                    break;
                }
            }
            Console.Clear();
            Thread.Sleep(1200);

            if (_age == 24 && (_playerName == "Keres" || _playerName == "케레스" || _playerName == "에단" || _playerName == "Edan") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Thread.Sleep(200);
                Console.WriteLine("왜 다시 왔는가.");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("그때의 소멸은 그녀가 스스로 초래한 일.");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("너와 나는 일절 관계없다.");
                Thread.Sleep(200);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Clear();

            }

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(".");
            }
            Console.Clear();
            Console.WriteLine("확인했습니다.");
        }
    }
}
