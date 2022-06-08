using JustSports.WebApi.Models;
using System.Net;

namespace JustSports.WebApi.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (AccessViolationException avEx)
			{				
				await HandleExceptionAsync(httpContext, avEx);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var message = exception switch
			{
				//CustomerAuthenticationFailureException => "Incorrect username or password.",
				AccessViolationException => "Access violation error from the custom middleware",
				
				_ => "Internal Server Error from the custom middleware."
			};

			_logger.LogError($"Error: {message}");

			await context.Response.WriteAsync(new ErrorDetails()
			{
				StatusCode = context.Response.StatusCode,
				Message = message
			}.ToString());
		}
	}
}
