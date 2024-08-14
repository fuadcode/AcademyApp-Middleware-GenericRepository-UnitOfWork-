using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Application.Exceptions;
using AppAcademy.Application.Services.Interfaces;
using AppAcademy.Core.Entities;
using AppAcademy.Data.Implementations;
using AutoMapper;

namespace AppAcademy.Application.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Create(GroupCreateDto groupCreateDto)
        {
            if (await _unitOfWork.groupRepository.isExists(g => g.Name.ToLower() == groupCreateDto.Name.ToLower()))
                throw new CustomExceptions(400, "Name", "Dublicate is not permitted");

            var group = _mapper.Map<Group>(groupCreateDto);
            await _unitOfWork.groupRepository.Create(group);
            _unitOfWork.Commit();

            return group.Id;
        }

        public async Task<List<Group>> GetAll()
        {
            return await _unitOfWork.groupRepository.GetAll();
        }

        public async Task<Group> GetOne(string name)
        {
            return await _unitOfWork.groupRepository.GetEntity(g => g.Name == name, "Students");
        }

    }
}
