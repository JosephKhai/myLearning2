using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.DataAccess.EFCore
{
    public class StoreProcedureName
    {
        public static string GetAllCities = "[dbo].[GetAllCities]";
        public static string DeleteCity = "[dbo].[DeleteCity]";
        public static string DeleteCountry = "[dbo].[DeleteCountry]";
    }
}

