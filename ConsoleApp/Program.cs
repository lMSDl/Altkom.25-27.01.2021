using ConsoleApp.Models;
using Models;
using Services.DAL.Services;
using Services.InMemoryService;
using Services.Interfaces;
using System;

namespace ConsoleApp
{
    public partial class Program
    {
        private static IService<Person> Service { get; } = new CrudService<Person>(); // new PeopleService();

        [STAThread]
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

            switch (command.Type)
            {
                case CommandTypes.Exit:
                    return false;

                case CommandTypes.Add:
                    Add();
                    break;

                case CommandTypes.Edit:
                    if (command.Parameter.HasValue)
                        Edit(command.Parameter.Value);
                    break;

                case CommandTypes.Delete:
                    if(command.Parameter.HasValue)
                        Delete(command.Parameter.Value);
                    break;

                case CommandTypes.Export:
                    if (command.Parameter.HasValue)
                        Export(command.Parameter.Value);
                    break;

                case CommandTypes.Import:
                        Import();
                    break;

                default:
                    Console.WriteLine(Properties.Resources.UnknownCommand);
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

        private static void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}
