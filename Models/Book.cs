using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class Book
    {
        public Book(string title, string author, string iSBN, int publishYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublishYear { get; private set; }

        public void Add(string title, string author, string iSBN, int publishYear)
        {
            Id = new Random().Next(1, 1000);
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishYear = publishYear;
        }
    }
}