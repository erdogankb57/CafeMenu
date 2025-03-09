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
	[Table("CATEGORY")]
	public class Category : IEntity
	{
		public Category()
		{
		}


		[Key]
		[Column("CategoryId")]
		public int CategoryId { get; set; }

		[Column("CategoryName")]
		public string? CategoryName { get; set; }

		[Column("ParentCategoryId")]
		public int? ParentCategoryId { get; set; }

		[Column("IsDeleted")]
		public bool? IsDeleted { get; set; }

		[Column("CreatedDate")]
		public DateTime? CreatedDate { get; set; }

		[Column("CreatorUserId")]
		public int? CreatorUserId { get; set; }
	}
}
