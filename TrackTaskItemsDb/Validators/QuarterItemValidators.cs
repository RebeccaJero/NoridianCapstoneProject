using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Validators
{
    public class QuarterItemValidators : IValidator<QuarterItem>
    {
        private TrackTasksEntities db = new TrackTasksEntities();
        public bool TryInvalidate(QuarterItem input, out string errorMessage)
        {
            errorMessage = string.Empty;

            var taskId = input.TaskItemId;
            //get the history of quarters for the item
            var taskQuarterItems = db.QuarterItems.Where(s => s.TaskItemId == taskId);
            var inputStartDate = db.Quarters.Where(q => q.Id == input.StartQuarterId).FirstOrDefault();
            var inputEndDate = db.Quarters.Where(q => q.Id == input.EndQuarterId).FirstOrDefault();
            // validator for change start date validator
            if(input.StartQuarterId > 0)
            {
                foreach (var item in taskQuarterItems)
                {
                    if (input.StartQuarterId == item.StartQuarterId)
                    {
                        errorMessage = "There is an existing start date  for this item.";
                        return true;
                    }
                
                  
                    if (input.StartQuarterId == item.EndQuarterId)
                    {
                        errorMessage = "Start date is equal to end date";
                        return true;
                    }

                    if(item.StartQuarterId > 0)
                    {
                        if (item.Quarter1.StartDate > inputStartDate.StartDate)
                        {
                            errorMessage = "start date is less than original or updated start date for this item";
                            return true;
                        }
                    }
                   
                }
            

             
            }

            // validator for change end date validator
            if (input.EndQuarterId > 0)
            {
                foreach (var item in taskQuarterItems)
                {
                    if (input.EndQuarterId == item.EndQuarterId)
                    {
                        errorMessage = "There is an existing same end date  for this item.";
                        return true;
                    }
                    if (input.EndQuarterId == item.StartQuarterId)
                    {
                        errorMessage = "There is an existing same start date  for this item.";
                        return true;
                    }
                    if(item.EndQuarterId > 0)
                    {
                        if (item.Quarter.EndDate > inputEndDate.EndDate)
                        {
                            errorMessage = "end date is less than original or updated end date for this item";
                            return true;
                        }

                    }
                  
                }

            }

            return false;
        }
    }
}