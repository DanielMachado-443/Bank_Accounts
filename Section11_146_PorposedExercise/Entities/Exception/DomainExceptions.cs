using System;

namespace Section11_146_PorposedExercise.Entities.Exception
{
    class DomainExceptions : ApplicationException
    {
        public DomainExceptions(string message) :base(message)
        {
        }
    }
}
