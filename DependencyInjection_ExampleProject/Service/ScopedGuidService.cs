using DependencyInjection_ExampleProject.Service.Interface;
using System;

namespace DependencyInjection_ExampleProject.Service
{
    public class ScopedGuidService : IScopedGuidService
    {
        private readonly Guid ID;
        public ScopedGuidService()
        {
            ID = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return ID.ToString();
        }
    }
}
