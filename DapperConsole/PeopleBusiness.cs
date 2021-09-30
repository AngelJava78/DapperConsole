using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperConsole
{
    ///<summary>
    ///People Business
    ///</summary>
    public class PeopleBusiness
    {
        readonly PeopleData data;
        public PeopleBusiness()
        {
            data = new PeopleData();
        }
        public void Add()
        {
            Console.WriteLine("New People");
            Console.Write("Name:");
            var name = Console.ReadLine();
            Console.Write("Last name:");
            var lastName = Console.ReadLine();
            Console.Write("Age: ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            var gender = Console.ReadLine();
            var people = new People
            {
                Name = name,
                LastName = lastName,
                Age = age,
                Gender = gender
            };
            var result = data.Add(people);
            if (result > 0)
            {
                Console.WriteLine($"New People was added. Id: {result}.");
            }
            else
            {
                Console.WriteLine($"Error on insert new people!!");
            }

        }

        public void Delete()
        {
            GetAll();
            Console.WriteLine("Delete People");
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());


            var result = data.Delete(id);
            if (result > 0)
            {
                Console.WriteLine($"New People was added. Id: {result}.");
            }
            else
            {
                Console.WriteLine($"Error on insert new people!!");
            }
            GetAll();
        }
        public void Update()
        {
            GetAll();
            Console.WriteLine("Update People");
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Name:");
            var name = Console.ReadLine();
            Console.Write("Last name:");
            var lastName = Console.ReadLine();
            Console.Write("Age: ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            var gender = Console.ReadLine();
            var people = new People
            {
                Id = id,
                Name = name,
                LastName = lastName,
                Age = age,
                Gender = gender
            };
            var result = data.Update(people);
            if (result > 0)
            {
                Console.WriteLine($"New People was added. Id: {result}.");
            }
            else
            {
                Console.WriteLine($"Error on insert new people!!");
            }
            var person = data.GetById(id);
            ShowPerson(person);
        }
        public void GetAll()
        {
            var peopleList = data.GetAll();
            ShowPerson(peopleList);


        }
        public void GetById()
        {
            Console.WriteLine("Get people by id");
            Console.WriteLine("Id: ");
            var id = int.Parse(Console.ReadLine());
            var person = data.GetById(id);
            ShowPerson(person);
        }
        private void ShowPerson(People p)
        {
            if(p == null)
            {
                Console.WriteLine("People is null or empty");
                return;
            }
            Console.WriteLine("People");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"LastName: {p.LastName}");
            Console.WriteLine($"Age: {p.Age}");
            Console.WriteLine($"Gender: {p.Gender}");
        }
        private void ShowPerson(IEnumerable<People> peopleList)
        {
            
            Console.WriteLine("People");
            Console.WriteLine("Id   Name      LastName            Age  Gender");
            if (peopleList == null)
            {
                Console.WriteLine("People list is null or empty");
                return;
            }
            foreach (var p in peopleList)
            {
                Console.WriteLine($"{p.Id.ToString().PadLeft(4, ' ')} {p.Name.PadRight(10, ' ')}{p.LastName.PadRight(20, ' ')}{p.Age.ToString().PadRight(5, ' ')}{p.Gender}");
            }
            Console.WriteLine("People");
        }
    }
}
