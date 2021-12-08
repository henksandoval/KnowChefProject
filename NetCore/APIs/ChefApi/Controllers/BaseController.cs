﻿namespace Chef.Api.Controllers
{
	using System.ComponentModel;
	using Chef.Shared.Enums;
	using Chef.Shared.Resources;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	[ApiController]
	[Produces("application/json")]
	public abstract class BaseController<TController> : ControllerBase
	{
		protected readonly ILogger<TController> logger;
		protected string? ControllerNameTranslated => SharedResource.ResourceManager.GetString(GetType().Name);

		public BaseController(ILogger<TController> logger)
		{
			this.logger = logger;
		}

		protected object GenerateMessageTranslated(string recordName, TypeAction typeAction)
		{
			switch (typeAction)
			{
				case TypeAction.Create:
					return GenerateMessageCreateTranslated(recordName);
				case TypeAction.Update:
					return GenerateMessageUpdateTranslated(recordName);
				case TypeAction.Delete:
					return GenerateMessageDeleteTranslated(recordName);
				default:
					throw new InvalidEnumArgumentException($"The type {typeAction} not is a type selector valid.");
			}
		}

		private object GenerateMessageCreateTranslated(string recordName)
		{
			var head = SharedResource.Create;
			var body = SharedResource.ConfirmationMessageCreate.Replace("{0}", recordName);
			return new { Head = head, Body = body };
		}

		private object GenerateMessageUpdateTranslated(string recordName)
		{
			var controllerNameTranslated = SharedResource.ResourceManager.GetString(GetType().Name);
			var head = SharedResource.Updated;
			var body = SharedResource.ConfirmationMessageUpdate.Replace("{0}", recordName);
			return new { Head = head, Body = body };
		}

		private object GenerateMessageDeleteTranslated(string recordName)
		{
			var head = SharedResource.Delete;
			var body = SharedResource.ConfirmationMessageDelete.Replace("{0}", recordName); ;
			return new { Head = head, Body = body };
		}

		protected IActionResult NotFoundRecord(long id)
		{
			logger.LogInformation(nameof(NotFoundRecord), id, "Not Found");
			return NotFound(id);
		}
	}
}