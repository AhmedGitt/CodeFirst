
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET22S_CodeFirst.Models
{
	[Table("Students")]
	public class Student
	{
		[Key]
			public long StudentId { get; set; }
			public int StudentDetailsId;
			public string Address;
			public string PhoneNumber;
			public string FirstName;
			public string LastName;
    }
}

