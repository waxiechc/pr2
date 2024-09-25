using System;
using System.Text.RegularExpressions;

class Program
{
    // Метод для перевірки коректності логіна
    static bool ValidateLogin(string login)
    {
        // Логін має бути від 2 до 10 символів, містити тільки літери і цифри, і не починатися з цифри
        Regex loginRegex = new Regex(@"^[A-Za-z][A-Za-z0-9]{1,9}$");
        return loginRegex.IsMatch(login);
    }

    // Метод для заміни визначених слів на нові
    static string ReplaceWords(string input)
    {
        // Створюємо масив слів для заміни і відповідних їм нових слів
        string[] targetWords = { "машина", "автомобіль", "авто" };
        string replacementWord = "транспорт";

        // Створюємо регулярний вираз, який замінить всі форми слова "машина", "автомобіль", "авто" на "транспорт"
        foreach (var word in targetWords)
        {
            string wordPattern = $@"\b{word}\b"; // пошук точного входження слова
            input = Regex.Replace(input, wordPattern, replacementWord, RegexOptions.IgnoreCase);
        }

        return input;
    }

    static void Main(string[] args)
    {
        // Приклад 1: Перевірка логіна
        Console.Write("Введiть логiн: ");
        string login = Console.ReadLine();

        if (ValidateLogin(login))
        {
            Console.WriteLine("Логiн коректний.");
        }
        else
        {
            Console.WriteLine("Логiн некоректний.");
        }

        // Приклад 2: Заміна слів
        Console.Write("Введiть речення для замiни слiв: ");
        string inputText = Console.ReadLine();

        string resultText = ReplaceWords(inputText);
        Console.WriteLine("Результат пiсля замiни: " + resultText);
    }
}