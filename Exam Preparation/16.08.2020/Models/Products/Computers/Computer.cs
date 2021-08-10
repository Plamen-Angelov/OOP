using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private double overallPerformance;
        private decimal price;
        private List<Components.IComponent> components = new List<Components.IComponent>();
        private List<IPeripheral> peripherals = new List<IPeripheral>();

        public IReadOnlyCollection<Components.IComponent> Components { get; }

        public IReadOnlyCollection<IPeripheral> Peripherals { get; } 

        public double OverallPerformance
        {
            get
            {
                return overallPerformance;
            }
            private set
            {
                if (Components.Count == 0)
                {
                    overallPerformance = value;
                }
                else
                {
                    overallPerformance = value + Components.Average(c => c.OverallPerformance);
                }
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                decimal componentsPrice = Components.Sum(c => c.Price);
                decimal peripheralsPrice = Peripherals.Sum(p => p.Price);

                price = value + componentsPrice + peripheralsPrice;
            }
        }
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Components = new List<Components.IComponent>(components);
            Peripherals = new List<IPeripheral>(peripherals);
        }

        public void AddComponent(Components.IComponent component)
        {
            if (Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, 
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public Components.IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || components.Any(c => c.GetType().Name == componentType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, 
                    componentType, this.GetType().Name, this.Id));
            }

            Components.IComponent component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || peripherals.Any(c => c.GetType().Name == peripheralType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheial = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            peripherals.Remove(peripheial);
            return peripheial;
        }

        public override string ToString()
        {
            return base.ToString();

            Console.WriteLine($" Components ({Components.Count}):");
            foreach (var component in Components)
            {
                Console.WriteLine($"  {component.GetType().Name}");
            }

            string.Format(SuccessMessages.ComputerPeripheralsToString, Peripherals.Count,
                Peripherals.Average(p => p.OverallPerformance));

            foreach (var peripheral in Peripherals)
            {
                Console.WriteLine(  Peripherals.GetType().Name);
            }
        }
    }
}
