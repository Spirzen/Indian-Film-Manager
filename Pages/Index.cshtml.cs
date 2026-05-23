using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DashboardService _dashboardService;

        public DashboardViewModel Dashboard { get; set; } = new();

        public IndexModel(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public void OnGet()
        {
            Dashboard = _dashboardService.GetDashboard();
        }
    }
}
