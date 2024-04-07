using myLearning.Common.Entities;
using myLearning.Common.Infrastructure.IServices;

namespace myLearning.Common.Service
{
    public abstract class BaseService
    {
        protected ICurrentContextProvider currentContextProvider;
        protected readonly ContextSession _session;

        protected BaseService(ICurrentContextProvider currentContextProvider)
        {
            this.currentContextProvider = currentContextProvider;
            _session = currentContextProvider.GetCurrentContext();
        }
    }
}
