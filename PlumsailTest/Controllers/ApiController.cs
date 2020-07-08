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
		private readonly ISearchService _searchService;
		private readonly IMapper _mapper;

		private readonly CommonResult _defaultResult = new CommonResult
		{
			ErrorMessage = "Ошибка заполнения формы"
		};

		#endregion

		#region constructor

		public ApiController(ISubmissionsService submissionsService, 
			IMapper mapper, 
			ISearchService searchService)
		{
			_submissionsService = submissionsService ?? throw new ArgumentNullException(nameof(submissionsService));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
		}

		#endregion

		[Route("addParameters")]
		public IActionResult AddParameters(List<FormField> fields)
		{
			#region validation

			if (fields == null)
			{
				return BadRequest(GetSerializedResult(_defaultResult));
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(GetSerializedResult(_defaultResult));
			}

			#endregion

			_submissionsService.SaveSubmission(new SubmissionDto{ Fields = fields });

			return Ok(GetSerializedResult(new CommonResult
			{
				Success = true,
				ErrorMessage = null
			}));
		}

		[Route("getSearchResult")]
		public async Task<IActionResult> GetSearchResult(string phrase)
		{
			#region valodation

			if(string.IsNullOrWhiteSpace(phrase))
				return BadRequest(GetSerializedResult(_defaultResult));

			#endregion

			var searchResult = await _searchService.Find(phrase);

			return Ok(JsonConvert.SerializeObject(searchResult, Formatting.None, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			}));
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
