using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class NameController : Controller
    {
        

        public IActionResult Index()
        {
            return View(MockData.Name);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Name.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Name[id]);
        }

        [HttpPost]
        public IActionResult Edit(NameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Name[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MockData.Name.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}