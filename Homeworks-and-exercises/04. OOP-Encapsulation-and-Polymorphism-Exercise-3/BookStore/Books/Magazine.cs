using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Interfaces;

namespace BookStore.Books
{
    class Magazine : IBook
    {
        public Magazine(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
    }
}
