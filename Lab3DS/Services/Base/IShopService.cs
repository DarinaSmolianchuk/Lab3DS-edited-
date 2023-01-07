using Lab3DS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Services.Base
{
    public interface IShopService
    {
        //Метод для отримування користувача
        User getUser(string username);

        //Історія покупок користувача
        void getUserHistory(int userID);
    }
}
