using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.HLO
{
    public static class HelloSolution
    {
        public static string Hello(string? friendName)
        {
            if(String.IsNullOrWhiteSpace(friendName))
            {
                return "Hello World";
            }
            else{
                return friendName;
            }
        }
    }
}

