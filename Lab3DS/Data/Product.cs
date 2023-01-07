using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class Product
    {
        //Генератор айдішок. Починається 1 для кращого сприйняття користувачем в консолі
        private static int numberOfProducts = 1;
        public int ID { get; }
        //Назва, ціна, кількість на складі
        public string ProductName { get; }
        public int Price { get; }
        private int count = 0;
        public int Count
        {
            get { return count; }
            set
            {
                if (value < 0)
                    return;
                else
                    count = value;
            }
        }

        //Конструктор
        public Product(string productName, int price, int count)
        {
            ID = numberOfProducts++;
            //Товару на складі не може бути менше 0
            if (count >= 0)
                Count = count;
            else
                Count = 0;

            //Ціна не може бути нульовою
            if (price < 0)
            {
                Price = 0;
            }
            else
            {
                Price = price;
            }
            ProductName = productName;
        }

        //Перевизначення функції для нормального виведення
        public override string ToString()
        {
            return ID + ". " + ProductName + ".\t\tЦiна: " + Price + "\tгрн.\t\tКiлькiсть на складi: " + Count + ".";
        }
    }
}