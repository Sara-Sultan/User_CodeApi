using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync(PagingInputDto pagingInputDto, CancellationToken cancellationToken = default);

        Task<UserDTO> GetByIdAsync(string UserId, CancellationToken cancellationToken = default);

        Task<UserDTO> CreateAsync(UserForCreationDto UserForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(string UserId, UserForUpdateDto UserForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(string UserId, CancellationToken cancellationToken = default);
    }
}
