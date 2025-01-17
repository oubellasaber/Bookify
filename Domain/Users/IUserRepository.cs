﻿namespace Bookify.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(User user);
    }
}
