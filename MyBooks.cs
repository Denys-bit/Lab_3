using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work_3
{
    internal class MyBooks
    {
        private string Title;
        private string Author;
        private string Description;
        private int Pages;
        private string Language;
        private short YearOfPublication;
        private Genre Genre;
        private bool IsRead;

        /// <summary>
        /// Конструктор без параметрів.
        /// </summary>
        public MyBooks()
        {

        }

        /// <summary>
        /// Конструктор з мінімальним набором параметрів, для створення потрібного об'єкту.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="yearOfPublication"></param>
        public MyBooks(string title, string author, short yearOfPublication)
        {
            Title = title;
            Author = author;
            YearOfPublication = yearOfPublication;
        }

        /// <summary>
        /// Основний конструктор.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="description"></param>
        /// <param name="pages"></param>
        /// <param name="language"></param>
        /// <param name="yearOfPublication"></param>
        /// <param name="genre"></param>
        /// <param name="isRead"></param>
        public MyBooks(string title, string author, string description, int pages, string language, short yearOfPublication, Genre genre, bool isRead) : this(title, author, yearOfPublication)
        {
            /*            Title = title;
                        Author = author; - звідси можна видалити, так як він, 
                        буде використовуватись з попереднього конструктору 
                        тим позбувшись дублікації коду в двох констр.*/
            Description = description;
            Pages = pages;
            Language = language;
            /*            YearOfPublication = yearOfPublication;*/
            Genre = genre;
            IsRead = isRead;
        }
        public void MarkAsRead()
        {
            IsRead = true;
        }

        public void MarkAsUnread()
        {
            IsRead = false;
        }

        public string autoProperties { get; } = "Значення за замовчуванням.";

        public string TitleAndAuthor
        {
            get { return $"Назва книги: {title}, Автор: {author}."; }
        }

        public string title
        {
            get { return Title; }
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Для поля \"Назва книжки\", заборонено використовувати кількість символів менше 3");
                Title = value;
            }
        }

        public string author
        {
            get { return Author; }
            set
            {
                if (value.Length < 5)
                    throw new ArgumentException("Для поля \"Автор\", заборонено використовувати кількість символів менше 5");
                Author = value;
            }
        }

        public string description
        {
            get { return Description; }
            set
            {
                if (value.Length < 15)
                    throw new ArgumentException("Для поля \"Опис\", заборонено використовувати кількість символів менше 15");
                Description = value;
            }
        }

        public string language
        {
            get { return Language; }
            set
            {
                if (value.Length < 2) // Наприклад uk (ukrainian)
                    throw new ArgumentException("Для поля \"Мова\", заборонено використовувати кількість символів менше 2");
                Language = value;
            }
        }

        public int pages
        {
            get { return Pages; }
            set
            {
                if (value <= 0)
                    throw new FormatException("Некоректна кількість сторінок. Тільки додатні цілі числа (Більше 0).");
                Pages = value;
            }
        }

        public short yearOfPublication
        {
            get { return YearOfPublication; }
            set
            {
                if (value < 1500 || value > 2023)
                    throw new FormatException("Некоректне введення року видання. Рік повинен бути не менше за 1500 та не більше за актуальний.");
                YearOfPublication = value;
            }
        }

        public Genre genre
        {
            get { return Genre; }
            set
            {
                Genre = value;
            }
        }

        public bool isRead
        {
            get { return IsRead; }
            set
            {
                IsRead = value;
            }
        }
    }
}