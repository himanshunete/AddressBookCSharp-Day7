using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MultipleAddressBook
{

    class ContactDetails
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public int phoneNumber1;
        public int phoneNumber2;
        public string email;
        public string addressBook;

        public ContactDetails(string addressBook, string firstName, string lastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber1 = phoneNumber1;
            this.phoneNumber2 = phoneNumber2;
            this.email = email;
            this.addressBook = addressBook;

        }
        public string toString()
        {
            return " Details of " + firstName + " " + lastName + " are: " + " Address: " + address + "  City: " + city + "\n"
                                    + "                           " + " State: " + state + "  Zip: " + zip + "\n"
                                    + "                          " + " PhoneNumber: " + phoneNumber1 + phoneNumber2 + "\n"
                                    + "                          " + " Email: " + email;

        }
    }

    //Computation
    class Program
    {
        private ArrayList contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
        private Dictionary<string, Dictionary<string, ContactDetails>> multipleAddressBookMap;

        public Program()
        {
            contactDetailsList = new ArrayList();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
            multipleAddressBookMap = new Dictionary<string, Dictionary<string, ContactDetails>>();
        }


        public void AddDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, string email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            contactDetailsList.Add(contactDetails);
            contactDetailsMap.Add(firstName, contactDetails);
            multipleAddressBookMap.Add(addressBook, contactDetailsMap);
        }

        public void EditDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, int phoneNumber1, int phoneNumber2, String email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            int index = Convert.ToInt32(Console.ReadLine());
            contactDetailsList[index] = contactDetails;
            contactDetailsMap[firstName] = contactDetails;
        }

        public void DeleteDetails(string firstName)
        {
            int index = Convert.ToInt32(Console.ReadLine());
            contactDetailsList.RemoveAt(index);
            contactDetailsMap.Remove(firstName);
        }
        public void ComputeDetails()
        {
            foreach (KeyValuePair<string, Dictionary<string, ContactDetails>> book in multipleAddressBookMap)
            {
                Console.WriteLine("Key: {0}, Value: {1}", book.Key, book.Value);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Address Book System ");
            Program details = new Program();
            int noOfPersons = Convert.ToInt32(Console.ReadLine());

            for (int numOfPerson = 1; numOfPerson < noOfPersons; numOfPerson++)
            {
                string addressBook = Console.ReadLine();
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                string address = Console.ReadLine();
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                int zip = Convert.ToInt32(Console.ReadLine());
                int phoneNumber1 = Convert.ToInt32(Console.ReadLine());
                int phoneNumber2 = Convert.ToInt32(Console.ReadLine());
                string email = Console.ReadLine();
                details.AddDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            }
            details.ComputeDetails();

            for (int numOfPerson = 1; numOfPerson < noOfPersons; numOfPerson++)
            {
                string addressBook = Console.ReadLine();
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                string address = Console.ReadLine();
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                int zip = Convert.ToInt32(Console.ReadLine());
                int phoneNumber1 = Convert.ToInt32(Console.ReadLine());
                int phoneNumber2 = Convert.ToInt32(Console.ReadLine());
                string email = Console.ReadLine();
                details.AddDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
            }
            details.ComputeDetails();

            int option = Convert.ToInt32(Console.ReadLine());
            const int EDIT = 0;
            const int DELETE = 1;
            switch (option)
            {
                case EDIT:
                    int noOfEdits = Convert.ToInt32(Console.ReadLine());
                    for (int numOfPerson = 1; numOfPerson < noOfEdits; numOfPerson++)
                    {
                        string addressBook = Console.ReadLine();
                        string firstName = Console.ReadLine();
                        string lastName = Console.ReadLine();
                        string address = Console.ReadLine();
                        string city = Console.ReadLine();
                        string state = Console.ReadLine();
                        int zip = Convert.ToInt32(Console.ReadLine());
                        int phoneNumber1 = Convert.ToInt32(Console.ReadLine());
                        int phoneNumber2 = Convert.ToInt32(Console.ReadLine());
                        string email = Console.ReadLine();
                        details.EditDetails(addressBook, firstName, lastName, address, city, state, zip, phoneNumber1, phoneNumber2, email);
                    }
                    details.ComputeDetails();
                    break;
                case DELETE:
                    int noOfDeletes = Convert.ToInt32(Console.ReadLine());
                    for (int numOfPerson = 1; numOfPerson < noOfDeletes; numOfPerson++)
                    {
                        string firstName = Console.ReadLine();
                        details.DeleteDetails(firstName);
                    }
                    details.ComputeDetails();
                    break;
            }

        }

    }
}
