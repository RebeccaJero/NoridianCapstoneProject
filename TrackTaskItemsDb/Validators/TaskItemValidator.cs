using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Validators
{
    public class TaskItemValidator : IValidator<TaskItem>
    {
        private TrackTasksEntities db = new TrackTasksEntities();
        public bool TryInvalidate(TaskItem input, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (input.CompletedDate != null)
            {
                var status = input.Status;
                if (status != 6)
                {
                    errorMessage = "Status has to be Complete.";
                    return true;
                }

            }

            if (input.Status == 6)
            {

                if (input.CompletedDate == null)
                {
                    errorMessage = "Please fill in Completed Date.";
                    return true;
                }

            }

            if (input.CompletedDate != null)
            {

                if (input.StartDate != null && (input.StartDate > input.CompletedDate))
                {
                    errorMessage = "Start Date cannot be greater than completed Date.";
                    return true;
                }


            }

            if (input.QuarterItems.Count() == 0)
            {
                errorMessage = "Start quarter cannot be greater than End quarter.";
                return true;
            }

            return false;
        }
    }
}