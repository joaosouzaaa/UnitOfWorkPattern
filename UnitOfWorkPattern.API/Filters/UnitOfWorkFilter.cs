using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using UnitOfWorkPattern.API.Interfaces.Settings;
using UnitOfWorkPattern.API.Interfaces.UnitOfWork;

namespace UnitOfWorkPattern.API.Filters;

public sealed class UnitOfWorkFilter(IUnitOfWork unitOfWork, INotificationHandler notificationHandler) : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Request.Method is WebRequestMethods.Http.Get)
            return;

        if (context.Exception is null && context.ModelState.IsValid && !notificationHandler.HasNotifications())
            unitOfWork.CommitTransaction();
        else
            unitOfWork.RollbackTransaction();

        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Request.Method is WebRequestMethods.Http.Get)
            return;

        unitOfWork.BeginTransaction();

        base.OnActionExecuting(context);
    }
}
