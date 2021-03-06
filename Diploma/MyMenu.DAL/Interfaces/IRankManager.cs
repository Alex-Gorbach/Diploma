﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRankManager:IDisposable
    {
        void Create(Rating item);
        List<Rating> GetRecipeRanksById(int recipeId);
        List<Rating> GetRankByUserRecipeId(string userId, int recipeId);
    }
}
