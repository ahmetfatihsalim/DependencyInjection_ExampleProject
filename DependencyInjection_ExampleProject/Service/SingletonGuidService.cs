using DependencyInjection_ExampleProject.Service.Interface;
using System;

namespace DependencyInjection_ExampleProject.Services
{
    public class SingletonGuidService : ISingletonGuidService
    {
        private readonly Guid ID;
        public SingletonGuidService()
        {
            ID = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return ID.ToString();
        }
    }
}
