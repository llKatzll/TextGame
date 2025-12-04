using System.Diagnostics;
using System;
using System.Threading;

namespace TextGame
{
    //It took me ten years to find the answer to something, I forgot about it in 2 seconds, that's about it
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
        static float _atk = 3;
        static float _def = 50;
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

            Console.SetCursorPosition(_cursorX, _cursorY);

            _playTimer.Start();

            GameStart();
            TutorialScenario();
        }

        // --------------------------------
        // 공통 유틸
        // --------------------------------
        static void Clear()
        {
            Console.Clear();
            StatViewer();
        }

        static void StatViewer()
        {
            int _hpBarAmount = 10;

            Console.SetCursorPosition(75, 0);
            Console.Write("[LEVEL : " + _level + " ]");

            Console.SetCursorPosition(75, 1);
            Console.Write("[NAME : " + _playerName + " ]");

            Console.SetCursorPosition(75, 2);
            Console.Write("[Age : " + _age + " ]");

            //체력바 구현 (체력 칸 3칸이하일때 붉은 색)
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

            Console.SetCursorPosition(75, 6);
            Console.Write("[ ATK : " + _atk + " ]");
            Console.SetCursorPosition(75, 7);
            Console.Write("[ DEF Chance : " + _def + " ]");
            Console.SetCursorPosition(75, 8);
            Console.Write("[ DGD Chance : " + _dgd + " ]");

            Console.SetCursorPosition(_cursorX, _cursorY);
        }

        static void TakeDamage(float damage)
        {
            _currentHp -= damage;

            if (_currentHp < 0)
            {
                _currentHp = 0;
            }
        }

        static void Heal(float heal)
        {
            _currentHp += heal;

            if (_currentHp > 100)
            {
                _currentHp = 100;
            }
        }

        // --------------------------------
        // 게임 시작 / 튜토리얼
        // --------------------------------
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
                        if (_gotMad == 1)
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
            for (int i = 0; i < 3; i++)
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

            bool ageOk = false;

            while (!ageOk)
            {
                // 버퍼 클리어
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Clear();
                Console.Write("당신의 나이를 입력하세요 : ");
                string ageInput = Console.ReadLine();

                // 정수 변환 실패 → 재입력
                if (!int.TryParse(ageInput, out _age))
                {
                    Clear();
                    Console.WriteLine("다시해주세요. (숫자만 입력해주세요 ※너무 큰 숫자도 안됩니다.)");
                    Thread.Sleep(1700);
                    continue;
                }

                Clear();
                Thread.Sleep(500);

                // 나이 조건 판정
                if (_age <= 10)
                {
                    Console.WriteLine("진심인가요?");
                    Thread.Sleep(400);
                    Console.WriteLine("구");
                    Thread.Sleep(200);
                    Console.WriteLine("구");
                    Thread.Sleep(200);
                    Console.WriteLine("가");
                    Thread.Sleep(200);
                    Console.WriteLine("가");
                    Thread.Sleep(200);
                    Console.WriteLine("?");
                    Thread.Sleep(1200);
                    Console.WriteLine("전 이 세계를 어린아이에게 보여주진 못하겠네요.");
                    Thread.Sleep(1700);
                    Clear();
                    Environment.Exit(0);
                }
                else if (_age > 0 && _age <= 20)
                {
                    Console.WriteLine("젊으시네요.");
                    Thread.Sleep(800);
                    Clear();
                    ageOk = true;
                }
                else if (_age > 100)
                {
                    Console.WriteLine("믿기지 않네요.");
                    Thread.Sleep(1100);
                    Clear();
                    ageOk = true;
                }
                else if (_age <= 99)
                {
                    ageOk = true;
                    Clear();
                }
            }

            Clear();
            Thread.Sleep(1200);

            if (_age == 24 && (_playerName == "Keres" || _playerName == "케레스" || _playerName == "에단" || _playerName == "Edan") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(800);
                Console.WriteLine("왜 다시 왔는가.");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("그때의 소멸은 그녀가 스스로 초래한 일.");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("애석한 일이다만, 너와 나는 일절 관계없다.");
                TakeDamage(10f);
                Thread.Sleep(1500);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
            }

            if (_age == 25 && (_playerName == "Katz" || _playerName == "카츠") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(800);
                Console.WriteLine("그를 따라하는군.");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("넌 그가 세운 계획의 협력자인가?");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("앞으로의 길에 불행이 가득하기를.");
                Thread.Sleep(800);
                TakeDamage(50f);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
            }

            if (_age == 25 && (_playerName == "Lev" || _playerName == "레브") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(800);
                Console.WriteLine("그를 따라하는군.");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("의지의 뜻을 거역하는것인가.");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("그는 우리의 세계에 있어 절대악이 되었을터.");
                Thread.Sleep(1000);
                TakeDamage(25f);
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
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("카스티지움은");
                Thread.Sleep(800);
                Clear();
                Console.WriteLine("다른 시간선의 자신을 껄끄러워하지.");
                Thread.Sleep(800);
                TakeDamage(15f);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
            }

            if (_age == 26 && (_playerName == "Arencia" || _playerName == "아렌시아") && _playerGender == "female")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();
                Thread.Sleep(300);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                Clear();
                Console.WriteLine("'그'와 나를.");
                Thread.Sleep(1000);
                Clear();
                Console.WriteLine("모욕하려 드는군.");
                Thread.Sleep(1500);
                TakeDamage(75f);
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
            Console.WriteLine("환영합니다");
            Thread.Sleep(500);
            Console.WriteLine("눈을 뜨십시오.");
            Thread.Sleep(1000);
        }

        static void TutorialScenario()
        {
            Thread.Sleep(1000);
            Clear();
            Console.WriteLine("새하얀 공간에서 눈을 떴다.");
            Thread.Sleep(2000);
            Clear();
            Console.WriteLine("원목의 냄새와 희미한 꽃향이 코를 간지럽힌다.");
            Thread.Sleep(2500);
            Clear();
            Console.WriteLine("내 이름은-");
            Thread.Sleep(2300);
            Clear();
            Console.WriteLine(_playerName + ". 기억났다.");
            Thread.Sleep(2000);
            Clear();
            Console.WriteLine("분명 나는 아까-");
            Thread.Sleep(1700);
            Clear();
            Console.Write("1. (기억이 나지 않아 말을 삼킨다.) \n2. (무언가에 열중하고 있었다.)\n3. (특별함 없이 살아가고 있었다.)");

            bool _answered = false;

            while (!_answered)
            {
                ConsoleKeyInfo _insert = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                switch (_insert.KeyChar)
                {
                    case '1':
                        Clear();
                        Thread.Sleep(200);
                        Console.Write("...");
                        Thread.Sleep(1000);
                        _answered = true;
                        Clear();
                        break;
                    case '2':
                        Clear();
                        Thread.Sleep(200);
                        Console.Write("무엇인진 잊어버렸지만..");
                        Thread.Sleep(1600);
                        _answered = true;
                        Clear();
                        break;
                    case '3':
                        Clear();
                        Thread.Sleep(200);
                        Console.Write("여긴 어디지..?");
                        Thread.Sleep(1700);
                        _answered = true;
                        Clear();
                        break;
                    default:
                        break;
                }
            }

            _answered = false;

            Clear();
            Console.WriteLine($"\"(야!)\"");
            Thread.Sleep(700);
            Clear();
            Console.WriteLine($"\"(네 차례야! {_playerName}!)\"");
            Thread.Sleep(2000);
            Clear();
            Console.WriteLine("(옆자리에 있던 한 아이가 내게 은밀히 주의를 주었다.)");
            Thread.Sleep(2000);
            Clear();
            Console.Write("(고개를 아래로 내리자,)");
            Thread.Sleep(1100);
            Clear();
            Console.WriteLine("(손에는 처음보는 교본이 쥐어져있었다.)");
            Thread.Sleep(2000);
            Clear();
            Console.WriteLine("(그때, 교탁으로 보이는 곳에서 선생님으로 추정되는 이가 입을 열었다.)");
            Thread.Sleep(3500);
            Clear();
            Console.WriteLine($"\"24열 8번 문항, 정답이 뭐였죠 {_playerName}?\"");
            Thread.Sleep(3500);
            Clear();
            Console.WriteLine("(펄럭이는 종잇장 소리들속에서 나는 질문에 대한 대답을 강요받는다.)");
            Thread.Sleep(4000);
            Clear();
            Console.Write("1. 아무 답이나 내뱉는다\n2. 물어본다\n3. 이 세계에서 내보내달라 소리친다");

            while (!_answered)
            {
                ConsoleKeyInfo _insert = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                switch (_insert.KeyChar)
                {
                    case '1':
                        Clear();
                        Thread.Sleep(200);
                        Console.Write("...");
                        Thread.Sleep(1000);
                        Clear();
                        Console.Write($"\"3번?\"");
                        Thread.Sleep(1000);
                        Clear();
                        Console.Write("내 목소리가 교실의 정적을 깼다.");
                        Thread.Sleep(1500);
                        Clear();
                        Console.Write("오답이라는 말과 함께 나는 어느새 주변 아이들의 웃음거리가 되어있었다.");
                        Thread.Sleep(2500);
                        _answered = true;
                        Clear();
                        break;
                    case '2':
                        Clear();
                        Thread.Sleep(200);
                        Console.Write($"\"(정답이 뭔지 알아?)\"");
                        Thread.Sleep(1200);
                        Clear();
                        Console.Write($"\"(뭐?)\"");
                        Thread.Sleep(900);
                        Clear();
                        Console.Write("아이가 어이없다는 듯이 물었다.");
                        Thread.Sleep(1400);
                        Clear();
                        Console.Write($"\"(하.. 이번만이다)\"");
                        Thread.Sleep(1600);
                        Clear();
                        Console.Write($"\"(4, 루트)\"");
                        _divine++;
                        Thread.Sleep(1200);
                        Clear();
                        Console.Write("나는 그대로 대답하였고, 주변의 놀라는 반응과 함께 위기는 넘어가졌다.");
                        Thread.Sleep(2500);
                        Clear();
                        _answered = true;
                        Clear();
                        break;
                    case '3':
                        Clear();
                        Thread.Sleep(200);
                        Console.Write("나는 자리를 박차고 일어났다.");
                        Thread.Sleep(1300);
                        Clear();
                        Console.Write("순식간에 모든 시선이 내 표피에 꽃힌다.");
                        Thread.Sleep(2000);
                        Clear();
                        Console.Write($"\"ㅇ-여긴 어디야!\"");
                        Thread.Sleep(1500);
                        Clear();
                        Console.Write("옆자리 아이의 눈동자엔 사회에 섞이지 못한 정신이상자가 비춰지고 있었다.");
                        Thread.Sleep(3000);
                        Clear();
                        Thread.Sleep(100);
                        Console.Write($"\"-..날 어서 여기서 꺼내줘!");
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write("!");
                            Thread.Sleep(110);
                        }
                        Console.Write("\"");
                        Thread.Sleep(1600);
                        Clear();
                        Console.Write($"\"지");
                        Thread.Sleep(170);
                        Console.Write("랄");
                        Thread.Sleep(160);
                        Console.Write(" 말");
                        Thread.Sleep(100);
                        Console.Write("라");
                        Thread.Sleep(70);
                        Console.Write("ㄱ-");
                        Thread.Sleep(60);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Clear();
                        Thread.Sleep(2500);
                        Console.Write("너");
                        Thread.Sleep(1500);
                        Clear();
                        Console.Write(_playerName + ".");
                        Thread.Sleep(2500);
                        Clear();
                        Console.Write("멋대로 행동하지마라.");
                        for (int i = 0; i < 10; i++)
                        {
                            Thread.Sleep(500);
                            TakeDamage(5f);
                            Clear();
                        }
                        Thread.Sleep(500);
                        Clear();
                        Console.Write("흐름에 동조해라.");
                        Thread.Sleep(1500);
                        Clear();
                        Console.Write("그럼 탈출을 도와주지.");
                        for (int i = 0; i < 10; i++)
                        {
                            Thread.Sleep(500);
                            Clear();
                            Heal(5f);
                        }
                        Thread.Sleep(500);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Clear();
                        Thread.Sleep(1300);
                        Console.Write("아이들이 수근거린다.");
                        Thread.Sleep(3000);
                        Clear();
                        Console.Write("그리고 난 지금 상황을 이해했다.");
                        Thread.Sleep(3000);
                        Clear();
                        Console.Write("내 시간이 되돌려졌구나.");
                        Thread.Sleep(3000);
                        Clear();
                        _answered = true;
                        Clear();
                        break;
                    default:
                        break;
                }
            }
        }

        static void Choose() //템플릿
        {
            //------------------------------
            bool _answered = false;

            while (!_answered)
            {
                ConsoleKeyInfo _insert = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                switch (_insert.KeyChar)
                {
                    case '1':
                        Thread.Sleep(200);

                        _answered = true;
                        Clear();
                        break;
                    case '2':
                        Thread.Sleep(200);

                        _answered = true;
                        Clear();
                        break;
                    case '3':
                        Thread.Sleep(200);

                        _answered = true;
                        Clear();
                        break;
                    default:
                        break;
                }
            }
            //-----------------------
        }

        // --------------------------------
        // 텍스트 출력 관련 함수
        // --------------------------------

        /// <summary>
        /// charDelay : 글자마다 대기(ms), 0이면 한 번에 출력
        /// afterDelayMs : 문장 출력 후 추가 대기(ms)
        /// newLine : true면 줄바꿈, false면 줄바꿈 없이 이어서 출력
        /// </summary>
        
        // 사용 예시 : PrintText("안녕하세요",25,1000,true);

        static void PrintText(string text, int charDelay = 0, int afterDelayMs = 0, bool newLine = true)
        {
            if (string.IsNullOrEmpty(text))
            {
                if (newLine) Console.WriteLine();
                return;
            }

            if (charDelay <= 0)
            {
                if (newLine) Console.WriteLine(text);
                else Console.Write(text);
            }
            else
            {
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }
                if (newLine) Console.WriteLine();
            }

            if (afterDelayMs > 0)
                Thread.Sleep(afterDelayMs);
        }

        // 줄바꿈 있는 버전
        static void PrintLine(string text, int charDelay = 0, int afterDelayMs = 0)
        {
            PrintText(text, charDelay, afterDelayMs, true);
        }

        // 줄바꿈 없는 버전
        static void PrintInline(string text, int charDelay = 0, int afterDelayMs = 0)
        {
            PrintText(text, charDelay, afterDelayMs, false);
        }
    }
}
