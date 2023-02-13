using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
	public class Order
	{

        [BindNever]
		public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(25)]
        [Required(ErrorMessage ="Длина имени не менее 5 символов")]
		public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Surname { get; set; }
        [Display(Name = "Адресс")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длина имени не менее 15 символов")]
        public string Adress { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не менее 10 символов")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина имени не менее 15 символов")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}
