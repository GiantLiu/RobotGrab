namespace Robot.Entitys.Grab.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Robot.Entitys.Grab.GrabContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Robot.Entitys.Grab.GrabContext context)
        {
            
        }
    }
}
