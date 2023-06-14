using System;

namespace ATM_Console
{


    class Program
    {
        static int balance = 1000; 

        static void Main(string[] args)
        {
            Console.WriteLine("**** ATM xoş geldiniz ****");
            Console.WriteLine();

            Login();

            Console.ReadLine();
        }

        static void Login()
        {
            Console.Write("PIN kodunu daxil edin: ");
            string pin = Console.ReadLine();

            if (pin == "1")
            {
                ShowMenu();
            }
            else
            {
                Console.WriteLine("Yanlış PIN. Zəhmət olmasa yenidən cehd edin.");
                Login();
            }
        }

        static bool IsValidPin(string pin)
        {
            return pin.Length == 4 && int.TryParse(pin, out _);
        }

        static void ShowMenu()
        {
            Console.WriteLine("**** MENYU ****");
            Console.WriteLine("1. Balansı Yoxla");
            Console.WriteLine("2. Nakit Pul Çıxar");
            Console.WriteLine("3. Hesabdan Çıxış");
            Console.WriteLine();

            Console.Write("Emeliyyatı seçin (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckBalance();
                    break;
                case "2":
                    WithdrawCash();
                    break;
                case "3":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Yanlış seçim. Zehmet olmasa yenidən seçin.");
                    ShowMenu();
                    break;
            }
        }

        static void CheckBalance()
        {
            Console.WriteLine($"Cari bakiye: {balance} AZN");
            Console.WriteLine();
            ShowMenu();
        }

        static void WithdrawCash()
        {
            Console.Write("Çıxarmaq istediyiniz mebləği daxil edin: ");
            string amountString = Console.ReadLine();
            int a = Convert.ToInt32(amountString);

            int[] banknotes = { 200, 100, 50, 20, 10, 5, 1 };

            Console.WriteLine("Banknot Parçalama Neticesi:");

            foreach (int banknote in banknotes)
            {
                int count = a / banknote;
                if (count > 0)
                {
                    Console.WriteLine($"{count} dene {banknote} manat");
                    a %= banknote;
                }
            }




            if (int.TryParse(amountString, out int amount))
            {

                if (amount >= 1 && amount <= 1000)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                        Console.WriteLine($"{amount} AZN çekildi. Yeni bakiye: {balance} AZN");
                    }
                    else
                    {
                        Console.WriteLine("Cüzi bakiyə. Zəhmət olmasa uyğun bir məbləğ daxil edin.");
                    }
                }
                else
                {
                    Console.WriteLine("Yanlış məbləğ. Zəhmət olmasa 1 ilə 1000 arasında bir dəyər daxil edin.");
                }
            }
            else
            {
                Console.WriteLine("Yanlış məbləğ. Zəhmət olmasa bir tam sayı daxil edin.");
            }

            Console.WriteLine();
            ShowMenu();
        }

        static void Logout()
        {
            Console.WriteLine("Hesabdan çıxış edildi.");
            Console.WriteLine("İyi günler!");
        }
    }
}


