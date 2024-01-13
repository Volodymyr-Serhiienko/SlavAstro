using System;
using System.Text.Json;

namespace Astro
{
    public class Person : NumeroObject
    {
        public string Firstname { get; } = "";
        public string Lastname { get; } = "";
        public DateTime BirthDate { get; }
        public int LifeNum
        {
            get
            {
                int num = Chris.Year + Chris.Month + Chris.Day;
            start:
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                if (sum > 9) { num = sum; goto start; }
                return sum;
            }
        }
        public int GuardNum
        {
            get
            {
                int num = Slav.Year + Slav.Month + Slav.Day;
            start:
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                if (sum > 9) { num = sum; goto start; }
                return sum;
            }
        }

        public Person(DateTime datetime, string firstname, string lastname)
            : base(datetime)
        {
            Firstname = firstname;
            Lastname = lastname;
            BirthDate = datetime;
        }
        public Person() : base(DateTime.Now) { }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
