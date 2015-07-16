namespace CSharp6
{
    using static System.Console;

    public enum DaysOfWeek { Monday = 1, Tuesday = 2};

    public class Program
    {
        static void Main(string[] args)
        {
            long acctNumber;
            double balance;
            DaysOfWeek wday;
            string output;

            acctNumber = 104254568790;
            balance = 16.35;
            wday = DaysOfWeek.Monday;

            output = string.Format(new AccountNumberFormat(), "On {2}, the balance of account {0:H} was {1:C2}.", acctNumber, balance, wday);
            WriteLine(output);
            wday = DaysOfWeek.Tuesday;
            output = string.Format(new AccountNumberFormat(), "On {2}, the balance of account {0:I} was {1:C2}.", acctNumber, balance, wday);
            WriteLine(output);
            Read();
        }
    }
}
