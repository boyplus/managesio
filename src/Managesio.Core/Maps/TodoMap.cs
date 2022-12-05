using Managesio.Core.Entities;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Managesio.Core.Maps;

public class TodoMap
{
    public TodoMap(EntityTypeBuilder<Todo> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("todo");

        entityBuilder.Property(x=>x.Id).HasColumnName("id");
        entityBuilder.Property(x=>x.Title).HasColumnName("title");
        entityBuilder.Property(x=>x.Note).HasColumnName("note");
    }
}