using OnlineShop.Common.Constants;
using OnlineShop.Models;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = GetComputer(computerId);

            Type type = GetType(componentType, ExceptionMessages.InvalidComponentType);
            IComponent typeInstance = default;
            try
            {
                typeInstance = (IComponent)Activator
               .CreateInstance(type, new object[] {
                    id,
                    manufacturer,
                    model,
                    price,
                    overallPerformance,
                    generation
               });
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }


            if (computer.Components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            this.components.Add(typeInstance);
            computer.AddComponent(typeInstance);
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            Type type = GetType(computerType, ExceptionMessages.InvalidComputerType);
            IComputer typeInstance = default;
            try
            {
                typeInstance = (IComputer)Activator
                    .CreateInstance(type, new object[] {
                        id,
                        manufacturer,
                        model,
                        price
                    });
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            this.computers.Add(typeInstance);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = GetComputer(computerId);

            Type type = GetType(peripheralType, ExceptionMessages.InvalidPeripheralType);
            IPeripheral typeInstance = default;
            try
            {
                typeInstance = (IPeripheral)Activator
               .CreateInstance(type, new object[] {
                    id,
                    manufacturer,
                    model,
                    price,
                    overallPerformance,
                    connectionType
               });
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }


            if (computer.Peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            this.peripherals.Add(typeInstance);
            computer.AddPeripheral(typeInstance);
            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers
                .Where(c => c.Price <= budget)
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault();

            if (computer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = GetComputer(id);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            return GetComputer(id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = GetComputer(computerId);
            computer.RemoveComponent(componentType);

            IComponent component = components
                .First(c => c.GetType().Name == componentType);

            this.components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = GetComputer(computerId);
            computer.RemovePeripheral(peripheralType);

            IPeripheral peripheral = peripherals
                .First(c => c.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private Type GetType(string productType, string exceptionMessage)
        {
            Type type = default;
            try
            {
                type = Assembly
                   .GetCallingAssembly()
                   .GetTypes()
                   .First(x => x.Name == productType);
            }
            catch (Exception)
            {
                throw new ArgumentException(exceptionMessage);
            }

            return type;
        }

        private IComputer GetComputer(int id)
        {
            IComputer computer = this.computers
                .FirstOrDefault(c => c.Id == id);

            if (computer is null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer;
        }
    }
}
