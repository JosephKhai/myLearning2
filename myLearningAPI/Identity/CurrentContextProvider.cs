using myLearning.Common.Entities;
using myLearning.Common.Infrastructure.IServices;


namespace myLearningAPI.Identity
{
    public class CurrentContextProvider: ICurrentContextProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentContextProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ContextSession GetCurrentContext()
        {
            if (_contextAccessor.HttpContext?.User != null && _contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var currentUserId = _contextAccessor.HttpContext.User.GetUserId();

                if (currentUserId > 0)
                {
                    return new ContextSession
                    {
                        UserId = currentUserId
                        //org code will go here
                    };
                }


            }

            return null;
        }
    }
}
