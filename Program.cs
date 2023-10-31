using System;
using System.Text;

namespace Lab_work_3
{
    internal class Program
    {
        static void Main()
        {

            Console.OutputEncoding = Encoding.UTF8;

            MyLibrary library = new MyLibrary();

            library.ArrProcessing();

            while (true)
            {
                Console.WriteLine(" 1 — Додати книгу");
                Console.WriteLine("  -1 - Додати книгу (Більш коротку)");
                Console.WriteLine("  -2 - Додати книгу (З дефолтними значеннями)");
                Console.WriteLine(" 2 — Переглянути книги");
                Console.WriteLine(" 3 — Видалити книгу");
                Console.WriteLine(" 4 — Додати прочитану книгу: ");
                Console.WriteLine(" 5 — Список прочитаних книжок: ");
                Console.WriteLine(" 6 — Список непрочитаних книжок: ");
                Console.WriteLine(" 0 — Вийти з програми");

                Console.Write("\nВиберіть дію: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            MyBooks book = new MyBooks("Назва", "Автор", "Опис", 0, "", 0, 0, false);
                            bool inputIsValidTitle = true;

                            while (inputIsValidTitle)
                            {
                                try
                                {
                                    Console.Write("\nНазва книжки: ");
                                    book.title = Console.ReadLine();
                                    inputIsValidTitle = false; // Помилка відсутня;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidTitle = true;
                                }
                            }

                            bool inputIsValidAuthor = true;

                            while (inputIsValidAuthor)
                            {
                                try
                                {
                                    Console.Write("Автор: ");
                                    book.author = Console.ReadLine();
                                    inputIsValidAuthor = false;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidAuthor = true;
                                }
                            }

                            bool inputIsValidDescription = true;

                            while (inputIsValidDescription)
                            {
                                try
                                {
                                    Console.Write("Опис: ");
                                    book.description = Console.ReadLine();
                                    inputIsValidDescription = false;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidDescription = true;
                                }
                            }

                            bool inputIsValidLanguage = true;

                            while (inputIsValidLanguage)
                            {
                                try
                                {
                                    Console.Write("Мова: ");
                                    book.language = Console.ReadLine();
                                    inputIsValidLanguage = false;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidLanguage = true;
                                }
                            }

                            bool inputIsValidPages = true;

                            while (inputIsValidPages)
                            {
                                try
                                {
                                    Console.Write("Кількість сторінок: ");
                                    book.pages = int.Parse(Console.ReadLine()); ;
                                    inputIsValidPages = false;
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidPages = true;
                                }
                            }

                            bool inputIsValidPublication = true;

                            while (inputIsValidPublication)
                            {
                                try
                                {
                                    Console.Write("Рік видання: ");
                                    book.yearOfPublication = short.Parse(Console.ReadLine());
                                    inputIsValidPublication = false;
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidPublication = true;
                                }
                            }

                            bool inputIsValidGenre = true;

                            while (inputIsValidGenre)
                            {
                                try
                                {
                                    Console.WriteLine("\nНаявні жанри книг: ");
                                    foreach (Genre genre1 in Enum.GetValues(typeof(Genre)))
                                    {
                                        Console.WriteLine($"{(int)genre1}. {genre1}");
                                    }

                                    Console.Write("Ваш вибір: ");
                                    if (Enum.TryParse(Console.ReadLine(), false, out Genre genre))
                                    {
                                        if (Enum.IsDefined(typeof(Genre), genre))
                                        {
                                            inputIsValidGenre = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Такого жанру не існує");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неправильний формат вводу. Введіть ціле число.");
                                    }
                                    book.genre = genre;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidGenre = true;
                                }
                            }
                            library.AddBook(new MyBooks(book.title, book.author, book.description, book.pages, book.language, book.yearOfPublication, book.genre, book.isRead));
                            break;
                        case -1:
                            MyBooks book1 = new MyBooks("Назва книги", "Автор", 0);

                            bool inputIsValidTitle1 = true;
                            while (inputIsValidTitle1)
                            {
                                try
                                {
                                    Console.Write("\nНазва книжки: ");
                                    book1.title = Console.ReadLine();
                                    inputIsValidTitle1 = false; // Помилка відсутня;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidTitle1 = true;
                                }
                            }

                            bool inputIsValidAuthor1 = true;


                            while (inputIsValidAuthor1)
                            {
                                try
                                {
                                    Console.Write("Автор: ");
                                    book1.author = Console.ReadLine();
                                    inputIsValidAuthor1 = false;
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidAuthor1 = true;
                                }
                            }

                            bool inputIsValidPublication1 = true;

                            while (inputIsValidPublication1)
                            {
                                try
                                {
                                    Console.Write("Рік видання: ");
                                    book1.yearOfPublication = short.Parse(Console.ReadLine());
                                    inputIsValidPublication1 = false;
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    inputIsValidPublication1 = true;
                                }
                            }

                            library.AddBook(new MyBooks(book1.title, book1.author, "Опис", 0, "Мова", book1.yearOfPublication, Genre.Other, false));
                            break;
                        case -2:
                            MyBooks myBooks = new MyBooks();
                            myBooks.description = "Використання пустого конструктору";
                            library.AddBook(new MyBooks("Назва книги", "Автор...", myBooks.description, 0, "Українська", 0, Genre.Other, false));
                            break;
                        case 2:
                            library.ViewBooks();
                            break;
                        case 3:
                            if (library.bookCount >= 1)
                            {
                                Console.Write("Введіть номер книги для видалення: ");
                                if (int.TryParse(Console.ReadLine(), out int removeIndex))
                                {
                                    library.RemoveBook(removeIndex - 1);
                                }
                                else
                                {
                                    Console.WriteLine("Невірний номер.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nВидалення неможливо! Додайте хоч 1 книжку.");
                            }
                            break;
                        case 4:
                            if (library.bookCount >= 1)
                            {
                                library.ViewTitleBook();
                                Console.WriteLine("Введіть номер книги, яку бажаєте позначити як \"прочитану\"");

                                if (int.TryParse(Console.ReadLine(), out int readIndex))
                                {
                                    if (readIndex >= 1 && readIndex <= library.bookCount)
                                    {
                                        library.MarkBookAsRead(readIndex - 1);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Невірний номер книги.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некоректний формат номера книги.");
                                }
                            }
                            else if (library.bookCount == 0)
                            {
                                Console.WriteLine("\nНеможливо додати прочитану книжку, якої не існує!");
                            }
                            break;
                        case 5:
                            library.ViewReadBooks();
                            break;
                        case 6:
                            library.ViewUnreadBooks();
                            break;
                        case 0:
                            Environment.Exit(0); // Повертає або задає код виходу із процесу.
                            break;
                        default:
                            Console.WriteLine("\nНевірний вибір.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nНевірний вибір.");
                }
            }
        }
    }
}
