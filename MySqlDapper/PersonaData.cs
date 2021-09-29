using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDapper
{
    public class PersonaData
    {
        readonly string connectionString;
        public PersonaData()
        {
            connectionString = @"Data Source=localhost;Database=persona;Uid=root;pwd=Java781105m35$;Port=3306";
        }
        public int Add(Persona persona)
        {
            var query = "INSERT INTO Persona (Nombre, Apellidos) VALUES(@Nombre, @Apellidos)";
            var result = 0;
            using (var db = new MySqlConnection(connectionString))
            {
                result = db.Execute(query, new { persona.Nombre, persona.Apellidos});
            }
            return result;
        }

        public int Delete(int id)
        {
            var result = 0;
            var query = "DELETE FROM Persona WHERE Id = @Id";
            using (var db = new MySqlConnection(connectionString))
            {
                result = db.Execute(query, new { Id = id });
            }
            return result;
        }

        public int Update(Persona persona)
        {
            var result = 0;
            var query = "UPDATE Persona SET Nombre = @Nombre, Apellidos = @Apellidos WHERE Id = @Id";
            using (var db = new MySqlConnection(connectionString))
            {
                result = db.Execute(query, new { persona.Id, persona.Nombre, persona.Apellidos });
            }
            return result;
        }
        public List<Persona> GetAll()
        {
            var result = new List<Persona>();
            var query = "select Id, Nombre, Apellidos from Persona";
            using (var db = new MySqlConnection(connectionString))
            {
                result = db.Query<Persona>(query).ToList();
            }
            return result;
        }

        public Persona GetById(int id)
        {
            var person = new Persona();
            var query = "select Id, Nombre, Apellidos from Persona WHERE Id = @Id";
            using (var db = new MySqlConnection(connectionString))
            {
                person = db.QueryFirst<Persona>(query, new { Id = id });
            }
            return person;
        }
    }
}
