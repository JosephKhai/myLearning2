using Microsoft.AspNetCore.Http;
using myLearning.Common.Entities;
using myLearning.Common.Infrastructure.IServices;
using myLearning.Common.WebApi.Identity;

namespace myLearning.Common.WebApi
{
    public class CurrentContextProvider : ICurrentContextProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentContextProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ContextSession GetCurrentContext()
        {
            if (_contextAccessor.HttpContext.User != null && _contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var currentUserId = _contextAccessor.HttpContext.User.GetUserId();

                if (currentUserId > 0)
                {
                    return new ContextSession { UserId = currentUserId };
                }
            }

            return null;
        }
    }
}
