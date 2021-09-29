using System;

namespace MySqlDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var business = new PersonaBusiness();
            business.GetAll();
            business.GetById();
            business.Add();
            business.Delete();
            business.Update();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
