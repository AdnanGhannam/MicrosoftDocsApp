// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MicrosoftDocs.Infrastructure.Data;

#nullable disable

namespace MicrosoftDocs.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220424145004_003_add_CollectionsArticles_relation")]
    partial class _003_add_CollectionsArticles_relation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CollectionsArticles", b =>
                {
                    b.Property<string>("ArticlesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SavedInId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ArticlesId", "SavedInId");

                    b.HasIndex("SavedInId");

                    b.ToTable("CollectionsArticles");
                });

            modelBuilder.Entity("ContributorsArticles", b =>
                {
                    b.Property<string>("ArticlesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContributorsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ArticlesId", "ContributorsId");

                    b.HasIndex("ContributorsId");

                    b.ToTable("ContributorsArticles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.AppUserAggregate.Collection", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentArea")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullTitle")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsApi")
                        .HasColumnType("bit");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ReadTimes")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ReadingTime")
                        .HasColumnType("time");

                    b.Property<string>("SectionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SectionId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArticleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Interaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArticleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("InteractionType")
                        .HasColumnType("int");

                    b.Property<string>("InteractorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("InteractorId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Section", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ContentArea")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsApi")
                        .HasColumnType("bit");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SectionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CollectionsArticles", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.Collection", null)
                        .WithMany()
                        .HasForeignKey("SavedInId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ContributorsArticles", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("ContributorsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.AppUserAggregate.Collection", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", "Owner")
                        .WithMany("Collections")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", "Creator")
                        .WithMany("OwnedArticles")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Language", "Language")
                        .WithMany("Articles")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Product", null)
                        .WithMany("Articles")
                        .HasForeignKey("ProductId");

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Section", "Section")
                        .WithMany("Articles")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Language");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Feedback", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", "Article")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Interaction", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", "Article")
                        .WithMany("Interactions")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", "Interactor")
                        .WithMany("Interactions")
                        .HasForeignKey("InteractorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Interactor");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Product", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", "Creator")
                        .WithMany("Products")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Language", "Language")
                        .WithMany("Products")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Product", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductId");

                    b.Navigation("Creator");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Section", b =>
                {
                    b.HasOne("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", "Creator")
                        .WithMany("Sections")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Language", "Language")
                        .WithMany("Sections")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Product", null)
                        .WithMany("Sections")
                        .HasForeignKey("ProductId");

                    b.HasOne("MicrosoftDocs.Domain.Entities.SectionAggregate.Section", null)
                        .WithMany("Sections")
                        .HasForeignKey("SectionId");

                    b.Navigation("Creator");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.AppUserAggregate.AppUser", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Feedbacks");

                    b.Navigation("Interactions");

                    b.Navigation("OwnedArticles");

                    b.Navigation("Products");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Article", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Language", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Products");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Product", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Products");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("MicrosoftDocs.Domain.Entities.SectionAggregate.Section", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
