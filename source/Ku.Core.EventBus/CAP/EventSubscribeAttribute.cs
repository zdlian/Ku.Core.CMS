﻿using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.CAP;

namespace Ku.Core.EventBus.CAP
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class EventSubscribeAttribute : CapSubscribeAttribute
    {
        public EventSubscribeAttribute(string name) : base(name)
        {
        }
    }
}
