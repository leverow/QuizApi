using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizApi.Entities.Configurations;

public class TopicConfiguration : EntityBaseConfiguration<Topic>
{
    public override void Configure(EntityTypeBuilder<Topic> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name).HasColumnType("varchar(50)").IsRequired(true);
        // builder.Property(b => b.NameHash).HasColumnType("nvarchar(64)").IsRequired(true);
        builder.Property(b => b.Description).HasColumnType("nvarchar(255)").IsRequired(true);
        // builder.HasIndex(b => b.NameHash).IsUnique(true);
    }
}