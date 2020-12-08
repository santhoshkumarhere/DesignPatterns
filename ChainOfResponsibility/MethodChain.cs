namespace DesignPatterns.ChainOfResponsibility.MethodChain
{
    using System;
    using static System.Console;

        public class Creature
        {
            public string Name;
            public int Attack, Defense;

            public Creature(string name, int attack, int defense)
            {
                Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
                Attack = attack;
                Defense = defense;
            }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class CreatureModifier
        {
            protected Creature creature;
            protected CreatureModifier next;

            public CreatureModifier(Creature creature)
            {
                this.creature = creature ?? throw new ArgumentNullException(paramName: nameof(creature));
            }

            public void Add(CreatureModifier cm)
            {
                if (next != null) next.Add(cm);
                else next = cm;
            }

            public virtual void Handle() => next?.Handle();
        }

        public class DoubleAttackModifier : CreatureModifier
        {
            public DoubleAttackModifier(Creature creature) : base(creature)
            {
            }

            public override void Handle()
            {
                WriteLine($"Doubling {creature.Name}'s attack");
                creature.Attack *= 2;
                // base.Handle();
                next?.Handle(); //I'm confortable using this
            }
        }

        public class IncreaseDefenseModifier : CreatureModifier
        {
            public IncreaseDefenseModifier(Creature creature) : base(creature)
            {
            }

            public override void Handle()
            {
                WriteLine("Increasing goblin's defense");
                creature.Defense += 3;
                base.Handle();
            }
        }


        public class NoBonusesModifier : CreatureModifier
        {
            public NoBonusesModifier(Creature creature) : base(creature)
            {
            }

            public override void Handle()
            {
                // nothing
                WriteLine("No bonuses for you!");
            }
        }
}
