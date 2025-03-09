using Cafe.Menu.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Menu.Entity
{
	[Table("Product")]
	public class Product : IEntity
	{
		public Product()
		{
		}


		[Key]
		[Column("ProductId")]
		public int ProductId { get; set; }

		[Column("ProductName")]
		public string? ProductName { get; set; }

		[Column("CategoryId")]
		public int? CategoryId { get; set; }

		[Column("Price")]
		public decimal Price { get; set; }

		[Column("ImagePath")]
		public string? ImagePath { get; set; }

		[Column("IsDeleted")]
		public bool? IsDeleted { get; set; }

		[Column("CreatedDate")]
		public DateTime? CreatedDate { get; set; }

		[Column("CreatorUserId")]
		public int? CreatorUserId { get; set; }
	}
}
