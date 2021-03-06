﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ToggleApp.Domain.Entities;

namespace ToggleApp.Domain.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllAsync();
        Task<Application> GetByIdAsync(int id);
    }
}
