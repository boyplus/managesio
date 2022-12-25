using Managesio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managesio.Core.Maps;

public class UserMap
{
    public UserMap(EntityTypeBuilder<User> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("user");

        entityBuilder.Property(x=>x.Id).HasColumnName("id");
        entityBuilder.Property(x=>x.Email).HasColumnName("email");
        entityBuilder.Property(x=>x.Password).HasColumnName("password");
        entityBuilder.Property(x=>x.Firstname).HasColumnName("firstname");
        entityBuilder.Property(x=>x.Lastname).HasColumnName("lastname");
    }
}