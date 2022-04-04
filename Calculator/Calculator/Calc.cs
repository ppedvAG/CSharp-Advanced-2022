namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (a > 1000)
                return 16;

            return checked(a + b);
        }



        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }


        public void OldSchoolCasting()
        {
            object oo = new DateTime();
            if(oo is DateTime)
            {
                DateTime dt = (DateTime)oo; //casting
            }
        }

        // since .NET Framework 2.0
        public void OldSchoolBoxing()
        {
            object oo = new DateTime();
            DateTime? dt = oo as DateTime?; //as == boxing
            if(dt != null)
            {
                Console.WriteLine("yeah");
            }
        }

        //since C#7 (.net Framework 4.6)
        public void PatterMatching()
        {
            object oo = new DateTime();

            int number = 1_000_000_000;


            if(oo is DateTime dt)  //patter matching
            {
                Console.WriteLine("yeah");
            }
        }
    }
}