using System.Text.Json;

namespace Astro
{
    public class Christian
    {
        private DateTime Datetime { get; }
        
        public Christian(DateTime dateTime) => Datetime = dateTime;
        
        public int Year { get => Datetime.Year; }
        public int Month { get => Datetime.Month; }
        public int Day { get => Datetime.Day; }
        public int Hour { get => Datetime.Hour; }
        public int Min { get => Datetime.Minute; }
    }
    public class Slavian
    {
        private const int YearOffset = 5508;
        private const int YearLifeCycle = 144;
        private const int YearLifeCycleOffset = 112;
        private const int YearCycle = 16;
        private const int September = 9;
        private const int October = 10;

        public int Year { get; private set; }
        public int Year144 { get; private set; }
        public int Year16 { get; private set; }
        public int Month { get; }
        public string MonthName { get; }
        public int Day { get; }
        public string Season { get; }
        public string DayName { get; }
        public string Нoliday { get; }
        public string PostName { get; }
        public string PostDescription { get; }

        private DateTime slavDate;

        private static DateTime AdjustDate(DateTime dateTime)
        {
            return dateTime.Hour >= 18 ? dateTime.AddDays(1) : dateTime;
        }
        private void AdjustYear()
        {
            if ((Year16 >= 1 && Year16 <= 4) && ((slavDate.Month >= September && slavDate.Day >= 23) || slavDate.Month >= October))
                IncrementYear();
            else if ((Year16 >= 5 && Year16 <= 8) && ((slavDate.Month >= September && slavDate.Day >= 22) || slavDate.Month >= October))
                IncrementYear();
            else if ((Year16 >= 9 && Year16 <= 12) && ((slavDate.Month >= September && slavDate.Day >= 21) || slavDate.Month >= October))
                IncrementYear();
            else if ((Year16 >= 13 && Year16 <= 16) && ((slavDate.Month >= September && slavDate.Day >= 20) || slavDate.Month >= October))
                IncrementYear();

            if (Year144 > YearLifeCycle) Year144 -= YearLifeCycle;
            if (Year16 > YearCycle) Year16 -= YearCycle;
        }
        private void IncrementYear()
        {
            Year += 1;
            Year144 += 1;
            Year16 += 1;
        }
        private void AdjustYear16(DateTime slavDate)
        {
            if ((Year16 == 4 && slavDate.Month == September && slavDate.Day == 22) ||
                (Year16 == 8 && slavDate.Month == September && slavDate.Day == 21) ||
                (Year16 == 12 && slavDate.Month == September && slavDate.Day == 20) ||
                (Year16 == 16 && slavDate.Month == September && slavDate.Day == 19))
            {
                IncrementYear();
            }

            if (Year144 > YearLifeCycle) Year144 -= YearLifeCycle;
            if (Year16 > YearCycle) Year16 -= YearCycle;
        }

        public Slavian(DateTime dateTime)
        {
            slavDate = AdjustDate(dateTime);
            Year = slavDate.Year + YearOffset;
            Year144 = (Year % YearLifeCycle) + YearLifeCycleOffset;
            Year16 = Year % YearCycle == 0 ? YearCycle : Year % YearCycle;
            AdjustYear();
            AdjustYear16(slavDate);

            (string, int, int, string, string) slavDateTupple = SlavAstronomy.DateConvert(Year16, Year144, slavDate.Month, slavDate.Day, slavDate.Year);
            MonthName = slavDateTupple.Item1;
            Month = slavDateTupple.Item2;
            Day = slavDateTupple.Item3;
            Season = slavDateTupple.Item4;
            DayName = slavDateTupple.Item5;
            (string, string) postTupple = SlavAstronomy.Post(Month, Day);
            PostName = postTupple.Item1;
            PostDescription = postTupple.Item2;
            //Нoliday = slavCal[4];

        }

        public override string ToString() => $"ЛѢто {Year}, {Day} {MonthName}({Month}) {DayName}, {Season}";
    }

    public class NumeroObject
    {
        private DateTime Datetime { get; }
        
        public NumeroObject(DateTime dateTime) => Datetime = dateTime;

        public Christian Chris { get => new(Datetime); }
        public Slavian Slav { get => new(Datetime); }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}