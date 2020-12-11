using DesignPatterns.Builder;
using DesignPatterns.Builder.FunctionalBuilder;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.ChainOfResponsibility.MethodChain;
using DesignPatterns.Composite;
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

            // TestFunctionalBuilder();

            // TestGreetingsChainOfCommand();
            TestCompositeGraphic();
        }

        public static void TestCompositeGraphic()
        {
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            WriteLine(drawing);
        }

        public static void TestFunctionalBuilder()
        {
            var customer = new Customer("Santhosh");
            var builder = new CustomerFunctionalBuilder();
            var result = builder.GrantThirtyPercentDiscount().GrantTwentyPercentDiscount().Calculate(customer);
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
