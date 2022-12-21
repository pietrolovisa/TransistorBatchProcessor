﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransisterBatch.EntityFramework
{
    public interface IDbProvider
    {
        void SetupServices<TDbContext>(IServiceCollection services) where TDbContext : DbContext;
    }
}
