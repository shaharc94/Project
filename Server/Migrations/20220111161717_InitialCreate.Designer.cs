// <auto-generated />
using HomeProject.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeProject.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220111161717_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("HomeProject.Shared.Entities.Worker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<double>("Salary")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
