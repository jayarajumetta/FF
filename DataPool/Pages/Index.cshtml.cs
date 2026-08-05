using DataPool.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DataPool.Pages
{
    public class IndexModel : PageModel
    {
        // The page model is intentionally thin — all data loading
        // is done client-side via fetch() calls to /api/quotes.
        // This keeps the UI reactive and avoids full page reloads on filter changes.
        public IndexModel(IDataPoolService service) { }

        public void OnGet() { }
    }
}
