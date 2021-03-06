﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Ku.Core.Infrastructure.DependencyResolver;

namespace Ku.Core.CMS.Web.Filters
{
    public abstract class VinoActionAttribute : Attribute
    {
        public virtual void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public virtual void OnActionExecuted(ActionExecutedContext context)
        { 
        }

        public virtual async Task OnActionExecutionAsync(ActionExecutingContext context)
        {
            await Task.CompletedTask;
        }

        public virtual void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public virtual void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
        }

        public virtual void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
