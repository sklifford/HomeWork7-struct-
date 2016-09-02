using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _7_1_Check
{
     enum Discount
    {
        Default = 0, Incentive = 2, Patron = 5, VIP = 15
    }

    struct Check
    {
        ArrayList products;

        struct Product
        {
            public string name;
            public float quantity;
            public double price;
            public Discount discount;

            public Product(string name, float quantity, double price, Discount discount)
            {
                this.name = name;
                this.quantity = quantity;
                this.price = price;
                this.discount = discount;
            }
        }

        public void AddProduct(string name, float quantity, double price, Discount discount)
        {
            if (products == null)
                products = new ArrayList();
            products.Add(new Product(name, quantity, price, discount));
        }

        public void Print()
        {
            double total = 0;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0,37}","ООО \"Ашан\"            ");
            Console.WriteLine("{0,37}", "ДОБРО ПОЖАЛОВАТЬ!          ");
            Console.WriteLine("                                     ");
            Console.WriteLine("{0}                  ", DateTime.Now);
            foreach (Product prod in products)
            {
                if (prod.discount == 0)
                {
                    Console.WriteLine("{0,29:N2} х {1,-5:N2}", prod.quantity, prod.price);
                    Console.WriteLine("{0,-31} {1,-5:N2}", prod.name, prod.quantity * prod.price);
                    total += prod.quantity * prod.price;
                }
                else
                {
                    Console.WriteLine("{0,29:N2} х {1,-5:N2}", prod.quantity, prod.price * (int)prod.discount);
                    Console.WriteLine("{0,-31} {1,-5:N2}", prod.name, prod.quantity*prod.price*(int)prod.discount);
                    Console.WriteLine("{0,34} {1}%", "Скидка", (int)prod.discount);
                    total += prod.quantity* prod.price * (int)prod.discount;
                }
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("                                     ");
            Console.WriteLine("{0,-30} {1,-5:N2}", "ИТОГ", total);
            Console.WriteLine("{0,-31} {1,-5:N2}", "В т.ч. НДС", total*0.2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Check check = new Check();
            check.AddProduct("Хлеб обеденный", 3, 5.56, Discount.Incentive);
            check.AddProduct("Масло сливочное", 2, 38.56, Discount.Patron);
            check.AddProduct("Икра красная", 1, 190.5, Discount.Default);
            check.Print();
        }
    }
}
