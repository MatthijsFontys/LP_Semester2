using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Models;

namespace UnitTests {
    public class TimeCalculations {

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
    }
}
