using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Operators.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection.Configurations
{
    public class OpratorConfiguration : IEntityTypeConfiguration<Oprator>
    {
        public void Configure(EntityTypeBuilder<Oprator> builder)
        {
            builder.HasKey(x => x.OpratorId);
        }
    }
}
