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
			CreateMap<Submission, SubmissionDto>()
				.ForMember(dest => dest.Fields, opt => opt.MapFrom(src => src.Parameters));
			CreateMap<SubmissionDto, Submission>()
				.ForMember(dest => dest.Parameters, opt => opt.MapFrom(src => src.Fields));

			CreateMap<FormField, FieldParameter>();
			CreateMap<FieldParameter, FormField>();
		}
	}
}
