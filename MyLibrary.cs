using System;

namespace Lab_work_3
{
    internal class MyLibrary
    {
        //private int[] mybook;
        private MyBooks[] books; // Масив для зберігання книг

        public void ArrProcessing()
        {
            int arraySize; //arraySize Локальна змінна для зберігання розміру масиву

            do
            {
                Console.Write("Введіть розмір масиву: ");
                if (int.TryParse(Console.ReadLine(), out arraySize) && arraySize > 0)
                {
                    try
                    {
                        books = new MyBooks[arraySize]; // Ініціалізуємо масив з заданим розміром
                        Console.WriteLine("Масив створено з розміром " + arraySize);
                    }
                    catch (OutOfMemoryException)
                    {
                        Console.WriteLine("Помилка: Недостатньо пам'яті для створення масиву такого розміру.");
                        arraySize = 0; // Скидаємо розмір масиву на нуль для повторного введення
                    }
                }
                else
                {
                    Console.WriteLine("Введіть коректний розмір більше 0 та не більше 2млрд.");
                }
            } while (arraySize <= 0);
            Console.Clear();
        }

        public int bookCount = 0; // Лічильник кількості книг

        public void AddBook(MyBooks book)
        {
            if (bookCount < books.Length)
            {
                books[bookCount] = book;
                bookCount++;
                Console.WriteLine("\nКнигу додано.");
            }
            else
            {
                Console.WriteLine("Масив книг заповнено. Неможливо додати більше книг.");
            }
        }

        public void ViewBooks()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("\nБібліотека порожня.");
            }
            else
            {
                for (int i = 0; i < bookCount; i++)
                {
                    Console.WriteLine($"Книга #{i + 1}");
                    Console.WriteLine($"Назва: {books[i].title}");
                    Console.WriteLine($"Автор: {books[i].author}");
                    Console.WriteLine($"Опис: {books[i].description}");
                    Console.WriteLine($"Кількість сторінок: {books[i].pages}");
                    Console.WriteLine($"Мова: {books[i].language}");
                    Console.WriteLine($"Рік видання: {books[i].yearOfPublication}");
                    Console.WriteLine($"Жанр: {books[i].genre}");
                    Console.WriteLine($"Тестова автовластивість: {books[i].autoProperties}");
                    Console.WriteLine($"Обчислювальна властивість: {books[i].TitleAndAuthor}");

                    Console.WriteLine();
                }
            }
        }
        public void ViewTitleBook()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("\nБібліотека порожня.");
            }
            else
            {
                for (int i = 0; i < bookCount; i++)
                {
                    Console.WriteLine($"Книга #{i + 1}");
                    Console.WriteLine($"Назва: {books[i].title}");
                    Console.WriteLine();
                }
            }
        }
        public void ViewReadBooks()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("\nКнижок немає!");
            }
            else
            {
                Console.WriteLine("\nПрочитані книги:");
                for (int i = 0; i < bookCount; i++)
                {
                    if (books[i].isRead)
                    {
                        Console.WriteLine($"Книга #{i + 1}: {books[i].title}");
                    }
                }
            }
        }

        public void ViewUnreadBooks()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("\nСпершу додайте книжки!");
            }
            else
            {
                Console.WriteLine("\nНепрочитані книги:");
                for (int i = 0; i < bookCount; i++)
                {
                    if (!books[i].isRead)
                    {
                        Console.WriteLine($"Книга #{i + 1}: {books[i].title}");
                    }
                }
            }
        }
        public void MarkBookAsRead(int index)
        {
            if (index >= 0 && index < bookCount)
            {
                books[index].MarkAsRead();
            }
            else
            {
                Console.WriteLine("Невірний номер книги.");
            }
        }

        public int[] FindBookCharacteristics(short? characteristicsPublication, string characteristicsLanguage)
        {
            int[] bookIndex = new int[bookCount];
            int matchingCount = 0;

            if (bookCount == 0)
            {
                Console.WriteLine("Бібліотека порожня.");
                return new int[0];  // Повернути пустий масив, оскільки немає збігів.
            }

            for (int i = 0; i < bookCount; i++)
            {
                if (books[i].yearOfPublication == characteristicsPublication || books[i].language == characteristicsLanguage)
                {
                    bookIndex[matchingCount] = i;
                    matchingCount++;
                }
            }

            if (matchingCount == 0)
            {
                Console.WriteLine("Не знайдено.");
                return new int[0];  // Повернути пустий масив, оскільки немає збігів.
            }

            // Вивести всі збіги після завершення пошуку.
            for (int i = 0; i < matchingCount; i++)
            {
                int index = bookIndex[i];
                Console.WriteLine($"Знайдено книгу: #{index + 1}");
                Console.WriteLine($"Назва: {books[index].title}");
                Console.WriteLine($"Автор: {books[index].author}");
                Console.WriteLine($"Опис: {books[index].description}");
                Console.WriteLine($"Кількість сторінок: {books[index].pages}");
                Console.WriteLine($"Мова: {books[index].language}");
                Console.WriteLine($"Рік видання: {books[index].yearOfPublication}");
                Console.WriteLine($"Жанр: {books[index].genre}");
                Console.WriteLine($"Тестова автовластивість: {books[index].autoProperties}");
                Console.WriteLine($"Обчислювальна властивість: {books[index].TitleAndAuthor}");
                Console.WriteLine();
            }

            return bookIndex;
        }

        public void RemoveBook(int index)
        {
            if (index >= 0 && index < bookCount)
            {
                for (int i = index; i < bookCount - 1; i++)
                {
                    books[i] = books[i + 1];
                }
                books[bookCount - 1] = null;
                bookCount--;
                Console.WriteLine($"Книгу #{index + 1} видалено.");
            }
            else
            {
                Console.WriteLine("Невірний індекс книги.");
            }
        }
    }
}
