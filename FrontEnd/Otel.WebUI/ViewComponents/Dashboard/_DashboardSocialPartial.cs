using Microsoft.AspNetCore.Mvc;

namespace Otel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSocialPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
