using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastShop.Data.Models;
using FastShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FastShop.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public ViewResult Register()
		{
			ViewBag.Title = "Регістрація";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			ViewBag.Title = "Регістрація";

			if (ModelState.IsValid)
			{
				if (_userManager.FindByEmailAsync(model.Email).Result != null)
				{
					ViewBag.CheckEmail = "Email вже існує";
					return View(model);
				}

				User user = new User { Email = model.Email, UserName = model.Email };

				var res = await _userManager.CreateAsync(user, model.Password);

				if (res.Succeeded)
				{
					await _signInManager.SignInAsync(user, true);
					return Redirect("/");
				}
			}

			return View(model);
		}

		[HttpGet]
		public ViewResult Login()
		{
			ViewBag.Title = "Вхід";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			ViewBag.Title = "Вхід";

			if (ModelState.IsValid)
			{
				var res = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

				if (res.Succeeded)
				{
					return Redirect("/");
				}
				else
				{
					ModelState.AddModelError("", "Не правильний логін або пароль");
				}
			}

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public async Task<RedirectResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Redirect("/");
		}

		[Authorize]
		[HttpGet]
		public ViewResult Settings()
		{
			ViewBag.Title = "Налаштування аккаунту";

			return View();
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Settings(SettingAccountVM settings)
		{
			ViewBag.Title = "Налаштування аккаунту";

			if (ModelState.IsValid)
			{
				string currName = User.Identity.Name;
				User user = await _userManager.FindByNameAsync(currName);

				var res = await _userManager.ChangePasswordAsync(user, settings.OldPass, settings.NewPass);

				if (res.Succeeded)
				{
					ViewBag.Msg = "Пароль успішно змінено";
					return View();
				}
				else
				{
					ViewBag.Error = "Старий пароль вказано не вірно";
				}
			}

			return View(settings);
		}
    }
}