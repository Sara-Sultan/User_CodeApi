using Domain;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<User>> GetAllAsync(IPagingInputDto pagingInputDto, CancellationToken cancellationToken = default)
        {

            var query = _dbContext.Users.AsQueryable();
            var page = query.Skip((pagingInputDto.PageNumber * pagingInputDto.PageSize) - pagingInputDto.PageSize).Take(pagingInputDto.PageSize);
            return await page.ToListAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(string UserId, CancellationToken cancellationToken = default) =>
            await _dbContext.Users
            .FirstOrDefaultAsync(x => x.ID == UserId, cancellationToken);

        public void Insert(User User) => _dbContext.Users.Add(User);

        public void Remove(User User) => _dbContext.Users.Remove(User);
    }
}