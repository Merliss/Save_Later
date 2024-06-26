﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using SaveLater.Domain.Entities;

namespace SaveLater.Persistence.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        //private readonly SaveLaterContext _dbContext;
        public CategoryRepository(SaveLaterContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchCategory)
        {
            var allCategories = await _dbContext.Categories.Include(p => p.Posts).ToListAsync();

            if (searchCategory == SearchCategoryOptions.FirstBestAllTheTime)
            {
                return GetOneMaxPost(allCategories);
            }
            else if (searchCategory == SearchCategoryOptions.FirstBestThisMonth)
            {
                DateTime d = DateTime.Now;

                allCategories = allCategories.Where(c => c.Posts.Any
                (p => (p.Created.Month == d.Month && d.Year == p.Created.Year))).ToList();

                return GetOneMaxPost(allCategories);
            }
            return allCategories;
        }


        private List<Category> GetOneMaxPost(List<Category> allCategories)
        {
            foreach (var c in allCategories)
            {
                Post max = null;
                foreach (var p in c.Posts)
                {
                    if(max == null)
                    {
                        max = p;
                        break;
                    }
                    if (max.Rate < p.Rate)
                    {
                        max = p;
                    }
                }
                c.Posts = new List<Post>();
                if (max != null)
                {
                    c.Posts.Add(max);
                }
            }
                return allCategories;
        }
    }
}
