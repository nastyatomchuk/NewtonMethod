using System;

namespace NewtonsMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Задаем начальное приближение и точность
                double xn = 1.5;
                double eps = 1e-6;

                // Вычисляем корень уравнения
                double root = NewtonsMethod(MyFunction, MyDerivative, xn, eps);

                Console.WriteLine("Найденный корень: " + root);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.ReadLine();
        }

        // Функция, для которой ищем корень
        static double MyFunction(double x)
        {
            return x * x - 4; // Пример уравнения: x^2 - 4 = 0
        }

        // Производная функции
        static double MyDerivative(double x)
        {
            return 2 * x; // Производная уравнения: 2x
        }

        // Метод Ньютона
        static double NewtonsMethod(Func<double, double> f, Func<double, double> df, double xn, double eps)
        {
            double x1 = xn - f(xn) / df(xn);
            double x0 = xn;

            while (Math.Abs(x0 - x1) > eps)
            {
                x0 = x1;
                x1 = x1 - f(x1) / df(x1);

                // Проверка на деление на ноль
                if (Math.Abs(df(x1)) < eps)
                {
                    throw new Exception("Деление на ноль. Невозможно найти корень.");
                }
            }

            return x1;
        }
    }
}
