using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MVC_ReleaseDateSite {
    public class ValidDateAttribute : ValidationAttribute {

        public override bool IsValid(object value) {
            DateTime userEnteredDate = (DateTime)value;
            return (userEnteredDate > DateTime.Now.AddDays(1) && userEnteredDate <= DateTime.Now.AddYears(2));
        }
    }
}
