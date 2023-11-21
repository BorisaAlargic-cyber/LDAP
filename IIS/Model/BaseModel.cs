using System;
using System.ComponentModel.DataAnnotations;

namespace IIS.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
