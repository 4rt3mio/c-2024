using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Classes
{
    public static class DemonstrationOfProgram
    {
        public static void Run()
        {
            Tariff tariff = new Tariff();
            tariff.SetPrice(UtilityType.Electricity, 0.15m);
            tariff.SetPrice(UtilityType.Water, 0.10m);
            tariff.SetPrice(UtilityType.Gas, 0.20m);
            tariff.SetPrice(UtilityType.Heating, 0.15m);

            Resident resident = new Resident("Иван", "Иванов");
            resident.Tariff = tariff;

            UtilityBill utilityBill1 = new UtilityBill(resident, UtilityType.Electricity, 100);
            UtilityBill utilityBill2 = new UtilityBill(resident, UtilityType.Water, 50);
            UtilityBill utilityBill3 = new UtilityBill(resident, UtilityType.Heating, 250);

            resident.AddUtilityBill(utilityBill1);
            resident.AddUtilityBill(utilityBill2);
            resident.AddUtilityBill(utilityBill3);

            Console.WriteLine("Сумма всех потребленных услуг: " + resident.TotalCostForAllUtilities());
            Console.WriteLine("Сумма за электричество: " + resident.TotalCostForUtility(UtilityType.Electricity));
            Console.WriteLine("Сумма за воду: " + resident.TotalCostForUtility(UtilityType.Water));
            Console.WriteLine("Сумма за отопление: " + resident.TotalCostForUtility(UtilityType.Heating));
        }
    }
}
