using Course.Database.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Course.Database;

public class InventoryDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<UserAccess> UserAccesses { get; set; }
    public DbSet<InventoryFieldInfo> FieldDefinitions { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<InventoryFieldValue> FieldValues { get; set; }
    public DbSet<UserLikes> UserLikes { get; set; }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Inventory>()
            .HasOne(i => i.Creator)
            .WithMany(u => u.CreatedInventories)
            .HasForeignKey(i => i.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Inventory>()
            .HasOne(i => i.Category)
            .WithMany(c => c.Inventories)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<UserAccess>()
            .HasKey(ua => new { ua.InventoryId, ua.UserId });

        builder.Entity<UserAccess>()
            .HasOne(ua => ua.Inventory)
            .WithMany(i => i.AccessList)
            .HasForeignKey(ua => ua.InventoryId);

        builder.Entity<UserAccess>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.AccessList)
            .HasForeignKey(ua => ua.UserId);

        builder.Entity<ChatMessage>()
            .HasOne(c => c.Inventory)
            .WithMany(i => i.Chat)
            .HasForeignKey(c => c.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ChatMessage>()
            .HasOne(c => c.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<InventoryFieldInfo>()
            .HasOne(fd => fd.Inventory)
            .WithMany(i => i.CustomFields)
            .HasForeignKey(fd => fd.InventoryId);

        builder.Entity<InventoryItem>()
            .HasOne(ii => ii.Inventory)
            .WithMany(i => i.Items)
            .HasForeignKey(ii => ii.InventoryId);

        builder.Entity<InventoryFieldValue>()
            .HasOne(fv => fv.InventoryItem)
            .WithMany(ii => ii.CustomFieldValues)
            .HasForeignKey(fv => fv.InventoryItemId);

        builder.Entity<UserLikes>()
            .HasKey(ul => new { ul.InventoryItemId, ul.UserId });

        builder.Entity<UserLikes>()
            .HasOne(ul => ul.Item)
            .WithMany(ii => ii.Likes)
            .HasForeignKey(ul => ul.InventoryItemId);

        builder.Entity<UserLikes>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(ul => ul.UserId);
    }
}
