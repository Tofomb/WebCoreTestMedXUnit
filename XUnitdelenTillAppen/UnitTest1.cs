using System;
using WebCoreTestMedXUnit;
using Xunit;
using Moq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace XUnitdelenTillAppen
{
    public class UnitTest1
    {



     

        [Fact]
        public void How_Many_Books_Are_Registerd()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Title = "title", Author = "author" });
            books.Add(new Book { Title = "Bilbo", Author = "The Hobbit" });

            var mock = new Mock<IApiRequestSend<Book>>();
            mock.Setup(m => m.GetAllData()).Returns(books);
            var mockObj = mock.Object;
            var booklist = mockObj.GetAllData();
            var numberofBooks = booklist.Count();

            Assert.True(numberofBooks == books.Count);
        }


        [Theory]
        [InlineData("Tolkien", "J.R.R Tolkien")]
        [InlineData("Saibot", "Tobias")]
        public void ModifyAuthorName(string AuthorName, string NewName)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Id = 2, Title = "title", Author = "author" });
            books.Add(new Book { Id = 3, Title = "Bilbo", Author = "Tolkien" });
            books.Add(new Book { Id= 4, Title = "Lord of the rings", Author = "Tolkien" });
            var bookCounter = books.Where(m => m.Author == AuthorName).Count();

            var mock = new Mock<IApiRequestSend<Book>>();
            mock.Setup(m => m.GetAllData()).Returns(books);
            var mockObj = mock.Object;

            var booklist = mockObj.GetAllData();
            var selectedAuthorList = booklist.Where(m => m.Author == AuthorName);

            int counter = 0;

            foreach (var book in selectedAuthorList)
            {
                book.Author = NewName;
                mockObj.ModifyEntity(book.Id, book);
                counter++;
            }
           
            Assert.True(counter == bookCounter);
          
        }

        [Theory]
        [InlineData(1, "Boken", "Författaren")]
        [InlineData(4, "Silvertronen", "C.S. Lewies")]
        public void AddBookToDB(int id, string title, string author)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Id = 2, Title = "title", Author = "author" });
            books.Add(new Book { Id = 3, Title = "Bilbo", Author = "Tolkien" });

            var mock = new Mock<IApiRequestSend<Book>>();
            mock.Setup(m => m.GetAllData()).Returns(books);
            var mockObj = mock.Object;
            var book = new Book { Id = id, Title = title, Author = author };

            mockObj.AddEntity(book);
            books.Add(book);
            var bookList = mockObj.GetAllData();

            Assert.Equal(bookList, books);
        }


    }
}

