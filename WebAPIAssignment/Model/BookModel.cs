using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryAssignemnt;
using BookLibraryAssignemnt;

namespace WebAPIAssignment.Model
{
    public class BookModel
    {
        public static List<Book> BookList = new List<Book>()
        {
            new Book("They were none", "Agatha Christie", 203, "c84y2424ncmr2"),
            new Book("Murder at the vicariage", "Agatha Christie", 223, "c9825cmv25mp2"),
            new Book("Mathias Sandorf", "Jules Vernes", 950, "mc89p42wc48v5"),

        };

        public static Book GetBook(string isbn13)
        {
            Book book = BookList.FirstOrDefault(b => b.Isbn == isbn13);
            return book;
        }

        
    }
   
}
