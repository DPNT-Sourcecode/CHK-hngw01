﻿using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.HLO
{
    public static class HelloSolution
    {
        public static string Hello(string? friendName)
        {
            string returnMessage = "Hello, "+friendName+"!";
        return returnMessage;
        }
    }
}
