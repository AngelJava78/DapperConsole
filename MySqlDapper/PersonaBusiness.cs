using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDapper
{
    public class PersonaBusiness
    {
        readonly PersonaData data;
        public PersonaBusiness()
        {
            data = new PersonaData();
        }
        public void Add()
        {
            Console.WriteLine("New Persona");
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Apellidos: ");
            var apellidos = Console.ReadLine();
           
            var persona = new Persona
            {
                Nombre = nombre,
                Apellidos = apellidos,
              
            };
            var result = data.Add(persona);
            if (result > 0)
            {
                Console.WriteLine($"New Persona was added. Id: {result}.");
            }
            else
            {
                Console.WriteLine($"Error on insert new Persona!!");
            }

        }

        public void Delete()
        {
            GetAll();
            Console.WriteLine("Delete Persona");
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());


            var result = data.Delete(id);
            if (result > 0)
            {
                Console.WriteLine($"Deleted persona. Id: {result}.");
            }
            else
            {
                Console.WriteLine($"Error on deleted Persona!!");
            }
            GetAll();
        }
        public void Update()
        {
            GetAll();
            Console.WriteLine("Update Persona");
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("nombre:");
            var nombre = Console.ReadLine();
            Console.Write("Last nombre:");
            var apellidos = Console.ReadLine();
            
            var persona = new Persona
            {
                Id = id,
                Nombre = nombre,
                Apellidos = apellidos,
                
            };
            var result = data.Update(persona);
            if (result > 0)
            {
                Console.WriteLine($"Upated persona. Id: {result}.");
            }
            else
            {
                Console.WriteLine($"Error on updated Persona!!");
            }
            var person = data.GetById(id);
            ShowPerson(person);
        }
        public void GetAll()
        {
            var PersonaList = data.GetAll();
            ShowPerson(PersonaList);


        }
        public void GetById()
        {
            Console.WriteLine("Get Persona by id");
            Console.WriteLine("Id: ");
            var id = int.Parse(Console.ReadLine());
            var person = data.GetById(id);
            ShowPerson(person);
        }
        private void ShowPerson(Persona p)
        {
            Console.WriteLine("Persona");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"nombre: {p.Nombre}");
            Console.WriteLine($"apellidos: {p.Apellidos}");
            //Console.WriteLine($"Age: {p.Age}");
            //Console.WriteLine($"Gender: {p.Gender}");
        }
        private void ShowPerson(IEnumerable<Persona> PersonaList)
        {
            Console.WriteLine("Persona");
            Console.WriteLine("Id   Nombre      apellidos            ");
            foreach (var p in PersonaList)
            {
                Console.WriteLine($"{p.Id.ToString().PadLeft(4, ' ')} {p.Nombre.PadRight(10, ' ')}{p.Apellidos.PadRight(20, ' ')}");
            }
            Console.WriteLine("Persona");
        }
    }
}
