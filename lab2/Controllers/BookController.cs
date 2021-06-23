using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab2.Models;
using System.Runtime.Serialization;





namespace lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher()
        {
            return "hello nguyen van ha";
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 the complete Manual - author Name Book 1");
            books.Add("HTML5 & CSS Reponsive web Design cookbook -Author Name Book 2");
            books.Add("Professtional ASP.NET MVC 5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add( new Book(1,"HTML5 & CSS3 the complete Manual ", "author Name Book 1","/Content/Images/book1cover.jpg"));
            books.Add( new Book(2,"HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Images/ngonngucuathanhcong.jpg"));
            books.Add(new Book(3,"Professtional ASP.NET MVC 5 ","Author Name Book 2", "/Content/Images/nhagiakim.jpg"));
            ViewBag.Books = books;
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 the complete Manual ", "author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Images/ngonngucuathanhcong.jpg"));
            books.Add(new Book(3, "Professtional ASP.NET MVC 5 ", "Author Name Book 2", "/Content/Images/nhagiakim.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
                
        }

       [HttpPost, ActionName("EditBook")]
       [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Tiltle, string Author, string ImagesCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 the complete Manual ", "author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Images/ngonngucuathanhcong.jpg"));
            books.Add(new Book(3, "Professtional ASP.NET MVC 5 ", "Author Name Book 2", "/Content/Images/nhagiakim.jpg"));

            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Tiltle;
                    b.Author = Author;
                    b.ImageCover = ImagesCover;
                    break;
                }
            }

            return View("ListBookModel",books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include = "Id,Title,Author")] Book book)
        {
            var books = new List<Book>();
            //sách mặc định
            books.Add(new Book(1, "HTML5 & CSS3 the complete Manual ", "author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Images/ngonngucuathanhcong.jpg"));
            books.Add(new Book(3, "Professtional ASP.NET MVC 5 ", "Author Name Book 2", "/Content/Images/nhagiakim.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    //thêm sách mới
                    books.Add(book);
                }

            }
            catch(Exception ex)
            {

                ModelState.AddModelError("", "Error Save Data");
            }
            // trả về trang xem sách với danh sách Book mới
            return View("ListBookModel", books);

        }

    }
}