using _404_Book_Not_Found_Temp.Data;
using _404_Book_Not_Found_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _404_Book_Not_Found_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                var category = _db.Categories.Find(id);
                if (category != null)
                {
                    Category = category;
                }
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");


        }
    }
}
