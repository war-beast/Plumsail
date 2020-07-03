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

			CreateMap<SubmissionViewModel, SubmissionDto>()
				.ForMember(destination => destination.Value, opt => opt.MapFrom(source => source.SerializedJsonValue));
			CreateMap<SubmissionDto, SubmissionViewModel>()
				.ForMember(destination => destination.SerializedJsonValue, opt => opt.MapFrom(source => source.Value)); ;
		}
	}
}
