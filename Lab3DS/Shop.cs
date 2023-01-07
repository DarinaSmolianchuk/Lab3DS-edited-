using Lab3DS.Data;
using Lab3DS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS
{
    public class Shop
    {
        private ShopService shopService;

        public Shop()
        {
            //У нового магазина створюємо нову базу даних
            shopService = new ShopService(new DBContext());
        }

        //Метод 'Працювати'
        public void Work()
        {
            string username;
            int temporaryNumber = 0;

            do
            {
                //Виводимо інформацію про програму та просимо ввести юзернейм
                do
                {
                    Console.Clear();
                    Console.WriteLine("Вас вiтає Магазин.\nВведiть iм'я користувача (2-15 символiв).\nЯкщо бажаєте вийти -- введiть exit");
                    username = Console.ReadLine();
                    Console.Clear();
                    if (username == "exit")
                    {
                        Console.Clear();
                        Console.WriteLine("Магазин зачинився :с Приходьте завтра");
                        Console.ReadLine();
                        return;
                    }
                } while (username == "" || username.Length < 2 || username.Length > 15);

                //Отримуємо нашого користувача
                //Якщо такого немає, то створюється
                shopService.getUser(username);

                do
                {
                    //Вибір функції
                    //Основне меню
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Вiтаємо, " + username + "! " + " Ваш баланс: " + shopService.getUser(username).Balance +
                                          "\nЩо бажаєте зробити?\n1. Поповнити рахунок.\n2. Перейти до покупок.\n3. Переглянути iсторiю покупок.\n4. Вийти.");
                        temporaryNumber = SafeInput.readInt();
                    } while (temporaryNumber < 1 || temporaryNumber > 4);

                    switch (temporaryNumber)
                    {
                        //Поповнення рахунку.
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Поповнення рахунку.\nВведiть бажану суму поповнення:");
                            int summ = SafeInput.readInt();
                            //Змінюємо користувачу в базі даних баланс
                            shopService.getUser(username).addBalance(summ);
                            break;

                        case 2:
                            Console.Clear();
                            int index;
                            //Покупка
                            do
                            {
                                Console.WriteLine("Для покупки введiть ID товару.");
                                Console.WriteLine("Ваш баланс: " + shopService.getUser(username).Balance + " гривень.\n");
                                outputProductsList();
                                Console.Write("\n\t\t\t\t\t\t\t\t<<Вихiд з каталогу -- 0 >>\n");
                                Console.WriteLine();
                                index = SafeInput.readInt();
                                if (index == 0)
                                    break;

                                Console.Clear();
                                tryBuy(shopService.getUser(username).ID, index);
                                Console.WriteLine();
                            } while (index != 0);
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Iсторiя покупок користувача " + username + ":");
                            shopService.getUserHistory(shopService.getUser(username).ID);
                            Console.WriteLine("Для повернення назад -- натиснiть ENTER.");
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Дякуємо, що скористались магазином!");
                            Console.WriteLine("Для повторного входу -- натиснiть ENTER.");
                            Console.ReadLine();
                            break;
                    }
                } while (temporaryNumber != 4);
            } while (username != "exit");
        }



        //Купівля товару
        private void tryBuy(int userID, int productID)
        {
            //Якщо введено неправильно айді
            if (productID > shopService.Products.Count() || productID < 1)
            {
                Console.WriteLine("\t<<<УВАГА>>>\n\tПомилка! Товар не iснує!");
                return;
            }

            //Якщо товар закінчився
            if (shopService.Products[productID - 1].Count == 0)
            {
                Console.WriteLine("\t<<<УВАГА>>>\n\tПомилка! Товар закiнчився!");
                return;
            }

            //Якщо у користувача недостатньо грошей
            if (shopService.Products[productID - 1].Price > shopService.Users[userID].Balance)
            {
                Console.WriteLine("\t<<<УВАГА>>>\n\tНедостатньо коштiв! Поповнiть особистий рахунок та повторiть спробу!");
                return;
            }

            //Тепер можна і купити, якщо все в порядку
            History history = new History(userID, productID);

            //Змінюємо кількість товару і баланс
            shopService.Products[productID - 1].Count = shopService.Products[productID - 1].Count - 1;
            shopService.Users[userID].Balance = shopService.Users[userID].Balance - shopService.Products[productID - 1].Price;

            //Робимо запис в історію
            shopService.Histories.Add(history);
            shopService.Users[userID].Histories.Add(history);
            Console.WriteLine("\t<<<HОВЕ ПОВIДОМЛЕННЯ>>>\n\tУспiшно куплено " + shopService.Products[productID - 1].ProductName + "!");
        }

        //Виведення списку продуктів
        public void outputProductsList()
        {
            foreach (Product product in shopService.Products)
                Console.WriteLine(product.ToString());
        }

    }
}
