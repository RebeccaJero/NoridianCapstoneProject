using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Validators
{
    //Date Validator attribute
    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {

        private string DateToCompareFieldName { get; set; }

        public DateGreaterThanAttribute(string dateToCompareFieldName)
        {
            DateToCompareFieldName = dateToCompareFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult(string.Format("Start Date is Required!"));
            }

            DateTime startDate = (DateTime)value;


            var propinfo = validationContext.ObjectType.GetProperty(DateToCompareFieldName);
            var propvalue = propinfo.GetValue(validationContext.ObjectInstance, null);
            DateTime completedDate = DateTime.MinValue;

            if (propvalue != null)
            {
                completedDate = (DateTime)propvalue;
            }
            else
            {
                return ValidationResult.Success;
            }

            if (startDate.Date < completedDate.Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(string.Format("Completed Date is less than Start Date!", DateToCompareFieldName));
            }
        }



    }


    
}




