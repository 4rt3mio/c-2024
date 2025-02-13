using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Classes;

namespace Task
{
    public static class Input
    {
        public static void Run()
        {
            while (true)
            {
                bool isRight = true;
                int seatedPlaces = 0, totalPlaces = 0;
                double cost = 0;
                string? name = null;
                try
                {
                    Console.Write("Введите число заселенных мест в гостинице: ");
                    seatedPlaces = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите общее количество мест в гостинице: ");
                    totalPlaces = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите текущую стоимость проживания(тариф): ");
                    cost = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите название отеля: ");
                    name = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Введены некорректные данные!!!");
                    isRight = false;
                }
                if (isRight)
                {
                    var localHotel = Hotel.GetInstance();
                    localHotel.SetParams(seatedPlaces, totalPlaces, cost, name);
                    double t = localHotel.Revenue();
                    Console.WriteLine($"Полученная выручка гостиницы равняется {t}");
                }
                Console.WriteLine("Желате ли вы продолжить выполнение программы? Если да введите 'y' или строку, которая начинатеся с 'y'");
                var temp = Console.ReadLine();
                switch (temp)
                {
                    case "y": break;
                    default: return;
                }
            }
        }
    }
}
