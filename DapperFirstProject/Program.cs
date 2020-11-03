using Dapper;
using System;
using System.Data.SqlClient;

namespace DapperFirstProject
{
    class Program
    {
//        GO
//CREATE TABLE PRODUCTS(
//Id int identity(1,1),
//Name nvarchar(100),
//Price decimal (18,3),
//Stock int,
//primary key(Id)
//)
        static void Main(string[] args)
        {

            //var con = new SqlConnection();
            //con.ConnectionString = "server=DESKTOP-3VB3SSC\\SQLEXPRESS;database=DAPPERDB;integrated security=true";
            //var cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into PRODUCTS values('iphone6',5000,40)";
            //con.Open();
            //var detail=  cmd.ExecuteNonQuery();
            //con.Close();
            //Console.WriteLine("İşlem tamamlandı "+detail.ToString());
            var con = new SqlConnection();
            con.ConnectionString = "server=DESKTOP-3VB3SSC\\SQLEXPRESS;database=DAPPERDB;integrated security=true";

            //con.Execute("insert into products values('Klavye',20,100)");
            con.Execute("insert into products values(@name,@price,@stock)",new { 
            name = "Laptop",
            price = 5000,
            stock=50
            });

        }
    }
}
