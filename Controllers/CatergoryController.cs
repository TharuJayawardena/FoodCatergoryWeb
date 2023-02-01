using FoodCatergoryWeb.Data;
using FoodCatergoryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FoodCatergoryWeb.Controllers;

public class CatergoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CatergoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Catergory> objCategoryList = _db.Catergories;
        return View(objCategoryList);
    }
    //GET
    public IActionResult Create()
    {
        
        return View();
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Catergory obj)
    {   if(obj.Name == obj.Display.ToString())
        {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the name");
        }
        if (ModelState.IsValid)
        {
            _db.Catergories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Catergory created successfuly";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    //GET
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        var CatergoryFromDb = _db.Catergories.Find(id);

        if(CatergoryFromDb == null)
        {
            return NotFound();
        }
        return View(CatergoryFromDb);
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Edit(Catergory obj)
    {
        if (obj.Name == obj.Display.ToString())
        {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the name");
        }
        if (ModelState.IsValid)
        {
            _db.Catergories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Catergory updated successfuly";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CatergoryFromDb = _db.Catergories.Find(id);

        if (CatergoryFromDb == null)
        {
            return NotFound();
        }
        return View(CatergoryFromDb);
    }
    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]

    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Catergories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Catergories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Catergory Deleted successfuly";
        return RedirectToAction("Index");

    }

}
