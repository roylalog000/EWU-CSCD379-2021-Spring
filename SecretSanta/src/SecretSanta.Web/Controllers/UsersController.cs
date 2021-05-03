
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;
using SecretSanta.Web.Api;
using SecretSanta.Api.Dto;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IUsersClient Client { get; }

        public UsersController(IUsersClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index()
        {
            ICollection<User> users = await Client.GetAllAsync();
            List<UserViewModel> viewModelUsers = new();
            foreach (User u in users)
            {
                viewModelUsers.Add(new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,

                });
            }
            return View(viewModelUsers);
        }

        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await Client.PostAsync(new User
                {
                    FirstName = viewModel.FirstName
                });
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }




        public IActionResult Edit(int id)
        {
            return View(MockData.Users[id - 1]);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Users[viewModel.Id] = viewModel;
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