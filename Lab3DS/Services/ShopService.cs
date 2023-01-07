using Lab3DS.Data;
using Lab3DS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Services
{
    class ShopService : IShopService
    {
        //База даних
        private DBContext database;

        public List<Product> Products
        {
            get { return database.Products; }
        }

        public List<User> Users
        {
            get { return database.Users; }
        }

        public List<History> Histories
        {
            get { return database.Histories; }
        }

        //Конструктор
        public ShopService(DBContext database)
        {
            this.database = database;
        }

        //Метод для отримування користувача
        //Якщо користувач не існує -- створюємо нового і додаємо в БД.
        public User getUser(string username)
        {
            foreach (User user in database.Users)
            {
                if (user.Name == username)
                    return user;
            }

            //Якщо нема, то додаємо
            database.Users.Add(new User(username));
            return database.Users[database.Users.Count - 1];
        }

        //Історія покупок користувача
        public void getUserHistory(int userID)
        {
            //Якщо покупок не було
            if (database.Users[userID].Histories.Count() == 0)
            {
                Console.WriteLine("Покупок ще не було!");
                return;
            }

            //Якщо були -- виводимо
            Console.WriteLine("Зроблено " + database.Users[userID].Histories.Count() + " покупок!");
            Console.WriteLine("ID:\tДата покупки:\t\tТовар:");
            foreach (History history in database.Histories)
            {
                if (history.UserID == userID)
                    Console.WriteLine(history.ID + ".\t" + history.DateOfPurchase + ".\t" + database.Products[history.ProductID - 1].ProductName + ".");
            }
        }
    }
}
