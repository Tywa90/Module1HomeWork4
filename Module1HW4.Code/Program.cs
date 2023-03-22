namespace Module1HW4.Code
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Создание массива заданной длины
            int arrLength;
            InputFromUser(out arrLength);

            int[] arrIntRange = new int[arrLength];

            // Наполнение массива
            ArrayRandomizer(arrIntRange);

            DisplayArrayInt(arrIntRange);
            Console.WriteLine("--------------");

            // Подсчет положительных-отрицательных чисел
            int evenCounter;
            int oddCounter;

            EvenOddCounter(arrIntRange, out evenCounter, out oddCounter);

            // Создание массивов из положительных и отрицательных чисел
            int[] tempArrOdd = new int[arrIntRange.Length];
            int[] tempArrEven = new int[arrIntRange.Length];

            TempArrays(arrIntRange, out tempArrOdd, out tempArrEven);

            int[] arrEvenFinal = new int[evenCounter];
            int[] arrOddFinal = new int[oddCounter];

            EvenOrOddArrayCreate(tempArrEven, evenCounter, out arrEvenFinal);
            EvenOrOddArrayCreate(tempArrOdd, oddCounter, out arrOddFinal);

            DisplayArrayInt(arrEvenFinal);
            DisplayArrayInt(arrOddFinal);
            Console.WriteLine("--------------");

            // Создание массива char
            char[] arrEvenLetters = new char[arrEvenFinal.Length];
            char[] arrOddLetters = new char[arrOddFinal.Length];

            IntToCharArr(arrEvenFinal, out arrEvenLetters);
            IntToCharArr(arrOddFinal, out arrOddLetters);

            // A E I D H J
            int counterEven;
            int counterOdd;

            ReplaceToBigLetters(arrEvenLetters, arrEvenFinal, out counterEven);
            ReplaceToBigLetters(arrOddLetters, arrOddFinal, out counterOdd);

            CheckForMaxBigLetters();
            Console.WriteLine("--------------");

            DisplayArrayChars(arrEvenLetters);
            DisplayArrayChars(arrOddLetters);

            // Методы

            // Вывод массива на экран
            void DisplayArrayInt(int[] arr)
            {
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            void DisplayArrayChars(char[] arr)
            {
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            // Проверка ввода пользователя
            void InputFromUser(out int inputUser)
            {
                while (true)
                {
                    Console.Write("Введите размер создаваемого массива: ");
                    string? text = Console.ReadLine();
                    if (int.TryParse(text, out int number))
                    {
                        if (number <= 0)
                        {
                            Console.WriteLine("Введите положительное число");
                        }
                        else if (number != 0)
                        {
                            Console.WriteLine($"Будет создан массив длиной: {number}");
                            inputUser = number;
                            break;
                        }
                    }

                    Console.WriteLine("Не удалось распознать число, попробуйте еще раз.");
                }
            }

            // Наполнение массива случайными числами
            int[] ArrayRandomizer(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new Random().Next(1, 27);
                }

                return arr;
            }

            // Подсчет положительных и отрицательных чисел в массиве
            void EvenOddCounter(int[] arr, out int even, out int odd)
            {
                even = 0;
                odd = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        odd++;
                    }
                    else
                    {
                        even++;
                    }
                }

                if (even == 0)
                {
                    Console.WriteLine("Отсутсвуют четные числа в массиве.");
                }

                if (odd == 0)
                {
                    Console.WriteLine("Отсутсвуют нечетные числа в массиве.");
                }
            }

            // Перенос положительных и отрицательных чисел во временный массив
            void TempArrays(int[] arr, out int[] tempOdd, out int[] tempEven)
            {
                tempOdd = new int[arr.Length];
                tempEven = new int[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        tempArrOdd[i] = arr[i];
                    }
                    else
                    {
                        tempArrEven[i] = arr[i];
                    }
                }
            }

            // Создание массива нужной длины из положительных или отрицательных чисел
            void EvenOrOddArrayCreate(int[] arr, int counter, out int[] arrFinal)
            {
                arrFinal = new int[counter];
                int j = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != 0)
                    {
                        arrFinal[j] = arr[i];
                        j++;
                    }
                }
            }

            // Массив символов
            void IntToCharArr(int[] arr, out char[] charArr)
            {
                charArr = new char[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    charArr[i] = (char)(arr[i] + 96);
                }
            }

            // Буквы из списка заменяются на большие
            char[] ReplaceToBigLetters(char[] arr, int[] arrFinal, out int count)
            {
                char[] arrBigLetters = { 'a', 'e', 'i', 'd', 'h', 'j' };
                count = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arrBigLetters.Length; j++)
                    {
                        if (arr[i] == arrBigLetters[j])
                        {
                            arr[i] = (char)(arrFinal[i] + 64);
                            count++;
                        }
                    }
                }

                return arr;
            }

            // Проверка количества больших букв в массиве
            void CheckForMaxBigLetters()
            {
                if (counterEven > counterOdd)
                {
                    Console.WriteLine("В массиве с четными числами больше больших букв:");
                    DisplayArrayChars(arrEvenLetters);
                }
                else if (counterEven < counterOdd)
                {
                    Console.WriteLine("В массиве с нечетными числами больше больших букв:");
                    DisplayArrayChars(arrOddLetters);
                }
                else if (counterEven == 0 && counterOdd == 0)
                {
                    Console.WriteLine("Большие буквы отсутствуют в массивах");
                }
                else if (counterEven == counterOdd)
                {
                    Console.WriteLine("Одинаковое количество больших букв в массивах");
                }
                else
                {
                    Console.WriteLine("Неучтенное условие");
                }
            }
        }
    }
}
