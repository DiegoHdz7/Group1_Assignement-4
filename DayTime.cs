using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_Assignement_4
{
    public struct DayTime
    {
        private long minutes;

        public DayTime(long mintues)
        {
            this.minutes = mintues; // since there is no pro
        }
        public static DayTime operator +(DayTime lhs, int minutes)
        {
            return new DayTime(lhs.minutes + minutes);
        }

        public override string ToString()
        {
            long year = this.minutes / 518_400; // 
            long remaining = this.minutes % 518_400;
            //=
            long month = remaining / 43_200 + 1;
            remaining = remaining % 43_200;
            long day = remaining / 1_440 + 1;
            remaining = remaining % 1_440;
            long hours = remaining / 60;
            long minutes = remaining % 60;
            return $"{year:D4}-{month:D2}-{day:D2} {hours:D2}:{minutes:D2}";
        }
        public static void Runtest()
        {
            DayTime day = new DayTime(1_048_000_000);
            Console.WriteLine(day);
            day += 5;
            Console.WriteLine(day);
            day += 60; //added 1 hour
            Console.WriteLine(day);
            day += 300; // added 5 hours
            Console.WriteLine(day);
        }

    }
}
