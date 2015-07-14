namespace CSharp6
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var vendor = new Vendor
            {
                ContactPerson = new Vendor.Person
                {
                    HomeAddress = new Vendor.Person.Address
                    {
                        Location = "Ahmedabad"
                    }
                }
            };

            var location = vendor?.ContactPerson?.HomeAddress?.Location;
            WriteLine(location);
            vendor.ContactPerson = null;
            location = vendor?.ContactPerson?.HomeAddress?.Location;
            WriteLine(location);
            Read();
        }
    }
}
