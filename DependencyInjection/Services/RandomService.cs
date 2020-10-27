using System;

namespace DependencyInjection.Services
{
    public class RandomService
    {
        private readonly int _randonNumber;

        public RandomService()
        {
            _randonNumber = new Random().Next();
        }

        public int GetNumber() => _randonNumber;
    }
}
