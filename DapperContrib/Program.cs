using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace DapperContrib
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = new SqlConnection();
            con.ConnectionString = "server=DESKTOP-3VB3SSC\\SQLEXPRESS;database=DAPPERDB;integrated security=true";
            var product =  con.Get<Product>(id: 1002);
            con.Insert<Product>(new Product { Name = "Yeni ürün",Price = 5000,Stock=400 });
            var products = con.GetAll<Product>().ToList();
            Console.WriteLine("Hello World!");
        }
    }
    class Product
    {
        public int Id { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }
}
