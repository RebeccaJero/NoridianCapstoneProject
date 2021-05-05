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

            //if start date is null throw error
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
            //if Completed date is null then we do not have to compare with start date
            else
            {
                return ValidationResult.Success;
            }

            //check if start date is greater than completed date then throw error if it is
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

    //Status Validator attribute
    [AttributeUsage(AttributeTargets.Property)]
    public class StatusCompletedAttribute : ValidationAttribute
    {

        private string CompletedDate { get; set; }

        public StatusCompletedAttribute(string completedDate)
        {
            CompletedDate = completedDate;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult(string.Format("Status is Required!"));
            }

           


            var propinfo = validationContext.ObjectType.GetProperty(CompletedDate);
            var propvalue = propinfo.GetValue(validationContext.ObjectInstance, null);

            //if status is != 6(Completed) then we do not have to check for completed date value
            if ((int)value != 6)
            {
                return ValidationResult.Success;
            }

            if ((int)value == 6 && propvalue != null)
            {
                return ValidationResult.Success;
            }

            //if status is complete(6) and completed date is null throw error
            if((int)value == 6 && propvalue == null)
            {
                return new ValidationResult(string.Format("Please check that completed Date is filled in if Status is Completed!", CompletedDate));
            }
            //if status is not complete(6) and completed date is not null throw error
            if ((int)value != 6 && propvalue != null)
            {
                return new ValidationResult(string.Format("Please check that Status is Complete when completed date is filled in!", CompletedDate));
            }

            return ValidationResult.Success;
        }



    }



}




