using AppAcademy.Core.Repositories;

namespace AppAcademy.Data.Implementations
{
       public interface IUnitOfWork
    {
        void Commit();
        public IGroupRepository groupRepository { get; }
    }
}
