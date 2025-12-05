using System;
using System.Threading;

namespace TextGame
{
    internal static class TextPrinter
    {
        public static void BufferClear()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        public static void PrintText(
            string text,
            int charDelay = 0,
            int afterDelayMs = 0,
            bool needClear = true,
            bool newLine = true)
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
                if (needClear)
                    Program.Clear();  // Program의 공용 Clear 사용
            }
        }

        public static void PrintLine(string text, int charDelay = 0, int afterDelayMs = 0)
            => PrintText(text, charDelay, afterDelayMs, true);

        public static void PrintInline(string text, int charDelay = 0, int afterDelayMs = 0)
            => PrintText(text, charDelay, afterDelayMs, false);
    }
}
