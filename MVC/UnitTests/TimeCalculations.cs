using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVC_ReleaseDateSite.Logic;

namespace UnitTests {
    public class TimeCalculations {

        public TimeCalculationLogic tc;
        public TimeCalculations() {
            tc = new TimeCalculationLogic();
        }

        [Theory]
        [InlineData("14/02/2019", "17/02/2019", "3 days")]
        [InlineData("14/02/2019", "13/02/2019", "1 day ago")]
        [InlineData("14/02/2019", "15/02/2019", "1 day")]
        [InlineData("14/02/2019", "11/02/2019", "3 days ago")]
        public void CalculateTimeUntilRelease(string start, string end, string expected) {
            DateTime startDate;
            DateTime endDate;
            DateTime.TryParse(start, out startDate);
            DateTime.TryParse(end, out endDate);
            TimeCalculationLogic tc = new TimeCalculationLogic();
            ChangeDateModel changeDateModel = new ChangeDateModel
            {
                Date = endDate.ToShortDateString()
            };
            ChangeDateModel[] input = { changeDateModel };
            tc.ConvertToDaysIfValidDate(startDate, input);

            Assert.Equal(expected, input[0].Date);
        }

        [Theory]
        [InlineData("14/02/2019 12:00:00", "14/02/2019 14:59:59", "2 hours ago")]
        [InlineData("14/02/2019", "14/02/2019", "1 second ago")]
        [InlineData("17/02/2019 10:00:00", "21/02/2019 12:00:00", "4 days ago")]
        [InlineData("1/02/2019 12:00:00", "28/02/2019 10:00:00", "3 weeks ago")]
        public void CalculateTimeSinceCommentPosted(string start, string end, string expected) {
            DateTime startDate;
            DateTime endDate;
            DateTime.TryParse(start, out startDate);
            DateTime.TryParse(end, out endDate);

            string actual = tc.GetTimeSincePosted(startDate, endDate);

            Assert.Equal(expected, actual);
        }
    }
}
