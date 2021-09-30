using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DapperConsole
{
    ///<summary>
    ///Initial Program
    ///</summary>
    class Program
    {
        ///<summary>
        ///Main method
        ///<summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var business = new PeopleBusiness();
            business.GetAll();
            business.GetById();
            business.Add();
            business.Delete();
            business.Update();

        }

       
    }
}
