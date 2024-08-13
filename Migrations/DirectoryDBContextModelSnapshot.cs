﻿// <auto-generated />
using System;
using AuthApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuthApi.Migrations
{
    [DbContext(typeof(DirectoryDBContext))]
    partial class DirectoryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthApi.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int?>("ColonyId")
                        .HasColumnType("int")
                        .HasColumnName("colonyId");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("countryId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deletedAt");

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("municipalityId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("number");

                    b.Property<string>("NumberInside")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("numberInside");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personId");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("stateId");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("street");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int")
                        .HasColumnName("zipCode");

                    b.HasKey("Id");

                    b.HasIndex("ColonyId");

                    b.HasIndex("CountryId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("PersonId");

                    b.HasIndex("StateId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AuthApi.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Disabled")
                        .HasColumnType("bit")
                        .HasColumnName("disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("AuthApi.Entities.Colony", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int")
                        .HasColumnName("municipalityId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("zipCode");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Colonies");
                });

            modelBuilder.Entity("AuthApi.Entities.ContactInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int")
                        .HasColumnName("contactTypeId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deletedAt");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personId");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("PersonId");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("AuthApi.Entities.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("AuthApi.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ISO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("iSO");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("PhoneCode")
                        .HasColumnType("int")
                        .HasColumnName("phoneCode");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AuthApi.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("AuthApi.Entities.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatus");
                });

            modelBuilder.Entity("AuthApi.Entities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("stateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("AuthApi.Entities.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Nationality");
                });

            modelBuilder.Entity("AuthApi.Entities.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Occupation");
                });

            modelBuilder.Entity("AuthApi.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("AppOwner")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("appOwner");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("Date")
                        .HasColumnName("birthdate");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("curp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deletedAt");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstName");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int")
                        .HasColumnName("genderId");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastName");

                    b.Property<int?>("MaritalStatusId")
                        .HasColumnType("int")
                        .HasColumnName("maritalStatusId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("NationalityId")
                        .HasColumnType("int")
                        .HasColumnName("nationalityId");

                    b.Property<int?>("OccupationId")
                        .HasColumnType("int")
                        .HasColumnName("occupationId");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Rfc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("rfc");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<DateTime?>("ValidatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("validatedAt");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("OccupationId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("AuthApi.Entities.Preregistration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mail");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedAt");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2")
                        .HasColumnName("validTo");

                    b.HasKey("Id");

                    b.ToTable("Preregistrations");
                });

            modelBuilder.Entity("AuthApi.Entities.Proceeding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaId")
                        .HasColumnType("int")
                        .HasColumnName("areaId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Folio")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("folio");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personId");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("statusId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("StatusId");

                    b.ToTable("Proceedings");
                });

            modelBuilder.Entity("AuthApi.Entities.ProceedingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Disabled")
                        .HasColumnType("bit")
                        .HasColumnName("disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ProceedingStatuses");
                });

            modelBuilder.Entity("AuthApi.Entities.Session", b =>
                {
                    b.Property<string>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("sessionID");

                    b.Property<DateTime>("BegginAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("begginAt")
                        .HasDefaultValueSql("getDate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deletedAt");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("endAt");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ipAddress");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personId");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("userAgent");

                    b.HasKey("SessionID");

                    b.HasIndex("PersonId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("AuthApi.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("countryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("AuthApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.HasKey("Id");

                    b.ToTable("Users", "System");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "system@email.com",
                            FirstName = "System",
                            LastName = "",
                            Password = "Cc7J4tIRCw53U7P7iyUANkY+YNrN2SGRsld54JJecnI=",
                            isActive = false
                        });
                });

            modelBuilder.Entity("AuthApi.Entities.Address", b =>
                {
                    b.HasOne("AuthApi.Entities.Colony", "Colony")
                        .WithMany()
                        .HasForeignKey("ColonyId");

                    b.HasOne("AuthApi.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthApi.Entities.Municipality", "Municipality")
                        .WithMany()
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthApi.Entities.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthApi.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colony");

                    b.Navigation("Country");

                    b.Navigation("Municipality");

                    b.Navigation("Person");

                    b.Navigation("State");
                });

            modelBuilder.Entity("AuthApi.Entities.Colony", b =>
                {
                    b.HasOne("AuthApi.Entities.Municipality", "Municipality")
                        .WithMany()
                        .HasForeignKey("MunicipalityId");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("AuthApi.Entities.ContactInformation", b =>
                {
                    b.HasOne("AuthApi.Entities.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthApi.Entities.Person", "Person")
                        .WithMany("ContactInformations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AuthApi.Entities.Municipality", b =>
                {
                    b.HasOne("AuthApi.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("AuthApi.Entities.Person", b =>
                {
                    b.HasOne("AuthApi.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("AuthApi.Entities.MaritalStatus", "MaritalStatus")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId");

                    b.HasOne("AuthApi.Entities.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.HasOne("AuthApi.Entities.Occupation", "Occupation")
                        .WithMany()
                        .HasForeignKey("OccupationId");

                    b.Navigation("Gender");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Nationality");

                    b.Navigation("Occupation");
                });

            modelBuilder.Entity("AuthApi.Entities.Proceeding", b =>
                {
                    b.HasOne("AuthApi.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("AuthApi.Entities.ProceedingStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Area");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("AuthApi.Entities.Session", b =>
                {
                    b.HasOne("AuthApi.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AuthApi.Entities.State", b =>
                {
                    b.HasOne("AuthApi.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AuthApi.Entities.Person", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ContactInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
