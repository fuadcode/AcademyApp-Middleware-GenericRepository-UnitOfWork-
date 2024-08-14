using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Core.Entities;

namespace AppAcademy.Application.Services.Interfaces
{
    public interface IGroupService
    {
        Task<int> Create(GroupCreateDto groupCreateDto);
        Task<List<Group>> GetAll();
        Task<Group> GetOne(string name);
    }
}
