using System;
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
	[Route("api/[controller]")]
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
		public async Task<IActionResult> CreateItem(SubmissionViewModel model)
		{
			var result = new CommonResult {
				ErrorMessage = "Ошибка заполнения формы"
			};

			#region validation

			if (!ModelState.IsValid)
			{
				return BadRequest(JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				}));
			}

			#endregion

			_submissionsService.SaveSubmission(_mapper.Map<SubmissionDto>(model));
			result = new CommonResult
			{
				Success = true,
				ErrorMessage = null
			};

			return Ok(JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			}));
		}
	}
}
