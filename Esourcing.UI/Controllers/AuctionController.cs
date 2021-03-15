using Esourcing.UI.Clients;
using Esourcing.UI.ViewModel;
using ESourcing.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esourcing.UI.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ProductClient _productClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
        }


        public IActionResult Index()
        {
            List<AuctionViewModel> model = new List<AuctionViewModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //TODO:Product GetAll
            var productList = await _productClient.GetProducts();
            if (productList.IsSuccess)
                ViewBag.ProductList = productList.Data;

            var userList = await _userRepository.GetAllAsync();
            ViewBag.UserList = userList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(AuctionViewModel model)
        {
            return View(model);
        }

        public IActionResult Detail()
        {
            return View();
        }

    }
}
