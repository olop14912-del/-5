using System;
using System.Windows;
using Практическая_5;

namespace Практическая_5
{
    /// <summary>
    /// Главное окно программы.
    /// Содержит демонстрацию работы перегруженных операций класса Triad.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки сложения триады A с числом.
        /// Демонстрирует операцию: Triad + int.
        /// </summary>
        private void BtnAddNumber_Click(object sender, RoutedEventArgs e)
        {
            Triad triadA;
            int number;

            // Считываем триаду A.
            if (!TryReadTriad(TxtA1.Text, TxtA2.Text, TxtA3.Text, "A", out triadA))
                return;

            // Считываем число.
            if (!TryReadInt(TxtNumber.Text, "число", out number))
                return;

            // Используем перегруженную операцию сложения триады с числом.
            Triad result = triadA + number;

            // Выводим результат.
            TxtResult.Text =
                "Операция сложения триады с числом:\n" +
                $"{triadA} + {number} = {result}\n\n" +
                "Каждый элемент триады увеличен на заданное число.";
        }

        /// <summary>
        /// Обработчик кнопки сложения двух триад.
        /// Демонстрирует операцию: Triad + Triad.
        /// </summary>
        private void BtnAddTriads_Click(object sender, RoutedEventArgs e)
        {
            Triad triadA;
            Triad triadB;

            // Считываем первую триаду.
            if (!TryReadTriad(TxtA1.Text, TxtA2.Text, TxtA3.Text, "A", out triadA))
                return;

            // Считываем вторую триаду.
            if (!TryReadTriad(TxtB1.Text, TxtB2.Text, TxtB3.Text, "B", out triadB))
                return;

            // Используем перегруженную операцию сложения двух триад.
            Triad result = triadA + triadB;

            // Выводим результат.
            TxtResult.Text =
                "Операция сложения двух триад:\n" +
                $"{triadA} + {triadB} = {result}\n\n" +
                "Складываются соответствующие элементы двух триад.";
        }

        /// <summary>
        /// Обработчик кнопки очистки результата.
        /// </summary>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Clear();
        }

        /// <summary>
        /// Обработчик кнопки "О программе".
        /// Выводит ФИО разработчика, номер работы и формулировку задания.
        /// </summary>
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"Разработчик: Клейменов Никита \n\n" +
                "Практическая работа №5\n" +
                "Задание:\n" +
                "Использовать класс Triad (тройка чисел). " +
                "Разработать операцию для сложения триады с числом. " +
                "Разработать операцию для сложения элементов одной триады с другой триадой.",
                "О программе",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        /// <summary>
        /// Обработчик кнопки "Выход".
        /// Закрывает программу.
        /// </summary>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Метод считывания триады из трёх строковых значений.
        /// </summary>
        /// <param name="firstText">Строка с первым числом.</param>
        /// <param name="secondText">Строка со вторым числом.</param>
        /// <param name="thirdText">Строка с третьим числом.</param>
        /// <param name="triadName">Название триады для сообщения об ошибке.</param>
        /// <param name="triad">Созданная триада.</param>
        /// <returns>true, если триада считана успешно; иначе false.</returns>
        private bool TryReadTriad(
            string firstText,
            string secondText,
            string thirdText,
            string triadName,
            out Triad triad)
        {
            triad = null;

            int first;
            int second;
            int third;

            if (!TryReadInt(firstText, $"первый элемент триады {triadName}", out first))
                return false;

            if (!TryReadInt(secondText, $"второй элемент триады {triadName}", out second))
                return false;

            if (!TryReadInt(thirdText, $"третий элемент триады {triadName}", out third))
                return false;

            triad = new Triad(first, second, third);
            return true;
        }

        /// <summary>
        /// Метод проверки и преобразования строки в целое число.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <param name="fieldName">Название поля для сообщения об ошибке.</param>
        /// <param name="value">Полученное целое число.</param>
        /// <returns>true, если число считано успешно; иначе false.</returns>
        private bool TryReadInt(string text, string fieldName, out int value)
        {
            if (!int.TryParse(text, out value))
            {
                MessageBox.Show(
                    $"Ошибка ввода: поле \"{fieldName}\" должно содержать целое число.",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return false;
            }

            return true;
        }
    }
}