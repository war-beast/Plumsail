using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Interfaces;
using PlumsailTest.BLL.Models;
using PlumsailTest.BLL.Models.ViewModels;

namespace PlumsailTest.Controllers
{
	[Route("api/common")]
	[ApiController]
	public class ApiController : ControllerBase
	{
		#region private members

		private readonly ISubmissionsService _submissionsService;
		private readonly IMapper _mapper;

		#endregion

		#region constructor

		public ApiController(ISubmissionsService submissionsService, IMapper mapper)
		{
			_submissionsService = submissionsService ?? throw new ArgumentNullException(nameof(submissionsService));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		#endregion

		[Route("createItem")]
		public IActionResult CreateItem(List<FormField> fields)
		{
			var result = new CommonResult {
				ErrorMessage = "Ошибка заполнения формы"
			};

			#region validation

			if (fields == null)
			{
				return BadRequest(GetSerializedResult(result));
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(GetSerializedResult(result));
			}

			#endregion

			_submissionsService.SaveSubmission(new SubmissionDto{ Fields = fields });
			result = new CommonResult
			{
				Success = true,
				ErrorMessage = null
			};

			return Ok(GetSerializedResult(result));
		}

		#region private methods

		private static string GetSerializedResult(CommonResult result)
		{
			return JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});
		}

		#endregion
	}
}
