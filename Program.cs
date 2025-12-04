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

            Console.SetCursorPosition(75, 4);
            double _ratio = (double)_currentHp / _maxHp;
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

        // 게임 시작
        static void GameStart()
        {
            PrintText("안녕하세요", 35, 1000, true, false);

            PrintText("시작하기 전에, 간단한 질문 몇 가지만 부탁드립니다.", 35, 2000, true, false);

            int _gotMad = 0;
            bool _loopAsk = false;

            while (!_loopAsk)
            {
                PrintText("성별이 어떻게 되시나요?", 35, 1000, false, true);

                PrintText(" 1. 남성", 15, 200, false, true);

                Console.SetCursorPosition(_cursorX + 1, _cursorY + 2);
                PrintText("2. 여성", 15, 200, false, true);

                Console.SetCursorPosition(_cursorX + 1, _cursorY + 3);
                PrintText("3. 그 외", 15, 200, false, true);

                Console.SetCursorPosition(_cursorX + 1, _cursorY + 5);
                PrintText("※ 해당하는 숫자키를 누름으로써 답변할 수 있습니다.", 25, 0, false, false);

                BufferClear();

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Clear();

                PrintText("", 0, 1500, false, false); // 그냥 텀만 유지

                switch (_insert.KeyChar)
                {
                    case '1':
                        PrintText("감사합니다.", 35, 1000, true, false);
                        _loopAsk = true;
                        _playerGender = "male";
                        break;

                    case '2':
                        PrintText("감사합니다.", 35, 1000, true, false);
                        _loopAsk = true;
                        _playerGender = "female";
                        break;

                    case '3':
                        PrintText("음.", 35, 500, true, false);
                        PrintText("알겠습니다.", 35, 1000, true, false);
                        _loopAsk = true;
                        _playerGender = "another";
                        break;

                    default:
                        if (_gotMad == 1)
                        {
                            PrintText("하하..", 35, 500, true, false);

                            PrintText("다시해주세요.", 35, 500, true, false);
                            _gotMad += 1;
                            break;
                        }

                        if (_gotMad == 2)
                        {
                            Clear();
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            PrintText("마지막 기회다.", 35, 500, true, false);

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            PrintText("장난치지마라.", 35, 1500, true, false);
                            _gotMad += 1;
                            break;
                        }

                        if (_gotMad == 3)
                        {
                            Thread.Sleep(200);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            for (int i = 0; i < 50; i++)
                            {
                                _playerName = "DELETED";
                                _level = 0;
                                TakeDamage(2);
                                PrintText("DELETE", 15, 10, true, true);
                            }
                            Environment.Exit(0);
                        }

                        PrintText("잘못된 입력입니다.", 35, 500, true, false);

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for (int i = 0; i < 25; i++)
                        {
                            PrintText("'1,2,3'중 하나만 눌러", 0, 2, false, true);
                        }

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Clear();

                        PrintText(".", 35, 0, false, true);
                        PrintText(".", 35, 0, false, true);
                        PrintText(".", 35, 500, true, true);

                        Clear();
                        PrintText("다시해주세요.", 35, 300, true, false);
                        _gotMad += 1;
                        break;
                }
            }

            _loopAsk = false;

            PrintText("다음.", 35, 700, true, false);

            bool _askingName = false;

            while (!_askingName)
            {
                BufferClear();

                Clear();
                PrintText("이름이 어떻게 되시나요?", 35, 1200, false, true);

                PrintText("당신의 이름을 입력하세요 : ", 35, 0, false, false);
                _playerName = Console.ReadLine();

                Clear();
                PrintText(_playerName + ".", 35, 1500, true, false);

                PrintText("이게 정말 당신의 이름이 맞나요?", 35, 300, false, false);

                PrintText("\n 1. Yes \n 2. No", 25, 0, false, true);

                BufferClear();

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                Clear();

                switch (_insert.KeyChar)
                {
                    case '1':
                        PrintText("네," + _playerName + ".", 35, 1000, true, false);

                        PrintText("좋은 이름이네요.", 35, 1000, true, false);

                        _askingName = true;
                        Clear();
                        break;

                    case '2':
                        _playerName = "";
                        Clear();
                        PrintText("그럼 바꿀 기회를 드리죠.", 35, 1100, true, false);
                        break;
                }
            }

            PrintText(_playerName + ".", 35, 300, true, false);

            for (int i = 0; i < 3; i++)
            {
                PrintText(".", 35, 200, false, false);
            }

            Clear();
            PrintText("..흠 이것만 물을게요.", 35, 1100 + 1000, true, false);

            bool ageOk = false;

            while (!ageOk)
            {
                Clear();
                PrintText("당신의 나이를 입력하세요 : ", 35, 0, false, false);

                BufferClear();

                string ageInput = Console.ReadLine();

                if (!int.TryParse(ageInput, out _age))
                {
                    Clear();
                    PrintText("다시해주세요. (숫자만 입력해주세요 ※너무 큰 숫자도 안됩니다.)", 15, 1700, true, false);
                    continue;
                }

                Clear();

                if (_age <= 10)
                {
                    //미성년자를 위한 게임은 없다!!!
                    PrintText("진심인가요?", 35, 400, false, true);
                    PrintText("구", 35, 200, false, true);
                    PrintText("구", 35, 200, false, true);
                    PrintText("가", 35, 200, false, true);
                    PrintText("가", 35, 200, false, true);
                    PrintText("?", 35, 1200, false, true);
                    PrintText("전 이 세계를 어린아이에게 보여주진 못하겠네요.", 35, 1700, true, false);
                    Clear();
                    Environment.Exit(0);
                }
                else if (_age > 0 && _age <= 20)
                {
                    PrintText("젊으시네요.", 35, 800, true, false);
                    Clear();
                    ageOk = true;
                }
                else if (_age > 100)
                {
                    PrintText("믿기지 않네요.", 35, 1100, true, false);
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
            
            // ---------------- 특정 인물 감지 구간 ----------------
            if (_age == 24 && (_playerName == "Keres" || _playerName == "케레스" || _playerName == "에단" || _playerName == "Edan") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();

                PrintText("왜 다시 왔는가", 40, 800, true, false);

                PrintText("그때의 소멸은 그녀도 알고있던 예견된 일", 40, 800, true, false);
                PrintText("다시 되돌릴 수는 없다", 40, 800, true, false);

                TakeDamage(10f);
                PrintText("", 0, 1500, false, true);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
            }

            if (_age == 25 && (_playerName == "Katz" || _playerName == "카츠") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();

                PrintText("그를 따라하는구나", 50, 800, true, false);
                PrintText("넌 그가 세운 계획의 협력자인가?", 40, 800, true, false);
                PrintText("앞으로의 길에 불행이 가득하기를", 60, 800, true, false);

                TakeDamage(50f);
                PrintText("", 0, 800, false, true);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
            }

            if (_age == 25 && (_playerName == "Lev" || _playerName == "레브") && _playerGender == "male")
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Clear();

                PrintText("그를 따라하는구나", 50, 800, true, false);
                PrintText("내 뜻을 거역하는것인가", 45, 800, true, false);
                PrintText("우리의 세계에 있어 그는 절대악일터", 50, 1000, true, false);

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

                PrintText("그것을 따라하는구나", 50, 300, true, false);
                PrintText("카스티지움은", 40, 800, true, false);
                PrintText("다른 시간선의 자신을 껄끄러워하지", 35, 800, true, false);
                PrintText("개명하는 것이 좋을거다", 50, 800, true, false);

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

                PrintText("...", 1000, 1000, true, false);
                PrintText("'그'와 나를.", 50, 1000, true, false);
                PrintText("모욕하려 드는군.", 90, 1500, true, false);

                TakeDamage(75f);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
            }

            for (int i = 0; i < 3; i++)
            {
                PrintText(".", 35, 100, false, true);
            }

            Clear();

            PrintText("확인했습니다.", 35, 1000, true, false);

            Console.ForegroundColor = ConsoleColor.White;
            Clear();

            PrintText("환영합니다", 35, 1000, true, false);
            PrintText("눈을 뜨십시오.", 35, 1000 + 500, true, false);
        }



        static void TutorialScenario()
        {
            
            PrintText("", 0, 1000, true, false); 

            PrintText("새하얀 공간에서 눈을 떴다.", 35, 2000, true, false);
            PrintText("원목의 냄새와 희미한 꽃향이 코를 간지럽힌다.", 35, 2500, true, false);
            PrintText("내 이름은-", 35, 2300, true, false);
            PrintText(_playerName + ". 기억났다.", 35, 2000, true, false);
            PrintText("분명 나는 아까-", 35, 1700, true, false);

            
            PrintText("1. (기억이 나지 않아 말을 삼킨다.) \n2. (무언가에 열중하고 있었다.)\n3. (특별함 없이 살아가고 있었다.)",
                      35, 0, false, false);

            bool _answered = false;

            while (!_answered)
            {
                BufferClear();

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                switch (_insert.KeyChar)
                {
                    case '1':
                        Clear();
                        PrintText("", 0, 200, false, false);      
                        PrintText("...", 35, 1000, true, false); 
                        _answered = true;
                        break;

                    case '2':
                        Clear();
                        PrintText("", 0, 200, false, false);
                        PrintText("무엇인진 잊어버렸지만..", 35, 1600, true, false);
                        _answered = true;
                        break;

                    case '3':
                        Clear();
                        PrintText("", 0, 200, false, false);
                        PrintText("여긴 어디지..?", 35, 1700, true, false);
                        _answered = true;
                        break;

                    default:
                        break;
                }
            }

            _answered = false;

            Clear();
            PrintText("\"(야!)\"", 35, 700, true, false);
            PrintText($"\"(네 차례야! {_playerName}!)\"", 35, 2000, true, false);
            PrintText("(옆자리에 있던 한 아이가 내게 은밀히 주의를 주었다.)", 35, 2000, true, false);

            PrintText("(고개를 아래로 내리자,)", 35, 1100, true, false);
            PrintText("(손에는 처음보는 교본이 쥐어져있었다.)", 35, 2000, true, false);
            PrintText("(그때, 교탁으로 보이는 곳에서 선생님으로 추정되는 이가 입을 열었다.)", 35, 3500, true, false);
            PrintText($"\"24열 8번 문항, 정답이 뭐였죠 {_playerName}?\"", 35, 3500, true, false);
            PrintText("(펄럭이는 종잇장 소리들속에서 나는 질문에 대한 대답을 강요받는다.)", 35, 4000, true, false);

            PrintText("1. 아무 답이나 내뱉는다\n2. 물어본다\n3. 이 세계에서 내보내달라 소리친다",
                      35, 0, false, false);

            while (!_answered)
            {
                BufferClear();

                ConsoleKeyInfo _insert = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                switch (_insert.KeyChar)
                {
                    case '1':
                        Clear();
                        PrintText("", 0, 200, false, false);
                        PrintText("...", 35, 1000, true, false);
                        PrintText("\"3번?\"", 35, 1000, true, false);
                        PrintText("내 목소리가 교실의 정적을 깼다.", 35, 1500, true, false);
                        PrintText("오답이라는 말과 함께 나는 어느새 주변 아이들의 웃음거리가 되어있었다.", 35, 2500, true, false);
                        _answered = true;
                        break;

                    case '2':
                        Clear();
                        PrintText("", 0, 200, false, true);
                        PrintText("\"(정답이 뭔지 알아?)\"", 35, 1200, true, false);
                        PrintText("\"(뭐?)\"", 35, 900, true, false);
                        PrintText("아이가 어이없다는 듯이 물었다.", 35, 1400, true, false);
                        PrintText("\"(하.. 이번만이다)\"", 35, 1600, true, false);
                        PrintText("\"(4, 루트)\"", 35, 1200, true, false);
                        _divine++;
                        PrintText("나는 그대로 대답하였고, 주변의 놀라는 반응과 함께 위기는 넘어가졌다.", 35, 2500, true, false);
                        _answered = true;
                        break;

                    case '3':
                        Clear();
                        PrintText("", 0, 200, false, false);
                        PrintText("나는 자리를 박차고 일어났다.", 35, 1300, true, false);
                        PrintText("순식간에 모든 시선이 내 표피에 꽃힌다.", 35, 2000, true, false);
                        PrintText("\"ㅇ-여긴 어디야!\"", 35, 1500, true, false);
                        PrintText("옆자리 아이의 눈동자엔 사회에 섞이지 못한 정신이상자가 비춰지고 있었다.", 35, 3000, true, false);

                        PrintText("", 0, 100, false, false);
                        PrintText("\"-..날 어서 여기서 꺼내줘!", 35, 0, false, false);
                        for (int i = 0; i < 5; i++)
                        {
                            PrintText("!", 0, 110, false, false);
                        }
                        PrintText("\"", 35, 1600, true, false);

                        PrintText("\"지", 35, 170, false, false);
                        PrintText("랄", 35, 160, false, false);
                        PrintText(" 말", 35, 100, false, false);
                        PrintText("라", 35, 70, false, false);
                        PrintText("ㄱ-", 35, 60, false, false);

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Clear();
                        PrintText("너", 35, 2500, true, false);
                        PrintText(_playerName + ".", 35, 2500, true, false);
                        PrintText("멋대로 행동하지마라.", 35, 0, true, false);

                        for (int i = 0; i < 10; i++)
                        {
                            PrintText("", 0, 500, false, false);
                            TakeDamage(2f);
                            Clear();
                        }

                        PrintText("", 0, 500, false, false);
                        PrintText("흐름에 동조해라.", 35, 1500, true, false);
                        PrintText("그럼 탈출을 도와주지.", 35, 0, true, false);

                        for (int i = 0; i < 10; i++)
                        {
                            PrintText("", 0, 500, false, true);
                            Clear();
                            Heal(2f);
                        }

                        PrintText("", 0, 500, false, false);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Clear();

                        PrintText("아이들이 수근거린다.", 35, 1300 + 3000, true, false);
                        PrintText("그리고 난 지금 상황을 이해했다.", 35, 3000, true, false);
                        PrintText("내 시간이 되돌려졌구나.", 35, 3000, true, false);

                        _answered = true;
                        break;

                    default:
                        break;
                }
            }
        }

        static void BufferClear()
        {
            // 버퍼 클리어
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
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

        // 텍스트 출력 관련 함수
        // --------------------------------

        /// <summary>
        /// charDelay : 글자마다 대기(ms), 0이면 한 번에 출력
        /// afterDelayMs : 문장 출력 후 추가 대기(ms), 이후 클리어
        /// newLine : true면 줄바꿈, false면 줄바꿈 없이 이어서 출력
        
        // 사용 예시 : PrintText("안녕하세요",25,1000,true,true);

        static void PrintText(string text, int charDelay = 0, int afterDelayMs = 0, bool needClear = true ,bool newLine = true)
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
            {
                Thread.Sleep(afterDelayMs);
                if (needClear) Clear();
            }
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
