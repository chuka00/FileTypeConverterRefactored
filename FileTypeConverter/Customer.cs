using System;

namespace FileTypeConverter
{

    [Document("This class represents a customer in the system")]
    public class Customer
    {
        [Document("This gets or sets the customer's id")]
        public int ID { get; set; }
        [Document("This gets or sets the customer's Name")]
        public string Name { get; set; }
        [Document("This gets or sets the customer's Address")]
        public string Address { get; set; }
        [Document("This gets or sets the customer's Age")]
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }

        [Document("Retrieves customer details from the database", Input = "id", Output = "Customer Details")]
        public void GetCustomerDetails(int id)
        {

        }
        [Document("This constructor initializes a new customer", Input = "int id, string Name, string Address, int Age,  GenderEnum Gender", Output = "none")]
        public Customer(int id, string Name, string Address, int age, GenderEnum gender)
        {
            ID = id;
            this.Name = Name;
            this.Address = Address;
            Age = age;
            Gender = gender;

        }

        [Document("Provides the gender options of a customer")]
        public enum GenderEnum
        {
            Male,
            Female
        }

        [Document("Makes a phrase or sentence with the available parameters", "Age and gender", "Outputs a sentence, otherwise known as string")]
        public void FormsAPhraseWithCustomer(int age, GenderEnum gender)
        {
            this.Gender = gender;
            this.Age = age;

            if (GenderEnum.Male == gender) Console.WriteLine("We have a {0} year old male", age);
            else Console.WriteLine("We have a {0} year old female", age);
        }

    }
}
