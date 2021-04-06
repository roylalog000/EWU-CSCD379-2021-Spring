using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserGroup.Web.ViewModels;

namespace UserGroup.Web.Controllers
{
    public class SpeakersController : Controller
    {
        static List<SpeakerViewModel> Speakers = new List<SpeakerViewModel>{
            new SpeakerViewModel {FirstName = "Inigo", LastName = "Montoya", EmailAddress = "Inigo.Montoya@princessbride.com"},
            new SpeakerViewModel {FirstName = "Princess", LastName = "Buttercup", EmailAddress = "Inigo.Montoya@princessbride.com"},
        };
        public IActionResult Index()
        {
            return View(Speakers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpeakerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Speakers.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            Speakers[id].Id = id;
            return View(Speakers[id]);
        }

        [HttpPost]
        public IActionResult Edit(SpeakerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Speakers[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}