using _404_Book_Not_Found_Temp.Data;
using _404_Book_Not_Found_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _404_Book_Not_Found_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel

    {
        private readonly ApplicationDbContext _db;
        
        public Category Category{ get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        
        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }


    }
}
