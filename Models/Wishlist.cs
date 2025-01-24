﻿using System.ComponentModel.DataAnnotations.Schema;
using Mailo.Data.Enums;

namespace Mailo.Models
{
	public class Wishlist
	{
        [ForeignKey("user")]
        public int UserID { get; set; }
		public User user { get; set; }
        [ForeignKey("product")]

        public int ProductID { get; set; }
        public Product product { get; set; }
		public DateTime AdditionDate { get; set; }= DateTime.Now;
	}
}
