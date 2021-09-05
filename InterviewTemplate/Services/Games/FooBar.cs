using InterviewTemplate.Domain.Games;

namespace InterviewTemplate.Services.Games
{
    public interface IFooBarGameService
    {
        bool ExecuteGame(FooBar fooBar);
    }

    public class FooBarService : IFooBarGameService
    {
        private readonly IFooBarExecutionFactory _fooBarExecutionFactory;

        public FooBarService(IFooBarExecutionFactory fooBarExecutionFactory)
        {
            _fooBarExecutionFactory = fooBarExecutionFactory;
        }

        public bool ExecuteGame(FooBar fooBar)
        {
            if (!(fooBar.HasValidPosition() 
                && fooBar.HasValidAnswer()))
                return false;

            var gameStrategy = _fooBarExecutionFactory.GetFooBarExecutionStrategy(fooBar);

            return gameStrategy.ExectuteStrategy(fooBar);
        }
    }
}
