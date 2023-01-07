using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class User
    {
        //Генератор айдішок
        private static int numberOfUsers = 0;
        public int ID { get; set; }

        //Ім'я, баланс та історія покупок
        public string Name { get; set; }

        private int balance = 0;
        public int Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                    return;
                else
                    balance = value;
            }
        }
        public List<History> Histories { get; }

        public User(string name)
        {
            ID = numberOfUsers++;
            Name = name;
            Histories = new List<History>();
        }

        //Метод зміни балансу
        public void addBalance(int plusBalance)
        {
            if (plusBalance > 0)
                balance += plusBalance;
        }
    }
}
