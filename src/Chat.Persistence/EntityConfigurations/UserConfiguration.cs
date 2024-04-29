using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Persistence.EntityConfigurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.FirstName).HasMaxLength(50);
        //List<User> users = new List<User>()
        //{
        //  new User { Id=Guid.NewGuid(), FirstName = "John", LastName = "Doe", UserName = "johndoe123", Email = "jane.doe@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", UserName = "alicesmith87", Email = "alice.smith@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "David", LastName = "Lee", UserName = "davidlee99", Email = "david.lee@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Emily", LastName = "Jones", UserName = "emilyj2023", Email = "emily.jones@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Michael", LastName = "Brown", UserName = "mikebrown7", Email = "michael.brown@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Sarah", LastName = "Garcia", UserName = "sg_2001", Email = "sarah.garcia@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "William", LastName = "Miller", UserName = "wmiller10", Email = "william.miller@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Jennifer", LastName = "Davis", UserName = "jenniferd92", Email = "jennifer.davis@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Matthew", LastName = "Hernandez", UserName = "mherndz88", Email = "matthew.hernandez@email.com", Password = "password" }, // Replace "password" with secure hashing
        //  new User { Id=Guid.NewGuid(), FirstName = "Ashley", LastName = "Young", UserName = "ash_young95", Email = "ashley.young@email.com", Password = "password" }, // Replace "password" with secure hashing
        //};

        //builder.HasData(users);
    }
}
