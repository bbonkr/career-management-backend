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
                    .ThenInclude(p => p.Links)
                .Include(u => u.Careers)
                    .ThenInclude(c => c.Links)
                .Include(u => u.Educations)
                    .ThenInclude(x=>x.Links)
                .Include(u => u.Portfolios)
                    .ThenInclude(x=>x.Links)
                .Include(u=>u.Portfolios)
                    .ThenInclude(x=>x.PortfolioTags)
                .Include(u=>u.Portfolios)
                    .ThenInclude(x=>x.Features)
                .Include(u => u.Skills)
                    .ThenInclude(x=>x.Items)
                .Where(u => u.Id == userId)
                .Select(u => new User {
                    Name = u.Name,
                    Username = u.Username,
                    Email = u.Email,
                    ImageUri = u.ImageUri,
                    Profile = new Profile
                    {
                        Bio = u.Profile.Bio,
                        Links = u.Profile.Links.Select(link => new ProfileLink
                        {
                            Title = link.Title,
                            Href = link.Href,
                            Icon = link.Icon,
                            Target = link.Target
                        }).ToList()
                    },
                    Careers = u.Careers.Select(c => new Career
                    {
                        Period = c.Period,
                        Title = c.Title,
                        State = c.State,
                        Description = c.Description,
                        Links = c.Links.Select(link => new CareerLink
                        {
                            Title = link.Title,
                            Href = link.Href,
                            Icon = link.Icon,
                            Target = link.Target
                        }).ToList()
                    }).ToList(),
                    Educations = u.Educations.Select(x => new Education
                    {
                        Period = x.Period,
                        Title = x.Title,
                        State = x.State,
                        Description = x.Description,
                        Links = x.Links.Select(link => new EducationLink
                        {
                            Title = link.Title,
                            Href = link.Href,
                            Icon = link.Icon,
                            Target = link.Target
                        }).ToList(),
                    }).ToList(),
                    Portfolios = u.Portfolios.Select(x => new Portfolio
                    {
                        Title = x.Title,
                        Descriptoin = x.Descriptoin,
                        Period = x.Period,
                        State = x.State,
                        Features = x.Features.Select(f => new PortfolioFeature
                        {
                            Content = f.Content,
                        }).ToList(),
                        Links = x.Links.Select(link => new PortfolioLink
                        {
                            Title = link.Title,
                            Href = link.Href,
                            Icon = link.Icon,
                            Target = link.Target
                        }).ToList(),
                        Tags = x.PortfolioTags.Select(x => 
                             x.Name
                        ).ToList(),
                    }).ToList(),
                    Skills = u.Skills.Select(skill => new Skill
                    {
                        Name = skill.Name,
                        Icon = skill.Icon,                        
                        Items = skill.Items.Select(item => new SkillItem
                        {
                            Name = item.Name,
                            Score = item.Score,
                        }).ToList(),
                    }).ToList(),
                })
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
