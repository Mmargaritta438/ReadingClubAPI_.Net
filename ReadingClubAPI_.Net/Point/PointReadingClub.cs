using System;

namespace ReadingClubSPI_.Net.Point
{
    public class PointReadingClub
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter the number of books purchased
            // Предложить пользователю ввести количество купленных книг
            Console.Write("Enter the number of books purchased this month: ");

            // Read the input from the user and convert it to an integer
            // Читаем введенные пользователем данные и преобразуем их в целое число
            int numberOfBooks = Convert.ToInt32(Console.ReadLine());

            // Calculate the points based on the number of books purchased
            // Подсчитайте баллы в зависимости от количества купленных книг
            int points = CalculatePoints(numberOfBooks);

            // Display the points awarded
            // Отображение начисленных баллов
            Console.WriteLine("Points awarded: " + points);

            // Wait for the user to press a key before exiting
            // Подождите, пока пользователь нажмет клавишу, прежде чем выйти
            Console.ReadKey();
        }

        // Function to calculate points based on the number of books purchased
        // Функция расчета баллов в зависимости от количества купленных книг
        static int CalculatePoints(int numberOfBooks)
        {
            if (numberOfBooks == 0)
            {
                return 0;
            }
            else if (numberOfBooks == 1)
            {
                return 5;
            }
            else if (numberOfBooks == 2)
            {
                return 15;
            }
            else if (numberOfBooks == 3)
            {
                return 30;
            }
            else
            {
                return 60;
            }
        }
    }
}
