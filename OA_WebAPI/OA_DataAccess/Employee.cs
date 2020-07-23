using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA_DataAccess
{
    public class Employee : BaseEntity
    {
        [Column(TypeName ="varchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string Gender { get; set; }
        public bool MaritalStates { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(100)")]
        public string Hobbies { get; set; }
        public int ImageId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        [Column(TypeName = "varchar(6)")]
        public string Zipcode { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PassWord { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
