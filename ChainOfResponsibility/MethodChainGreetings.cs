using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ChainOfResponsibility
{
    public class Guest
    {
        public bool greetedWithHello, greetedWithCoffee;
        public readonly bool IsDiabetic;
        public int roses = 0;

        public Guest(bool isDiabetic)
        {
            this.IsDiabetic = isDiabetic;
        }
    }

    public class HospitalityAction
    {
        HospitalityAction next;

        public HospitalityAction()
        {
        }
        
        public void Add(HospitalityAction action)
        {
            if (next != null) next.Add(action);
            else next = action;
        }

        public virtual void Handle(Guest guest) => next?.Handle(guest);
    }

    public class SayHelloAction : HospitalityAction
    {
        public override void Handle(Guest guest)
        {
            Console.WriteLine("Greeted with Hello!!");
            guest.roses += 1;
            if (!guest.IsDiabetic)
            {
                base.Handle(guest);
            }
        }
    }

    public class ProvideCoffeeAction : HospitalityAction
    {
        public override void Handle(Guest guest)
        {
            Console.WriteLine("Greeted with Coffee!!");
            guest.roses += 1;
            base.Handle(guest);
        }
    }
}
