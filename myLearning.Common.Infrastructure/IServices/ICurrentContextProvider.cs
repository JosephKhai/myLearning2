using myLearning.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.Common.Infrastructure.IServices
{
    public interface ICurrentContextProvider
    {
        ContextSession GetCurrentContext();
    }
}
