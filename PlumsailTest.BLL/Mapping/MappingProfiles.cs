using AutoMapper;
using PlumsailTest.BLL.DTO;
using PlumsailTest.BLL.Models.ViewModels;
using PlumsailTest.DAL.Entities;

namespace PlumsailTest.BLL.Mapping
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Submission, SubmissionDto>();
			CreateMap<SubmissionDto, Submission>();
		}
	}
}
