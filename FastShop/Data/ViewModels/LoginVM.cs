using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class LoginVM
	{
		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Email")]
		[RegularExpression(@"[A-Za-z0-9-_]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректна адреса")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Запам'ятати мене")]
		public bool RememberMe { get; set; }
	}
}
