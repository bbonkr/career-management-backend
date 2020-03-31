using CareerManagement.Data;
using CareerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerManagement.Web.Stores
{
    public class CareerStore
    {
        public CareerStore(DataContext db) {
            this.db = db;
        }

        public async Task<User> FindByUserId(string userId)
        {
            return await db.Users
                .Include(u => u.Profile)
                .Include(u => u.Careers)
                .Include(u => u.Educations)
                .Include(u => u.Portfolios)
                .Include(u => u.Skills)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }

        public Task<User> FindByUsername(string username)
        {
            var user = db.Users.Where(u => u.Username == username).FirstOrDefault();

            return FindByUserId(user?.Id);
        }

        private readonly DataContext db;
    }
}
