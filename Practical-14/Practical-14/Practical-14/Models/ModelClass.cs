using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical_14.Models
{
    public class ModelClass
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Date Of Birth")]
        public DateTime DOB { get; set; }
    }

    [MetadataType(typeof(ModelClass))]
    public partial class Employee
    {

    }
}