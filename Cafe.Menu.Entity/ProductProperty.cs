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

	[Table("ProductProperty")]
	public class ProductProperty : IEntity
	{
		public ProductProperty()
		{
		}


		[Key]
		[Column("ProductPropertyId")]
		public int ProductPropertyId { get; set; }

		[Column("ProductId")]
		public int? ProductId { get; set; }

		[Column("PropertyId")]
		public int? PropertyId { get; set; }
	}
}
