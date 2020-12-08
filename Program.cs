using DesignPatterns.Builder.FunctionalBuilder;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.ChainOfResponsibility.MethodChain;
using System;
using static System.Console;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pb = new PersonBuilder();
            //var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();
            //Console.WriteLine("Hello World!");

            //TestChainOfCommand();
            TestGreetingsChainOfCommand();
        }
        public static void TestGreetingsChainOfCommand()
        {
            var diabeticGuest = new Guest(true);
            var nonDiabeticGuest= new Guest(false);
            var greet = new HospitalityAction();
            greet.Add(new SayHelloAction());
            greet.Add(new ProvideCoffeeAction());

            greet.Handle(diabeticGuest);
            WriteLine("Next Please!!");
            greet.Handle(nonDiabeticGuest);
        }

        public static void TestChainOfCommand()
        {
            var goblin = new Creature("Goblin", 2, 2);
            WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            //root.Add(new NoBonusesModifier(goblin));

            WriteLine("Let's double goblin's attack...");
            root.Add(new DoubleAttackModifier(goblin));

            WriteLine("Let's increase goblin's defense");
            root.Add(new IncreaseDefenseModifier(goblin));

            // eventually...
            root.Handle();
            WriteLine(goblin);
        }
    }
}
