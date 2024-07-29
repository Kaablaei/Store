using Application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Handler
{
    public sealed class  GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails = CreateProblemDetailFromException(exception);

            httpContext.Response.StatusCode = problemDetails.Status!.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static ProblemDetails CreateProblemDetailFromException(Exception exception)
        {
            return exception is CustomeException
                ? new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Bad Request",
                    Detail = exception.Message
                }
                : new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server error",
                    Detail = "Server error"
                };
        }

    }
}
