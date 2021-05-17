using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Api;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IUsersClient UserClient { get; }

        public UsersController(IUsersClient userClient)
        {
            UserClient = userClient ?? throw new ArgumentNullException(nameof(userClient));
        }

        public IActionResult Index()
        {
            // ICollection<Event> events = await Client.GetAllAsync();
            // // List<EventViewModel> viewModelEvents = new();
            // // foreach(Event e in events)
            // // {
            // //     viewModelEvents.Add(new EventViewModel
            // //     {
            // //         Id = e.Id,
            // //         Title = e.Title,
            // //         Description = e.Description,
            // //         Date = e.Date?.DateTime,
            // //         Location = e.Location
            // //     });
            // // }
            // return View(events);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Create(Event viewModel)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         await Client.PostAsync(viewModel);
        //         return RedirectToAction(nameof(Index));
        //     }

        //     return View(viewModel);
        // }

        public IActionResult Edit(int id)
        {
            // var myEvent = await Client.GetAsync(id);
            // return View(myEvent);
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Edit(Event viewModel)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         await Client.PutAsync(viewModel.Id, new UpdateEvent {Title = viewModel.Title, 
        //             Description = viewModel.Description, 
        //             Date = viewModel.Date, 
        //             Location = viewModel.Location, 
        //             SpeakerId = viewModel.SpeakerId
        //         });
        //         return RedirectToAction(nameof(Index));
        //     }

        //     return View(viewModel);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     await Client.DeleteAsync(id);
        //     return RedirectToAction(nameof(Index));
        // }
    }
}