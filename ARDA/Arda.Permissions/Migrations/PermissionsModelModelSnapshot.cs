using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Arda.Permissions.Models;

namespace Arda.Permissions.Migrations
{
    [DbContext(typeof(PermissionsContext))]
    partial class PermissionsModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16386")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arda.Permissions.Models.Permission", b =>
                {
                    b.Property<Guid>("PermissionID");

                    b.Property<string>("PermissionsByUser");

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<Guid>("UserID");

                    b.HasKey("PermissionID");

                    b.HasAnnotation("Relational:TableName", "Permissions");
                });
        }
    }
}
