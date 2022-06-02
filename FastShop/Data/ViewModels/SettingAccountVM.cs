using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class SettingAccountVM
	{
		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Старий пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустима довжина від 7 до 30 символів")]
		public string OldPass { get; set; }

		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Новий пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустима довжина від 7 до 30 символів")]
		public string NewPass { get; set; }

		[Required(ErrorMessage = "Це поле обов'язкове")]
		[Display(Name = "Повторіть пароль")]
		[DataType(DataType.Password)]
		[Compare("NewPass", ErrorMessage = "Пароли не співпадають")]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустима довжина від 7 до 30 символів")]
		public string ConfirmPass { get; set; }
	}
}
