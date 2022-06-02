using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Email")]
		[RegularExpression(@"[A-Za-z0-9-_]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректна адреса")]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустима довжина від 7 до 30 символів")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустима довжина від 7 до 30 символів")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Повторіть пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустима довжина від 7 до 30 символів")]
		[Compare("Password", ErrorMessage = "Паролі не співпадають")]
		public string PasswordConfirm { get; set; }
	}
}
