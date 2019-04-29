using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_var_2_CorrBracSeq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Правильная скобочная последовательность это (){}[] ");
            Console.WriteLine("или ({})[{}] или даже [{}({})]");
            Console.WriteLine("ВВЕДИТЕ НАБОР СКОБОК ДЛЯ ПРОВЕРКИ :");
            var s = Console.ReadLine();

            // Console.WriteLine("Вы ввели : " + s);

            var checker = new BracketsChecker();

            foreach (var ch in s)
                checker.Put(ch);

            if (checker.Balanced == true)
            {
                Console.WriteLine("Вы все слелали ПРАВИЛЬНО!");
            }
            else Console.WriteLine("Вы допустили ошибку!");

            Console.ReadKey();
        }

        class BracketsChecker
        {
            private readonly string _opening = "([{";
            private readonly string _closing = ")]}";

            private bool _cantBeBalanced;

            private Stack<int> _opened = new Stack<int>();

            public bool Balanced => !_cantBeBalanced && !_opened.Any();

            public void Put(char ch)
            {
                if (_cantBeBalanced) return;

                int index = _opening.IndexOf(ch);

                if (index != -1)
                {
                    _opened.Push(index);
                    return;
                }

                index = _closing.IndexOf(ch);

                if (index != -1)
                {
                    if (!_opened.Any() || _opened.Peek() != index)
                    {
                        _cantBeBalanced = true;
                        _opened.Clear();
                        _opened.TrimExcess();
                        return;
                    }

                    _opened.Pop();
                    return;
                }
            }

        }
    }
}

