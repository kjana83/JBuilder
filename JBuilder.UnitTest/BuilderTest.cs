using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

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

        [TestCase]
        public void Should_Creted_Three_Level_Nested_Object()
        {
            Member member = Builder.BuildSingle(typeof(Member));
            Assert.IsNotNullOrEmpty(member.CompanyName);
            Assert.IsNotNull(member.Person);
            Assert.IsNotNullOrEmpty(member.Person.FirstName);
            Assert.IsNotNull(member.Person.Address);
            Assert.IsNotNullOrEmpty(member.Person.Address.AddressLine1);
        }

        [TestCase]
        public void Should_Create_Array_of_Single_Object()
        {
            IEnumerable<Address> addresses =Builder.BuildArray<Address>(5);
            Assert.GreaterOrEqual(addresses.ToList().Count() , 5);            
            Assert.IsNotNullOrEmpty(addresses.First().AddressLine1);
            Assert.IsNotNullOrEmpty(addresses.First().AddressLine2);
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

    public class Member
    {
        public string CompanyName { get; set; }

        public Person Person { get; set; }
    }
}
