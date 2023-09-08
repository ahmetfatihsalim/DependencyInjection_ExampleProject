using DependencyInjection_ExampleProject.Service.Interface;

namespace DependencyInjection_ExampleProject.Service
{
    public class TransientGuidService : ITransientGuidService
    {
        private readonly Guid ID;
        public TransientGuidService()
        {
            ID = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return ID.ToString();
        }
    }
}
