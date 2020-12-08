using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class Customer
    {
        public readonly string Name;
        public double Discount;

        public Customer(string name)
        {
            this.Name = name;
        }
    }

    public class CustomerFunctionalBuilder
    {
        private readonly List<Action<Customer>> actions = new List<Action<Customer>>();

        public CustomerFunctionalBuilder GrantTwentyPercentDiscount()
        {
            actions.Add(c => c.Discount += 20);
            return this;
        }

        public CustomerFunctionalBuilder GrantThirtyPercentDiscount()
        {
            actions.Add(c => c.Discount += 30);
            return this;
        }

        public Customer Calculate(Customer c)
        {
            actions.ForEach(a => a(c));
            return c;
        }
    }
}
