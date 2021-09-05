namespace InterviewTemplate.Domain.Games
{
    public static class FooBarExtensions
    {
        public static bool HasValidPosition(this FooBar fooBar)
        {
            return fooBar.Position > 0 ? true : false;
        }

        public static bool HasValidAnswer(this FooBar fooBar)
        {
            return !string.IsNullOrEmpty(fooBar.Answer);
        }
    }
}
