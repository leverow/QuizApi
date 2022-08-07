using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizApi.Entities.Configurations;

public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate();
    }
}