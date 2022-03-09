using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;
    
    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model); 
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Category thisCat = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCat);
    }

    public ActionResult Delete(int id)
    {
      var thisCat= _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCat = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Category thisCat = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCat);
    }
    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}