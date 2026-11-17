using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Book(Guid iD, string tutle, string description, decimal price)
        {
            ID = iD;
            Tutle = tutle;
            Description = description;
            Price = price;
        }

        public Guid ID { get; }
        public string Tutle { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Book Book, string Error) Create(Guid iD, string title, string description, decimal price)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length < MAX_TITLE_LENGTH)
            {
                error = "Title can not be longer then 250 symbols";
            }

            Book book = new Book(iD, title, description, price);

            return (book, error);

        }
    }
}
