using RideHailingAPI.Data;
using RideHailingAPI.Domain.Entities;
using RideHailingAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace RideHailingAPI.Repositories.Implementation;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByUserIdAsync(string userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task AddAsync(User user)
    {
         await _context.Users.AddAsync(user);
         await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        await _context.SaveChangesAsync();
    }
}