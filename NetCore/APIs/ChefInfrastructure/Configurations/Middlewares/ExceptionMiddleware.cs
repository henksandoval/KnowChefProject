namespace Chef.Infrastructure.Configurations.Middlewares
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Net;
	using System.Text;
	using System.Threading.Tasks;
	using Chef.Core.Domains.Exceptions;
	using Chef.Infrastructure.Configurations.Models;
	using Chef.Shared.Enums;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Diagnostics;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Hosting;
	using Newtonsoft.Json;

	public class ExceptionMiddleware
	{
		private readonly RequestDelegate next;
		private readonly IHostEnvironment env;

		public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
		{
			this.next = next;
			this.env = env;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex, env.IsDevelopment());
			}
		}

		private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception, bool includeDetails)
		{
			httpContext.Response.ContentType = ApiProduces.ContentType;
			httpContext.Response.StatusCode = (int) (exception is DomainException ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError);
			
			var error = new ErrorDetail
			{
				Title = "An error occurred",
				Status = httpContext.Response.StatusCode,
			};

			if (exception is DomainException domainException)
			{
				error.CodeError = domainException.CodeError;
				error.Detail = domainException.Message;
			}
			if (includeDetails)
			{
				error.Type = exception.GetType().Name;
				error.Detail = exception.Message;
				error.TraceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier ?? string.Empty;
				error.StackTrace = exception.StackTrace;
			}

			return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error, Formatting.Indented, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			}));
		}
	}
}
