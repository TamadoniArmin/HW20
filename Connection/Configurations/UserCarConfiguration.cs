using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Users.Entities;
using App.Domain.Core.MoayeneFani.UsersCars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class UserCarConfiguration : IEntityTypeConfiguration<UserCar>
    {
        public void Configure(EntityTypeBuilder<UserCar> builder)
        {
            builder.HasKey(x => x.UserCarId);
        }
    }
}
