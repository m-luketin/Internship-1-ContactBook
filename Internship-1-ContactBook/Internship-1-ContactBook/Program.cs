using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var choice = "";

            //a new empty dictionary
            Dictionary<string, (string, string, string)> phoneBook = new Dictionary<string, (string, string, string)>();
            //random entries
            phoneBook.Add("0976086801", ("Matija", "Luketin", "Pozeska 12"));
            phoneBook.Add("0910000001", ("Ivo", "Ivic", "Vukovarska 86"));
            phoneBook.Add("0910000002", ("Marko", "Markic", "Ilocka 16"));
            phoneBook.Add("0910000003", ("Antonia", "Brakic", "Poljicka 34"));
            phoneBook.Add("0910000004", ("Luka", "Andric", "Bracka 29"));
            phoneBook.Add("0910000005", ("Ivan", "Kovac", "Slavonska 67"));
            phoneBook.Add("0910000006", ("Petar", "Franic", "Trumbiceva 32"));
            phoneBook.Add("0910000007", ("Marin", "Juric", "Bosanska 2"));
            phoneBook.Add("0910000008", ("Ante", "Peric", "Branimirova 21"));
            //console menu
            do
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1)add entry");
                Console.WriteLine("2)change entry");
                Console.WriteLine("3)delete entry");
                Console.WriteLine("4)search entries by number");
                Console.WriteLine("5)search entries by name");
                Console.WriteLine("6)exit");
                choice = Console.ReadLine();

                if (choice == "1")
                    AddEntry(phoneBook);
                else if (choice == "2")
                    ChangeEntry(phoneBook);
                else if (choice == "3")
                    DeleteEntry(phoneBook);
                else if (choice == "4")
                    SearchByNum(phoneBook);
                else if (choice == "5")
                    SearchByName(phoneBook);

            } while (choice != "6");
        }
        static void AddEntry(Dictionary<string, (string, string,string)> dict)
        {
            Console.WriteLine("Enter a new phone number:");
            var phoneNumber1 = Console.ReadLine();
            phoneNumber1.Replace(" ", string.Empty);
            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter adress:");
            var homeAdress = Console.ReadLine();
            Console.WriteLine("Confirm phone number:");
            var phoneNumber2 = Console.ReadLine();
            phoneNumber1.Replace(" ", string.Empty);

            if (phoneNumber1==phoneNumber2 && !(dict.ContainsKey(phoneNumber1)))
                dict.Add(phoneNumber1, (firstName, lastName, homeAdress));
            else
                Console.WriteLine("Phone number invalid");
        }
        static void ChangeEntry(Dictionary<string,(string, string, string)> dict)
        {
            Console.WriteLine("Enter the phone number you want to change:");
            var phoneNumber = Console.ReadLine();

            if (dict.ContainsKey(phoneNumber))
            {
                Console.WriteLine("What would you like to change:");
                Console.WriteLine("1)phone number");
                Console.WriteLine("2)name");
                Console.WriteLine("3)adress");
                var choice = Console.ReadLine();
                var tmp = dict[phoneNumber];
                dict.Remove(phoneNumber);

                if (choice == "1")
                {
                    Console.WriteLine("Enter new phone number:");
                    var newPhoneNumber1 = Console.ReadLine();
                    Console.WriteLine("Confirm phone number:");
                    var newPhoneNumber2 = Console.ReadLine();

                    if (newPhoneNumber1 == newPhoneNumber2)
                        dict.Add(newPhoneNumber1, tmp);
                    else
                        Console.WriteLine("Phone number confirmation invalid");
                }
                else if (choice == "2")
                {
                    var newAdress = tmp.Item3;
                    Console.WriteLine("Enter new first name:");
                    var newFirstName = Console.ReadLine();
                    Console.WriteLine("Enter new last name:");
                    var newLastName = Console.ReadLine();

                    dict.Add(phoneNumber, (newFirstName, newLastName, newAdress));
                }

                else if (choice == "3")
                {
                    var newAdress = tmp.Item3;
                    Console.WriteLine("Enter new first name:");
                    var newFirstName = Console.ReadLine();
                    Console.WriteLine("Enter new last name:");
                    var newLastName = Console.ReadLine();

                    dict.Add(phoneNumber, (newFirstName, newLastName, newAdress));
                }
                else
                    Console.WriteLine("Error");
            }
            else
                Console.WriteLine("Phone number not found");
        }
        static void DeleteEntry(Dictionary<string, (string, string, string)> dict)
        {
            Console.WriteLine("Enter the number you'd like to delete:");
            var phoneNumber1 = Console.ReadLine();
            if (dict.ContainsKey(phoneNumber1))
            {
                Console.WriteLine("Confirm the phone number:");
                var phoneNumber2 = Console.ReadLine();
                if (phoneNumber1 == phoneNumber2)
                    dict.Remove(phoneNumber1);
                else
                    Console.WriteLine("Invalid phone number confirmation");            }
            else
                Console.WriteLine("Phone number not in phonebook");
        }
        static void SearchByNum(Dictionary<string, (string, string, string)> dict)
        {
            Console.WriteLine("Enter phone number for search:");
            var numForSearch = Console.ReadLine();
            numForSearch.Replace(" ", string.Empty);

            if (dict.ContainsKey(numForSearch))
                Console.WriteLine(numForSearch + dict[numForSearch]);
            else
                Console.WriteLine("Number not in phonebook");
        }
        static void SearchByName(Dictionary<string, (string, string, string)> dict)
        { 
            Console.WriteLine("Enter name:");
            var nameSearch = Console.ReadLine();
            foreach (var item in dict.OrderBy(item=>item.Value.Item2).ThenBy(item => item.Value.Item2))
            { 
                if (item.Value.Item1.StartsWith(nameSearch) || item.Value.Item2.StartsWith(nameSearch))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
