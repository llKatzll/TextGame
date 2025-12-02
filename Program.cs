using System.Diagnostics;
using System;

namespace TextGame
{
    internal class Program
    {
        static Stopwatch _playTimer = new Stopwatch();

        static int _cursorX = 0;
        static int _cursorY = 0;

        static string _playerGender = ""; //male /female /another
        static string _playerName = "";
        static int _age = 0;

        // karma : 악행수치 divine : 선행수치  게임의 흐름을 바꾼다.
        static int _karma = 0;
        static int _divine = 0;

        //플레이어 스탯
        static int _level = 1;
        static float _currentHp = 100;
        static float _maxHp = 100;
        static float _atk = 5;
        static float _def = 40;
        static float _dgd = 30;

        // 장비 스탯
        static string _empower = ""; //권능. 딜리터/메모라이즈/부산물
        static string _weaponName = "";
        static string _armorName = "";
        static string[] _accs = { "", "", "" };

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

        static void Clear()
        {
            Console.Clear();
            StatViewer();
        }

        static void GameStart()
        {
            Thread.Sleep(1000);

            Console.WriteLine("안녕하세요.");
            Thread.Sleep(1600);
            Clear();

            Console.WriteLine("시작하기 전에, 간단한 질문 몇 가지만 할게요.");
            Thread.Sleep(1600);
            Clear();

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

                Clear();

                Thread.Sleep(1500);

                switch (_insert.KeyChar)
                {
                    case '1':
                        Console.WriteLine("감사합니다.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        _playerGender = "male";
                        Clear();
                        break;
                    case '2':
                        Console.WriteLine("감사합니다.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        _playerGender = "female";
                        Clear();
                        break;
                    case '3':
                        Console.WriteLine("음.");
                        Thread.Sleep(500);
                        Console.WriteLine("알겠습니다.");
                        Thread.Sleep(1000);
                        _loopAsk = true;
                        _playerGender = "another";
                        Clear();
                        break;
                    default:
                        if(_gotMad == 1)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("하하..");
                            Thread.Sleep(500);
                            Clear();
                            Console.WriteLine("다시해주세요.");
                            _gotMad += 1;
                            Thread.Sleep(500);
                            Clear();
                            break;
                        }
                        if (_gotMad == 2)
                        {
                            Thread.Sleep(500);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("마지막 기회입니다.");
                            Thread.Sleep(500);
                            Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("다시 해");
                            _gotMad += 1;
                            Thread.Sleep(300);
                            Clear();
                            break;
                        }
                        if (_gotMad == 3)
                        {
                            Thread.Sleep(200);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            for (int i = 0; i < 50; i++)
                            {
                                Thread.Sleep(10);
                                _playerName = "DELETED";
                                _level = 0;
                                TakeDamage(2);
                                Console.WriteLine("DELETE");
                                Clear();
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
                        Clear();
                        Thread.Sleep(10);
                        Console.WriteLine(".");
                        Thread.Sleep(20);
                        Console.WriteLine(".");
                        Thread.Sleep(30);
                        Console.WriteLine(".");
                        Thread.Sleep(500);
                        Clear();
                        Console.WriteLine("다시해주세요.");
                        _gotMad += 1;
                        Thread.Sleep(300);
                        Clear();
                        break;
                }
            }

            _loopAsk = false;
            Thread.Sleep(500);
            Console.WriteLine("다음.");
            Thread.Sleep(500);
            Clear();

            bool _askingName = false;

            while (!_askingName)
            {
                //버퍼에 쌓인 키 전부 버리기 (무브스텍 제거)
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Clear();
                Console.WriteLine("이름이 어떻게 되시나요?");
                Console.Write("당신의 이름을 입력하세요 : ");
                _playerName = Console.ReadLine();

                Clear();
                Thread.Sleep(1500);
                Console.WriteLine(_playerName + ".");
                Thread.Sleep(300);
                Console.WriteLine("이게 정말 당신의 이름이 맞나요?");

                Console.WriteLine("\n 1. Yes \n 2. No");

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Clear();

                switch (_insert.KeyChar)
                {
                    case '1':
                        Thread.Sleep(300);
                        Console.WriteLine("네," + _playerName + ".");
                        Thread.Sleep(1000);
                        Clear();
                        Console.WriteLine("좋은 이름이네요.");
                        Thread.Sleep(1000);
                        _askingName = true;
                        Clear();
                        break;
                    case '2':
                        _playerName = "";
                        Clear();
                        Thread.Sleep(300);
                        Console.WriteLine("그럼 바꿀 기회를 드리죠.");
                        Thread.Sleep(1200);
                        Clear();
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
            Clear();
            Thread.Sleep(1100);
            Console.WriteLine("흠 이것만 물을게요.");
            Thread.Sleep(1000);
            Clear();

            while (!_loopAsk)
            {
                Console.WriteLine("연세는 어찌 되시나요?");

                Clear();
                Console.Write("당신의 나이를 입력하세요 :");
                string ageInput = Console.ReadLine();

                bool _isBig = int.TryParse(ageInput, out _age);
                Thread.Sleep(300);
                Clear();

                if (!_isBig)
                {
                    Clear();
                    Console.WriteLine("다시해주세요. (값이 너무 크거나 숫자외의 값을 입력하셨어요)");
                    Thread.Sleep(300);
                    Clear();
                }

                if (int.Parse(ageInput) <= 10)
                {
                    Clear();
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
                    Clear();
                }
                else if(int.Parse(ageInput) > 0 && int.Parse(ageInput) <= 20)
                {
                    Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine("젊으시네요.");
                    Thread.Sleep(500);
                    _age = int.Parse(ageInput);
                    Clear();
                    break;
                }
                else if (int.Parse(ageInput) > 100)
                {
                    Clear();
                    Thread.Sleep(500);
                    Console.WriteLine("믿기지 않네요.");
                    Thread.Sleep(1200);
                    _age = int.Parse(ageInput);
                    Clear();
                    break;
                }
                else if(int.Parse(ageInput) <= 99)
                {
                    _age = int.Parse(ageInput);
                    break;
                }
            }
            Clear();
            Thread.Sleep(1200);

            if (_age == 24 && (_playerName == "Keres" || _playerName == "케레스" || _playerName == "에단" || _playerName == "Edan") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(300);
                Console.WriteLine("왜 다시 왔는가.");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("그때의 소멸은 그녀가 스스로 초래한 일.");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("너와 나는 일절 관계없다.");
                Thread.Sleep(300);
                TakeDamage(10f);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();

            }

            if (_age == 25 && (_playerName == "Katz" || _playerName == "카츠") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(300);
                Console.WriteLine("그를 따라하는군.");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("넌 그가 세운 계획의 협력자인가?");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("앞으로의 길에 불행이 가득하기를.");
                TakeDamage(50f);
                Thread.Sleep(300);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();

            }

            if (_age == 25 && (_playerName == "Lev" || _playerName == "레브") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(300);
                Console.WriteLine("그를 따라하는군.");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("의지의 뜻을 거역하는것인가.");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("그는 우리의 세계에 있어 절대악이 되었을터.");
                TakeDamage(25f);
                Thread.Sleep(300);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();

            }

            if (_age == 28 && (_playerName == "Chronos" || _playerName == "크로노스") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(300);
                Console.WriteLine("그를 따라하는군.");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("카스티지움은");
                Thread.Sleep(300);
                Clear();
                Console.WriteLine("다른 시간선의 자신을 껄끄러워하지.");
                TakeDamage(15f);
                Thread.Sleep(300);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();

            }

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(".");
            }
            Thread.Sleep(500);
            Clear();
            Console.WriteLine("확인했습니다.");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            Clear();
            Thread.Sleep(1000);
            Console.WriteLine("환영합니다!");
            Thread.Sleep(500);
            Console.WriteLine("짧은 여정을 함께합시다.");
            Thread.Sleep(1000);
        }

        static void StatViewer()
        {
            
            int _hpBarAmount = 10;

            Console.SetCursorPosition(75,0);
            Console.Write("[LEVEL : " + _level + " ]");
            
            Console.SetCursorPosition(75, 1);
            Console.Write("[NAME : " + _playerName + " ]");

            Console.SetCursorPosition(75, 2);
            Console.Write("[Age : " + _age + " ]");

            //체력바 구현 (체력 10% 이하일땐 점멸)
            Console.SetCursorPosition(75, 4);

            //현재 HP 비율
            double _ratio = (double)_currentHp / _maxHp;

            //채워야할 체력바
            int _filledBar = (int)(_ratio * _hpBarAmount);

            Console.Write("{ HP : ");

            //체력바 출력
            for (int i = 0; i < _hpBarAmount; i++)
            {
                if (i < _filledBar)
                    Console.Write("■"); 
                else
                    Console.Write("□");  
            }

            Console.WriteLine($" {_currentHp}/{_maxHp}" + " }");

            Console.SetCursorPosition(_cursorX, _cursorY);
        }

        static void TakeDamage(float damage)
        {
            _currentHp -= damage;
            if (_currentHp < 0)
                _currentHp = 0;
        }

        static void TutorialScenario()
        {
            
        }
    }
}
