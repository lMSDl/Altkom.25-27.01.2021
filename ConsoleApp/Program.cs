﻿using ConsoleApp.Models;
using Models;
using Services.InMemoryService;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public class Program
    {
        private static IService<Person> Service { get; } = new PeopleService();

        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                DisplayPeople();
            } while (ReadAndExecuteCommand());

        }

        private static void DisplayPeople()
        {
            foreach (var person in Service.Read())
            {
                Console.WriteLine(person);
            }
        }

        private static bool ReadAndExecuteCommand()
        {
            var input = System.Console.ReadLine();
            var command = new Command(input);

            switch (command.Action)
            {
                case "exit":
                    return false;

                case "add":
                    Add();
                    break;

                case "edit":
                    if (command.Parameter.HasValue)
                        Edit(command.Parameter.Value);
                    break;

                case "delete":
                    if(command.Parameter.HasValue)
                        Delete(command.Parameter.Value);
                    break;

                default:
                    Console.WriteLine("Unknown command");
                    System.Console.ReadLine();
                    break;
            }

            return true;
        }

        private static void Add()
        {
            var person = new Person();
            Edit(person);
            Service.Create(person);
        }

        private static void Edit(int id)
        {
            var person = Service.Read(id);
            if (person == null)
                return;

            Edit(person);
            Service.Update(id, person);
        }

        private static void Edit(Person person)
        {
            Console.WriteLine("First name:");
            SendKeys.SendWait(person.FirstName);
            person.FirstName = Console.ReadLine();

            Console.WriteLine("Last name:");
            SendKeys.SendWait(person.LastName);
            person.LastName = Console.ReadLine();

            Console.WriteLine("Gender:");
            SendKeys.SendWait(person.Gender.ToString());
            person.Gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());

            Console.WriteLine("Birth date:");
            SendKeys.SendWait(person.BirthDate.ToShortDateString());
            person.BirthDate = DateTime.Parse(Console.ReadLine());
        }

        private static void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}
