using NUnit.Framework;

namespace JBuilder.UnitTest
{
    [TestFixture]
    public class BuilderTest
    {

        [TestCase]
        public void Should_Create_Simple_Object()
        {
            Address address = Builder.BuildSingle(typeof(Address));
            Assert.IsNotNullOrEmpty(address.AddressLine1);
            Assert.IsNotNullOrEmpty(address.AddressLine2);
        }

        [TestCase]
        public void Should_Create_Nested_Object()
        {
            Person person = Builder.BuildSingle(typeof(Person));
            Assert.IsNotNullOrEmpty(person.FirstName);
            Assert.IsNotNull(person.Address);
            Assert.IsNotNullOrEmpty(person.Address.AddressLine1);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
