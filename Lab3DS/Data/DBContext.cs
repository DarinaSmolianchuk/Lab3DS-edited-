using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    //Наша база даних. Саме вона відповідає за взаємодію даних
    public class DBContext
    {
        //Список всіх користувачів
        public List<User> Users { get; set; }

        //Історія покупок. Хто купив і що саме
        public List<History> Histories { get; set; }

        //Список продуктів
        public List<Product> Products { get; set; }

        //Конструктор
        public DBContext()
        {
            Users = new List<User>();
            Histories = new List<History>();
            Products = new List<Product>
            {
                new Product("Яблуко червоне", 10, 113),
                new Product("Xlaomi Note 8T", 6199, 3),
                new Product("Генератор (бенз.)", 79900, 1),
                new Product("Скретч-карта", 1000, 10),
                new Product("Коробка свiчок", 10, 34),
                new Product("Радiо аналогове", 860, 9),
                new Product("Хом'ячок плюшевий", 249, 17),
                new Product("Монiтор Asus 24`", 6499, 7)
            };
        }
    }
}
