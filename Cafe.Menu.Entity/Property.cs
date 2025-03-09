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

	[Table("Property")]
	public class Property : IEntity
	{
		public Property()
		{
		}


		[Key]
		[Column("PropertyId")]
		public int PropertyId { get; set; }

		[Column("Key")]
		public string? Key { get; set; }

		[Column("Value")]
		public string? Value { get; set; }

		[Column("IsDeleted")]
		public bool? IsDeleted { get; set; }

		[Column("CreatedDate")]
		public DateTime? CreatedDate { get; set; }

		[Column("CreatorUserId")]
		public int? CreatorUserId { get; set; }
	}
}
