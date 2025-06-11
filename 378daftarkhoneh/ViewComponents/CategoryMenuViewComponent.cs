using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _378daftarkhoneh.Data;

namespace _378daftarkhoneh.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoryMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();

            return View(categories);
        }
    }
}
