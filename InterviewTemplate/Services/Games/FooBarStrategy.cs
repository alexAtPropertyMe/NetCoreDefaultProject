using InterviewTemplate.Domain.Games;

namespace InterviewTemplate.Services.Games
{
    public interface IFooBarStrategy
    {
        bool ExectuteStrategy(FooBar fooBar);
    }

    public class FooStrategy : IFooBarStrategy
    {
        public bool ExectuteStrategy(FooBar fooBar)
        {
            return fooBar.Position % 3 == 0;
        }
    }

    public class BarStrategy : IFooBarStrategy
    {
        public bool ExectuteStrategy(FooBar fooBar)
        {
            return fooBar.Position % 5 == 0;
        }
    }

    public class FooBarStrategy : IFooBarStrategy
    {
        public bool ExectuteStrategy(FooBar fooBar)
        {
            return (fooBar.Position % 3 == 0) && (fooBar.Position % 5 == 0);
        }
    }

    public class DefaultStrategy : IFooBarStrategy
    {
        public bool ExectuteStrategy(FooBar fooBar)
        {
            return true;
        }
    }
}
