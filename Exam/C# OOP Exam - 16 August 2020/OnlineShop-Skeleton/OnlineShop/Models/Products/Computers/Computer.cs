using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
       

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
            
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (!this.Components.Any())
                {
                    return base.OverallPerformance;
                }

                var componentsAveragePerformance = this.Components.Any() ? this.Components.Average(c => c.OverallPerformance) : 0;

                return base.OverallPerformance + componentsAveragePerformance;
            }
        }

        public override decimal Price
        {
            get
            {
                decimal componentsPrice = this.Components.Any() ? this.Components.Sum(c => c.Price) : 0;
                decimal peripheralsPrice = this.Peripherals.Any() ? this.Peripherals.Sum(p => p.Price) : 0;

                return base.Price + componentsPrice + peripheralsPrice;
            }
        }
        public void AddComponent(IComponent component)
        {
            string componentType = component
                .GetType()
                .Name;

            if (this.Components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string peripheralType = peripheral
                .GetType()
                .Name;

            if (this.Peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.Components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent component = this.Components
                .First(c => c.GetType().Name == componentType);

            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals.All(c => c.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheral = this.Peripherals
                .First(c => c.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(" " + String.Format(SuccessMessages.ComputerComponentsToString, this.Components.Count));
            foreach (IComponent component in this.Components)
            {
                stringBuilder.AppendLine("  " + component.ToString());
            }

            stringBuilder.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString, this.Peripherals.Count,
                this.Peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0));
            foreach (var peripheral in this.Peripherals)
            {
                stringBuilder.AppendLine("  " + peripheral.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
