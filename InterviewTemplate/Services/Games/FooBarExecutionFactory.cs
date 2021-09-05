using InterviewTemplate.Domain.Games;
using System;

namespace InterviewTemplate.Services.Games
{
    public interface IFooBarExecutionFactory
    {
        IFooBarStrategy GetFooBarExecutionStrategy(FooBar fooBar);
    }

    public class FooBarExecutionFactory : IFooBarExecutionFactory
    {
        public IFooBarStrategy GetFooBarExecutionStrategy(FooBar fooBar)
        {
            IFooBarStrategy gameStrategy = null;

            if (fooBar.Answer.Equals(FooBarAnswers.Foo, StringComparison.InvariantCultureIgnoreCase))
                gameStrategy = new FooStrategy();
            else if (fooBar.Answer.Equals(FooBarAnswers.Bar, StringComparison.InvariantCultureIgnoreCase))
                gameStrategy = new BarStrategy();
            else if (fooBar.Answer.Equals(FooBarAnswers.FooBar, StringComparison.InvariantCultureIgnoreCase))
                gameStrategy = new FooBarStrategy();
            else
                gameStrategy = new DefaultStrategy();

            return gameStrategy;
        }
    }

    static class FooBarAnswers
    {
        public const string Foo = "Foo";
        public const string Bar = "Bar";
        public const string FooBar = "FooBar";
    }
}
