using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(IPagingInputDto pagingInputDto, CancellationToken cancellationToken = default);

        Task<User> GetByIdAsync(string UserId, CancellationToken cancellationToken = default);

        void Insert(User User);

        void Remove(User User);
    }
}
