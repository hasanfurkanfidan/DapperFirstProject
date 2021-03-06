﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

            ////con.Execute("insert into products values('Klavye',20,100)");
            //con.Execute("insert into products values(@name,@price,@stock)",new { 
            //name = "Laptop",
            //price = 5000,
            //stock=50
            //});
            //con.Execute("insert into products values(@name,@price,@stock)",new[] {
            //new{name="Tv",price=6000,stock=5},
            //new{name="Mouse",price=50,stock=50},
            //});
            //con.Execute("update products set name='kitap',stock=500 where Id=2");
            //con.Execute("delete from Products where Id=@id", new[] { new { id = 1 }, new { id = 2 } });
            //var value = con.ExecuteScalar("select name from products");
            //Console.WriteLine(value.ToString());
            //var products = con.Query<Product>("select*from products");
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.Name);
            //}
            var productDictionary = new Dictionary<int,Product>();
           var products =  con.Query<Product,ProductCategory,Product>(@"Select * from PRODUCTS inner join ProductCategories on   PRODUCTS.Id = ProductCategories.ProductId   where  ProductCategories.CategoryId=4 ",(product,productCategory)=> {
               Product otherProduct;
               if (!productDictionary.TryGetValue(product.Id,out otherProduct))
               {
                   otherProduct = product;
                   otherProduct.ProductCategories = new List<ProductCategory>();
                   productDictionary.Add(product.Id, product);
               }
               otherProduct.ProductCategories.Add(productCategory);
               return otherProduct;
            }).Distinct().ToList();

            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }





        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
    public class ProductCategory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public Category Category { get; set; }

        public Product Product { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }


    }
}
