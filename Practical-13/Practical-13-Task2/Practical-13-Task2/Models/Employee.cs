using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Practical_13_Task2.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required]
        [StringLength(10,MinimumLength =10)]
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}