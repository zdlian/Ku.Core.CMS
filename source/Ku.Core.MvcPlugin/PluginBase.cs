﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Ku.Core.MvcPlugin
{
    public abstract class PluginBase : IPluginStartup
    {
        public abstract void ConfigureServices(IServiceCollection serviceCollection);
    }
}
