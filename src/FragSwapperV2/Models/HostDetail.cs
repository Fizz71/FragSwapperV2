using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FragSwapperV2.Models.Db;
using FragSwapperV2.Libraries;

namespace FragSwapperV2.Models
{
    public class HostDetail
    {
        public HostDetail()
        {
            Events = new List<Event>();
            RandomEventImages = new List<HostEventImages>();
        }

        public Host Host { get; set; }
        public List<Event> Events { get; set; }

        public int EventRegistrationAverage { get; set; }
        public int EventAttendeeAverage { get; set; }
        public int EventListingsAverage { get; set; }
        public int EventTradesAverage { get; set; }
        public int CompletedEventsCount { get; set; }
        public string HostLogoFileName { get; set; }
        public List<HostEventImages> RandomEventImages { get; set; }

        public bool IsPremium
        {
            get
            {
                return Host.AccountType == HostAccountType.Premium;
            }
        }

        public DateTime FirstEvent
        {
            get
            {
                return Events.OrderBy(x => x.EventDate).First(x => x.Status > EventStatus.Requested).EventDate;
            }
        }

        public DateTime LastEvent
        {
            get
            {
                return Events.OrderBy(x => x.EventDate).Last(x => x.Status > EventStatus.Requested).EventDate;
            }
        }

        // We weight the average number events a year to make the first and last year
        // less important since they may not be a full year.
        public double WeightedEventAverage
        {
            get
            {
                int yearWeight = 10;
                int yearFirst = FirstEvent.Year;
                int yearLast = LastEvent.Year;
                var eventsPerYear = new List<int>();
                double weightedValueSum = 0;
                double weightSum = 0;
                for (int yearCount = yearFirst; yearCount < yearLast; yearCount++)
                {
                    int weight = ((yearCount == yearFirst) || (yearCount == yearFirst)) ? 1 : yearWeight;
                    weightedValueSum += (Events.Count(x => x.EventDate.Year == yearCount)) * yearWeight;
                    weightSum += weight;
                }
                if (weightSum == 0)
                    return 0;
                else
                    return Math.Round(weightedValueSum / weightSum, 1);

            }
        }

    }
}
