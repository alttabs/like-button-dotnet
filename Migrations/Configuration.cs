namespace LikeButton.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LikeButton.Models.Classes;

    internal sealed class Configuration : DbMigrationsConfiguration<LikeButton.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LikeButton.Models.ApplicationDbContext context)
        {
            context.Like.AddOrUpdate(x => x.article_id,
                new Like() { article_id = 1, like_date = DateTime.Now, article_like = 0 });
        }
    }
}
