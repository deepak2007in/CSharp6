namespace CSharp6
{
    public class Vendor
    {
        public class Person
        {
            public class Address
            {
                public string Location { get; set; }
            }
            public Address HomeAddress { get; set; }
        }
        public Person ContactPerson { get; set; }
    }
}
