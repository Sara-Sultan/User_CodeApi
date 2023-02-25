using Application.DTO;
using Application.IServices;
using Domain.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using System.Security.Cryptography;

namespace Application.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<UserDTO>> GetAllAsync(PagingInputDto pagingInputDto, CancellationToken cancellationToken = default)
        {
            var Users = await _repositoryManager.UserRepository.GetAllAsync(pagingInputDto, cancellationToken);

            var UsersDto = Mapping.MapperObject.Mapper.Map<IEnumerable<UserDTO>>(Users);

            return UsersDto;
        }

        public async Task<UserDTO> GetByIdAsync(string UserId, CancellationToken cancellationToken = default)
        {
            var User = await _repositoryManager.UserRepository.GetByIdAsync(UserId, cancellationToken);

            if (User is null)
            {
                throw new NotFoundException("User", UserId);
            }

            var UserDTO = Mapping.MapperObject.Mapper.Map<UserDTO>(User);

            return UserDTO;
        }

        public async Task<UserDTO> CreateAsync(UserForCreationDto UserForCreationDto, CancellationToken cancellationToken = default)
        {
            var User = Mapping.MapperObject.Mapper.Map<User>(UserForCreationDto);
            using var sha1 = SHA1.Create();
            User.ID = Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(User.Email)));
            _repositoryManager.UserRepository.Insert(User);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapping.MapperObject.Mapper.Map<UserDTO>(User);
        }

        public async Task UpdateAsync(string UserId, UserForUpdateDto UserForUpdateDto, CancellationToken cancellationToken = default)
        {
            var User = await _repositoryManager.UserRepository.GetByIdAsync(UserId, cancellationToken);

            if (User is null)
            {
                throw new NotFoundException("User", UserId);
            }

            User.FirstName = UserForUpdateDto.FirstName;
            User.lastName = UserForUpdateDto.lastName;
            User.Email = UserForUpdateDto.Email;
            User.MarketingConsent = UserForUpdateDto.MarketingConsent;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string UserId, CancellationToken cancellationToken = default)
        {
            var User = await _repositoryManager.UserRepository.GetByIdAsync(UserId, cancellationToken);

            if (User is null)
            {
                throw new NotFoundException("User", UserId);
            }

            _repositoryManager.UserRepository.Remove(User);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
