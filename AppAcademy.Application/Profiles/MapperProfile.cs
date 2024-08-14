using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Application.Dtos.StudentDtos;
using AppAcademy.Application.Extensions;
using AppAcademy.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AppAcademy.Application.Profiles
{
    public class MapperProfile : Profile
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public MapperProfile(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var request = _contextAccessor.HttpContext.Request;
            var urlBuilder = new UriBuilder(
                request.Scheme,
                request.Host.Host,
                request.Host.Port.Value
                );
            var url = urlBuilder.Uri.AbsoluteUri;

            //group uchun ..
            CreateMap<GroupCreateDto, Group>();

            //student uchun ..
            CreateMap<StudentCreateDto, Student>().ForMember(s => s.FileName, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "uploads/images/")));
            CreateMap<Student, StudentReturnDto>().ForMember(d => d.FileName, map => map.MapFrom(d => url + "uploads/images/" + d.FileName));

        }
    }
}
