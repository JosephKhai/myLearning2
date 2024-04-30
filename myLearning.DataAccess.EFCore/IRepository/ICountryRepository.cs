﻿using myLearning.Common.Entities;
using myLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLearning.DataAccess.EFCore.IRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Countries>> GetAllCountries();
        Task<Countries> GetCountryById(int Id);
        Task AddCounty(Countries newCountry);
        Task UpdateCountry(Countries updateCountry);
        Task DeleteCountry(int Id);
    }
}