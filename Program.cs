using System;

class Program
{
    static void Main()
    {
        const int numberOfLines = 7;
        string[] lines = new string[numberOfLines];

        // Ввод строк
        for (int i = 0; i < numberOfLines; i++)
        {
            Console.WriteLine($"Введите строку {i + 1}:");
            lines[i] = Console.ReadLine();
        }

        // Переменные для поиска строки с наименьшим числом пробелов
        int minSpacesCount = int.MaxValue;
        int lineWithMinSpaces = -1;

        Console.WriteLine("\nСтроки, содержащие слова, оканчивающиеся на '.com':");

        for (int i = 0; i < numberOfLines; i++)
        {
            string currentLine = lines[i];
            int spacesCount = 0;
            bool hasComWord = false;
            string currentWord = "";

            // Обработка строки как массива символов
            for (int j = 0; j < currentLine.Length; j++)
            {
                char currentChar = currentLine[j];

                // Если текущий символ - пробел
                if (currentChar == ' ')
                {
                    spacesCount++;
                    if (currentWord.Length > 0)
                    {
                        // Проверяем, заканчивается ли слово на ".com"
                        if (currentWord.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
                        {
                            hasComWord = true;
                        }
                        currentWord = ""; // Сбрасываем текущее слово
                    }
                }
                else
                {
                    currentWord += currentChar; // Собираем текущее слово
                }
            }

            // Проверка последнего слова в строке
            if (currentWord.Length > 0 && currentWord.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
            {
                hasComWord = true;
            }

            // Вывод строки, если содержит слово на ".com"
            if (hasComWord)
            {
                Console.WriteLine(currentLine);
            }

            // Проверка наименьшего числа пробелов
            if (spacesCount < minSpacesCount)
            {
                minSpacesCount = spacesCount;
                lineWithMinSpaces = i + 1; // Номер строки (1-индексация)
            }
        }

        // Вывод номера строки с наименьшим числом пробелов
        Console.WriteLine($"\nНомер строки с наименьшим числом пробелов: {lineWithMinSpaces}");
    }
}