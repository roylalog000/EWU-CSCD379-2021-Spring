using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class GroupController : Controller
    {
        

        public IActionResult Index()
        {
            return View(MockData.Group);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Group.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Group[id]);
        }

        [HttpPost]
        public IActionResult Edit(GroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Group[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MockData.Group.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}