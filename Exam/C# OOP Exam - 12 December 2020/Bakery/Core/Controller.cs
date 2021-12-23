using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFood;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;
        public Controller()
        {
            bakedFood = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
               this.drinks.Add(new Tea(name, portion, brand));

            }
            else if (type == "Water")
            {
                this.drinks.Add(new Water(name, portion, brand));
            }

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                this.bakedFood.Add(new Bread(name, price));

            }
            else if (type == "Cake")
            {
                this.bakedFood.Add(new Cake(name, price));
            }

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));

            }
            else if (type == "OutsideTable")
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            string result = string.Empty;
            List<ITable> freeTables = tables.Where(table => !table.IsReserved).ToList();
            for (int i = 0; i < freeTables.Count; i++)
            {
                if (i != freeTables.Count - 1)
                {
                    result += freeTables[i].GetFreeTableInfo() + Environment.NewLine;

                }
                else
                {
                    result += freeTables[i].GetFreeTableInfo();
                }
            }
            return result;
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            decimal bill = table.GetBill() + table.Price;
            totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber}\r\n" +
                $"Bill: {bill:f2}";
            
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else
            {
                IDrink drink = drinks.FirstOrDefault(f => f.Name == drinkName && f.Brand == drinkBrand);
                if (drink == null)
                {
                    return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);

                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }

           
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else
            {
                IBakedFood food = bakedFood.FirstOrDefault(f => f.Name == foodName);
                if (food == null)
                {
                    return string.Format(OutputMessages.NonExistentFood, foodName);

                }
                else
                {
                    table.OrderFood(food);
                    return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);

                }
            }
        }

        public string ReserveTable(int numberOfPeople)
        {

            ITable desiredTable = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if (desiredTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                desiredTable.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, desiredTable.TableNumber, numberOfPeople);
            }


        }
    }
}
