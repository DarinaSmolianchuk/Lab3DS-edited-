using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class History
    {
        //Генератор айдішок
        private static int numberOfPurchases = 0;
        public int ID { get; }

        //Хто купив і що саме
        public int UserID { get; }
        public int ProductID { get; }
        public DateTime DateOfPurchase { get; }

        public History(int userID, int productID)
        {
            ID = numberOfPurchases++;
            UserID = userID;
            ProductID = productID;
            DateOfPurchase = DateTime.Now;
        }
    }
}