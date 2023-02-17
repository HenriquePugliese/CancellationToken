using Application.Models;
using Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICancellationTokenService _cancellationTokenService;

        public HomeController(ICancellationTokenService cancellationTokenService)
        {
            _cancellationTokenService = cancellationTokenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterWithoutTransaction(CancellationToken cancellationToken)
        {
            await _cancellationTokenService.RegisterWithoutTransaction(cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RegisterWithUnitOfWork(CancellationToken cancellationToken)
        {
            await _cancellationTokenService.RegisterWithUnitOfWork(cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RegisterWithThirdPartyApi(CancellationToken cancellationToken)
        {
            await _cancellationTokenService.RegisterWithThirdPartyApi(cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RegisterWithThirdPartyApiTwo(CancellationToken cancellationToken)
        {
            await _cancellationTokenService.RegisterWithThirdPartyApiTwo(cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}