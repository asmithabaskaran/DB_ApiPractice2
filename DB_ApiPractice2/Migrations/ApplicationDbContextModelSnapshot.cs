﻿// <auto-generated />
using DB_ApiPractice2.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB_ApiPractice2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB_ApiPractice2.Models.EF_Models+Report", b =>
                {
                    b.Property<string>("recall_number")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address_1");

                    b.Property<string>("address_2");

                    b.Property<string>("center_classification_date");

                    b.Property<string>("city");

                    b.Property<string>("classification");

                    b.Property<string>("code_info");

                    b.Property<string>("country");

                    b.Property<string>("distribution_pattern");

                    b.Property<string>("event_id");

                    b.Property<string>("initial_firm_notification");

                    b.Property<string>("postal_code");

                    b.Property<string>("product_description");

                    b.Property<string>("product_quantity");

                    b.Property<string>("product_type");

                    b.Property<string>("reason_for_recall");

                    b.Property<string>("recall_initiation_date");

                    b.Property<string>("recalling_firm");

                    b.Property<string>("report_date");

                    b.Property<string>("state");

                    b.Property<string>("status");

                    b.Property<string>("termination_date");

                    b.Property<string>("voluntary_mandated");

                    b.HasKey("recall_number");

                    b.ToTable("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
