using System;

namespace Практическая_5
{
    /// <summary>
    /// Класс Triad описывает тройку целых чисел.
    /// В классе реализованы методы и перегруженные операции сложения:
    /// 1) триада + число;
    /// 2) число + триада;
    /// 3) триада + триада.
    /// </summary>
    public class Triad
    {
        /// <summary>
        /// Первое число триады.
        /// </summary>
        public int First { get; set; }

        /// <summary>
        /// Второе число триады.
        /// </summary>
        public int Second { get; set; }

        /// <summary>
        /// Третье число триады.
        /// </summary>
        public int Third { get; set; }

        /// <summary>
        /// Конструктор без параметров.
        /// Создаёт триаду (0; 0; 0).
        /// </summary>
        public Triad()
        {
            First = 0;
            Second = 0;
            Third = 0;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="first">Первое число.</param>
        /// <param name="second">Второе число.</param>
        /// <param name="third">Третье число.</param>
        public Triad(int first, int second, int third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        /// <summary>
        /// Метод сложения триады с числом.
        /// </summary>
        /// <param name="number">Число, которое прибавляется к каждому элементу триады.</param>
        /// <returns>Новая триада.</returns>
        public Triad Add(int number)
        {
            return this + number;
        }

        /// <summary>
        /// Перегруженный метод сложения двух триад.
        /// </summary>
        /// <param name="other">Вторая триада.</param>
        /// <returns>Новая триада.</returns>
        public Triad Add(Triad other)
        {
            return this + other;
        }

        /// <summary>
        /// Метод умножения триады на число.
        /// </summary>
        /// <param name="number">Множитель.</param>
        /// <returns>Новая триада.</returns>
        public Triad Multiply(int number)
        {
            return new Triad(
                First * number,
                Second * number,
                Third * number);
        }

        /// <summary>
        /// Проверка двух триад на равенство.
        /// </summary>
        /// <param name="other">Триада для сравнения.</param>
        /// <returns>true, если все элементы равны; иначе false.</returns>
        public bool IsEqual(Triad other)
        {
            if (other == null)
                return false;

            return First == other.First &&
                   Second == other.Second &&
                   Third == other.Third;
        }

        /// <summary>
        /// Операция сложения триады с числом.
        /// Каждый элемент триады увеличивается на заданное число.
        /// </summary>
        /// <param name="triad">Исходная триада.</param>
        /// <param name="number">Число для сложения.</param>
        /// <returns>Новая триада.</returns>
        public static Triad operator +(Triad triad, int number)
        {
            if (triad == null)
                throw new ArgumentNullException(nameof(triad));

            return new Triad(
                triad.First + number,
                triad.Second + number,
                triad.Third + number);
        }

        /// <summary>
        /// Операция сложения числа с триадой.
        /// Добавлена для удобства, чтобы можно было писать number + triad.
        /// </summary>
        /// <param name="number">Число для сложения.</param>
        /// <param name="triad">Исходная триада.</param>
        /// <returns>Новая триада.</returns>
        public static Triad operator +(int number, Triad triad)
        {
            return triad + number;
        }

        /// <summary>
        /// Операция сложения двух триад.
        /// Складываются соответствующие элементы:
        /// (a1; b1; c1) + (a2; b2; c2) = (a1 + a2; b1 + b2; c1 + c2).
        /// </summary>
        /// <param name="left">Первая триада.</param>
        /// <param name="right">Вторая триада.</param>
        /// <returns>Новая триада.</returns>
        public static Triad operator +(Triad left, Triad right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new Triad(
                left.First + right.First,
                left.Second + right.Second,
                left.Third + right.Third);
        }

        /// <summary>
        /// Формирование строки для вывода триады.
        /// </summary>
        /// <returns>Строковое представление триады.</returns>
        public override string ToString()
        {
            return $"({First}; {Second}; {Third})";
        }
    }
}