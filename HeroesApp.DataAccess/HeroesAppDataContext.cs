using HeroesApp.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesApp.DataAccess
{
   public class HeroesAppDataContext: DbContext
    {
        public DbSet<HeroeModel> Heroes { get; set; }
        public DbSet<TrainerModel> Trainers { get; set; }
        public HeroesAppDataContext(DbContextOptions<HeroesAppDataContext> options)
        : base(options)
        {
        }
    }
}
