using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserGroup.Web.Api;
using UserGroup.Web.Data;
using UserGroup.Web.ViewModels;

namespace UserGroup.Web.Controllers
{
    public class EventsController : Controller
    {
        public IEventsClient Client { get; }

        public EventsController(IEventsClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Event> events = await Client.GetAllAsync();
            List<EventViewModel> viewModelEvents = new();
            foreach(Event e in events)
            {
                viewModelEvents.Add(new EventViewModel
                {
                    Id = e.Id,
                    Title = e.Name
                });
            }
            return View(viewModelEvents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Events.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Events[id]);
        }

        [HttpPost]
        public IActionResult Edit(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Events[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await Client.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}