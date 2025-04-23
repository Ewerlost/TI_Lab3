using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    static class RSA
    {
        //Вычисляет количество взаимно простых чисел до n 
        public static int EulerPhi(int n)
        {

            int result = n; // Изначально присваиваем результату значение n

            // Перебираем все простые числа, которые делят n
            for (int p = 2; p * p <= n; ++p)
            {
                if (n % p == 0)
                {
                    // Если p делит n, уменьшаем result на result / p и на p - 1
                    while (n % p == 0)
                    {
                        n /= p;
                    }
                    result -= result / p;
                }
            }

            // Если n осталось простым, уменьшаем result на result / n
            if (n > 1)
            {
                result -= result / n;
            }

            return result;
        }

        public static bool IsProbablyPrime(int number, int k = 5)
        {
            if (number < 2) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0) return false;

            int d = number - 1;
            int s = 0;

            while ((d & 1) == 0)
            {
                d >>= 1;
                s++;
            }

            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                int a = rand.Next(2, number - 2);
                int x = QuickPowerMod(a, d, number);

                if (x == 1 || x == number - 1)
                    continue;

                bool isComposite = true;
                for (int r = 0; r < s - 1; r++)
                {
                    x = QuickPowerMod(x, 2, number);
                    if (x == number - 1)
                    {
                        isComposite = false;
                        break;
                    }
                }

                if (isComposite)
                    return false;
            }

            return true;
        }

        public static bool IsPrime(int number)
        {
            return IsProbablyPrime(number);
        }

        public static int FindGcd(int a, int b) => b == 0 ? a : FindGcd(b, a % b);

        public static (int gcd, int x, int y) ExtendedEuclidean(int a, int b)
        {
            // Инициализация начальных значений
            int x0 = 1, y0 = 0, x1 = 0, y1 = 1;
            int d0 = a, d1 = b; //поменять a и b местами для алгоритма по таблице

            while (d1 != 0)
            {
                // Вычисление остатка и частного
                int q = d0 / d1;
                int d2 = d0 % d1;
                int x2 = x0 - q * x1;
                int y2 = y0 - q * y1;

                // Обновление значений
                d0 = d1;
                d1 = d2;
                x0 = x1;
                x1 = x2;
                y0 = y1;
                y1 = y2;
            }

            if (y0 < 0) //Для RSA, не для рабина
            {
                y0 += a;
            }

            // Возвращаем НОД и коэффициенты x и y
            return (d0, x0, y0);
        }


        public static int QuickPowerMod(int num, int power, int mod)
        {
            long result = 1;
            long baseVal = num % mod;

            while (power > 0)
            {
                if ((power & 1) == 1)
                    result = (result * baseVal) % mod;
                baseVal = (baseVal * baseVal) % mod;
                power >>= 1;
            }

            return (int)result;
        }
    }
 }
