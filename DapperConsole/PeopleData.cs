using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace DapperConsole
{
    public class PeopleData
    {
        readonly string connectionString;
        public PeopleData()
        {
            connectionString = @"Data Source=localhost\mssqlserverdev;Initial Catalog=DapperCourse;User Id=sa;Password=0kY_DrYN1(";
        }
        public int Add(People people)
        {
            var query = "INSERT INTO [dbo].[People] (Name, LastName, Age, Gender) VALUES(@Name, @LastName, @Age, @Gender)";
            var result = 0;
            using (var db = new SqlConnection(connectionString))
            {
                result = db.Execute(query, new { people.Name, people.LastName, people.Age, people.Gender });
            }
            return result;
        }

        public int Delete(int id)
        {
            var result = 0;
            var query = "DELETE FROM [dbo].[People] WHERE [Id] = @Id";
            using (var db = new SqlConnection(connectionString))
            {
                result = db.Execute(query, new { Id = id });
            }
            return result;
        }

        public int Update(People people)
        {
            var result = 0;
            var query = "UPDATE [dbo].[People] SET Name = @Name, LastName = @LastName, Age = @Age, Gender= @Gender WHERE [Id] = @Id";
            using (var db = new SqlConnection(connectionString))
            {
                result = db.Execute(query, new { people.Id, people.Name, people.LastName, people.Age, people.Gender });
            }
            return result;
        }
        public List<People> GetAll()
        {
            var result = new List<People>();
            var query = "select [Id], [Name], [LastName], [Age], [Gender] from[dbo].[People]";
            using (var db = new SqlConnection(connectionString))
            {
                result = db.Query<People>(query).ToList();
            }
            return result;
        }

        internal People GetById(int id)
        {
            var person = new People();
            var query = "select [Id], [Name], [LastName], [Age], [Gender] from[dbo].[People] WHERE Id = @Id";
            using (var db = new SqlConnection(connectionString))
            {
                person = db.QueryFirst<People>(query, new { Id = id });
            }
            return person;
        }
    }
}
