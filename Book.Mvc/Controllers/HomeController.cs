using Book.Mvc.Entity;
using Book.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Mvc.Controllers
{
    public class HomeController : Controller
    {

        DataContext _db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var books = _db.Kitaplar
                .Where(i => i.Home == true)
                .Select(i => new BookListModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + ".." : i.Name,
                    Description = i.Description.Length > 35 ? i.Description.Substring(0,32 ) + "..." : i.Description,
                    Puan=i.Puan,
                    Yazar = i.Yazar.Length > 16 ? i.Yazar.Substring(0, 13) + ".." : i.Yazar,
                    Image=i.Image,
                    CategoryId=i.CategoryId,    
                }).ToList();
            return View(books);
        } 
        public ActionResult List(int? id)
        {
            var books = _db.Kitaplar
                .Select(i => new BookListModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + ".." : i.Description,
                    Puan = i.Puan,
                    Yazar = i.Yazar,
                    Image = i.Image,
                    CategoryId = i.CategoryId

                }).AsQueryable();
            if (id!= null)
            {
                books = books.Where(i => i.CategoryId == id);
            }

            return View(books.ToList());
        }
        
        public ActionResult YorumYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YorumYap(Comment model)
        {

            var comment = new Comment();
            comment.KitapId = model.KitapId;
            comment.UserName = model.UserName;
            comment.Yorum = model.Yorum;
            comment.Role = model.Role;
            
            comment.CommentTime = DateTime.Now;
            _db.Comments.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
      }
        public ActionResult ReadingList()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult ReadingList(ReadingList model)
        {
            var list = new ReadingList();

            
                    list.KitapId = model.KitapId;
                    list.UserName = model.UserName;
                    list.AdditionTime = DateTime.Now;
                    _db.ReadingLists.Add(model);
                    _db.SaveChanges();

                    return RedirectToAction("List","Home");
               
            

            //list.KitapId=model.KitapId;
            //list.UserName = model.UserName;
            //list.AdditionTime = DateTime.Now;

            //_db.ReadingLists.Add(model);
            //_db.SaveChanges();
            
        }

        public ActionResult Search(string search)
        {
            var books = _db.Kitaplar
                .Select(i => new BookListModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + ".." : i.Description,
                    Puan = i.Puan,
                    Yazar = i.Yazar,
                    Image = i.Image,
                    CategoryId = i.CategoryId

                }).AsQueryable();
            if (search != null)
            {
                books = books.Where(i => i.Name.Contains(search));
                ViewData["kelime"] = search;
            }

            return View(books.ToList());

        }
       
        

        public ActionResult ShowReadingList(string username)
        {
            

            ListBooksModel list = new ListBooksModel();
            var xxx = _db.ReadingLists.Where(i => i.UserName==username).ToList();
            list.readinglist = _db.ReadingLists.Where(i => i.UserName == username).ToList();
            list.kitaplar = _db.Kitaplar.ToList();
            return View(list);
            
        }
        public ActionResult Details(int id)
        {
            DetailModel detailmodel = new DetailModel();
            detailmodel.Id = id;
            detailmodel.kitaplar = _db.Kitaplar.Where(i => i.Id == id).FirstOrDefault();
            detailmodel.comments = _db.Comments.Where(i => i.KitapId == id && i.Role == "user" && i.Yorum != null).ToList();
            detailmodel.YazarComment = _db.Comments.Where(i => i.KitapId == id && i.Role == "yazar" && i.Yorum != null).ToList();
            return View(detailmodel);

        }
        public ActionResult DeleteBook(int? id)
        {
            ReadingList xxx = _db.ReadingLists.Find(id);
            _db.ReadingLists.Remove(xxx);
            _db.SaveChanges();
            
                return RedirectToAction("List");
        }
        public PartialViewResult Categories()
        {
            var list = _db.Categories.ToList();
            return PartialView(list);
        }

        public PartialViewResult DescendingList()
        {
            return PartialView(_db.Kitaplar.OrderByDescending(x => x.Puan).Take(6).ToList());
        }

        public ActionResult TekrarDeneme()
        {
            var xxx = _db.ReadingLists.ToList(); ;

            return View(xxx);

        }
        
    }


    
   
}