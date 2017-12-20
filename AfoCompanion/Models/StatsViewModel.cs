using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AfoCompanion.Models
{
    public class StatsViewModel
    {
        [Required(ErrorMessage ="You need to specify a name.")]
        public string Name { get; set; }
    }
}