using System;
using System.ComponentModel.DataAnnotations;

namespace OA_DataAccess
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
