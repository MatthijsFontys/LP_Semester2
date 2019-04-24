﻿using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
    public class TimeCalculationLogic {
        public string GetTimeSincePosted(DateTime postTime) {
            TimeSpan timeDifference = DateTime.Now.Subtract(postTime);
            // Seconds
            if (timeDifference.TotalSeconds < 60)
                if (timeDifference.TotalSeconds < 2)
                    return "1 second ago";
                else
                    return $"{Math.Floor(timeDifference.TotalSeconds)} seconds ago";
            // Minutes
            else if (timeDifference.TotalMinutes < 60)
                if (timeDifference.TotalMinutes < 2)
                    return "1 minute ago";
                else
                    return $"{Math.Floor(timeDifference.TotalMinutes)} minutes ago";
            // Hours
            else if (timeDifference.TotalHours < 24)
                if (timeDifference.TotalHours < 2)
                    return "1 hour ago";
                else
                    return $"{Math.Floor(timeDifference.TotalHours)} hours ago";
            // Days
            else if (timeDifference.TotalDays < 7)
                if (timeDifference.TotalDays < 2)
                    return "1 day ago";
                else
                    return $"{Math.Floor(timeDifference.TotalDays)} days ago";
            // Weeks
            else
                if (timeDifference.TotalDays / 7 < 2)
                return "1 week ago";
            else
                return $"{Math.Floor(timeDifference.TotalDays / 7)} weeks ago";
            // Todo implement months and years
        }

        public void ConvertToDaysIfValidDate(ChangeDateModel[] dates) {
            foreach (ChangeDateModel date in dates) {
                if (DateTime.TryParse(date.Date, out DateTime tempDate))
                    date.Date = $"{Math.Ceiling(tempDate.Subtract(DateTime.Now).TotalDays)} days";
            }
        }
    }
}
