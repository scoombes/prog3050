using System;
using System.Runtime.CompilerServices;
using EfEnumToLookup.LookupGenerator;
using Veil.DataModels;
using Veil.DataModels.Models;
using Veil.DataModels.Models.Identity;

[assembly: InternalsVisibleTo("Veil.DataAccess.Tests")]
namespace Veil.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VeilDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Veil.DataAccess.VeilDataContext";
        }

        protected override void Seed(VeilDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.ESRBRatings.AddOrUpdate(
                er => er.RatingId,
                new ESRBRating
                {
                    RatingId = "EC",
                    Description = "Early Childhood",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_ec.png"
                },
                new ESRBRating
                {
                    RatingId = "E",
                    Description = "Everyone",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_e.png"
                },
                new ESRBRating
                {
                    RatingId = "E10+",
                    Description = "Everyone 10+",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_e10.png"
                },
                new ESRBRating
                {
                    RatingId = "T",
                    Description = "Teen",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_t.png"
                },
                new ESRBRating
                {
                    RatingId = "M",
                    Description = "Mature",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_m.png"
                },
                new ESRBRating
                {
                    RatingId = "AO",
                    Description = "Adults Only",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_ao.png"
                },
                new ESRBRating
                {
                    RatingId = "RP",
                    Description = "Rating Pending",
                    ImageURL = "https://esrbstorage.blob.core.windows.net/esrbcontent/images/ratingsymbol_rp.png"
                }
            );

            int ecdId = 0;

            context.ESRBContentDescriptors.AddOrUpdate(
                ecd => ecd.Id,
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Alcohol Reference" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Animated Blood" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Blood" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Blood and Gore" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Cartoon Violence" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Comic Mischief" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Crude Humor" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Drug Reference" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Fantasy Violence" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Intense Violence" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Language" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Lyrics" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Mature Humor" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Nudity" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Partial Nudity" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Real Gambling" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Sexual Content" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Sexual Themes" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Sexual Violence" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Simulated Gambling" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Strong Language" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Strong Lyrics" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Strong Sexual Content" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Suggestive Themes" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Tobacco Reference" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Use of Alcohol" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Use of Drugs" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Use of Tobacco" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Violence" },
                new ESRBContentDescriptor { Id = ++ecdId, DescriptorName = "Violent References" }
            );

            context.Countries.AddOrUpdate(
                c => c.CountryCode,
                new Country
                {
                    CountryCode = "CA",
                    CountryName = "Canada",
                    FederalTaxAcronym = "GST",
                    FederalTaxRate = 0.05m
                },
                new Country
                {
                    CountryCode = "US",
                    CountryName = "United States of America",
                    FederalTaxRate = 0
                }
            );

            context.Provinces.AddOrUpdate(
                p => new { p.ProvinceCode, p.CountryCode },
                // Canadian Provinces and Territories
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "AB",
                    Name = "Alberta",
                    ProvincialTaxRate = 0
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "BC",
                    Name = "British Columbia",
                    ProvincialTaxAcronym = "PST",
                    ProvincialTaxRate = 0.07m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "MB",
                    Name = "Manitoba",
                    ProvincialTaxAcronym = "PST",
                    ProvincialTaxRate = 0.08m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "NB",
                    Name = "New Brunswick",
                    ProvincialTaxAcronym = "HST",
                    ProvincialTaxRate = 0.08m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "NL",
                    Name = "Newfoundland and Labrador",
                    ProvincialTaxAcronym = "HST",
                    ProvincialTaxRate = 0.08m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "NT",
                    Name = "Northwest Territories",
                    ProvincialTaxRate = 0
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "NS",
                    Name = "Nova Scotia",
                    ProvincialTaxAcronym = "HST",
                    ProvincialTaxRate = 0.10m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "NU",
                    Name = "Nunavut",
                    ProvincialTaxRate = 0
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "ON",
                    Name = "Ontario",
                    ProvincialTaxAcronym = "HST",
                    ProvincialTaxRate = 0.08m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "PE",
                    Name = "Prince Edward Island",
                    ProvincialTaxAcronym = "HST",
                    ProvincialTaxRate = 0.09m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "QC",
                    Name = "Quebec",
                    ProvincialTaxAcronym = "PST",
                    ProvincialTaxRate = 0.09975m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "SK",
                    Name = "Saskatchewan",
                    ProvincialTaxAcronym = "PST",
                    ProvincialTaxRate = 0.05m
                },
                new Province
                {
                    CountryCode = "CA",
                    ProvinceCode = "YT",
                    Name = "Yukon",
                    ProvincialTaxRate = 0
                },

                // US States
                new Province
                {
                    CountryCode = "US",
                    ProvinceCode = "NY",
                    Name = "New York",
                    ProvincialTaxRate = 0
                }
            );

            context.LocationTypes.AddOrUpdate(
                lt => lt.LocationTypeName, 
                new LocationType
                {
                    LocationTypeName = "Office"
                },
                new LocationType
                {
                    LocationTypeName = "Store"
                }
            );

            context.Platforms.AddOrUpdate(
                p => p.PlatformCode,
                new Platform
                {
                    PlatformCode = "PC",
                    PlatformName = "Personal Computer"
                }, 
                new Platform
                {
                    PlatformCode = "PS4",
                    PlatformName = "PlayStation 4"
                }, 
                new Platform
                {
                    PlatformCode = "XONE",
                    PlatformName = "Xbox One"
                },
                new Platform
                {
                    PlatformCode = "WIIU",
                    PlatformName = "Wii U"
                },
                new Platform
                {
                    PlatformCode = "PS3",
                    PlatformName = "PlayStation 3"
                }, 
                new Platform
                {
                    PlatformCode = "X360",
                    PlatformName = "Xbox 360"
                }
            );

            // The GUIDs for these were taken from SQL Server as it generates sequential ones
            context.Companies.AddOrUpdate(
                c => c.Name,
                new Company { Name = "Activision Blizzard" },
                new Company { Name = "Electronic Arts" },
                new Company { Name = "Ubisoft" },
                new Company { Name = "Take-Two" },
                new Company { Name = "2K Games" },
                new Company { Name = "Blizzard Entertainment" },
                new Company { Name = "EA DICE" },
                new Company { Name = "Rockstar Games" },
                new Company { Name = "Nintendo" },
                new Company { Name = "Sony Computer Entertainment" },
                new Company { Name = "Microsoft Studios" },
                new Company { Name = "Bungie" },
                new Company { Name = "Treyarch" }
            );

            context.Tags.AddOrUpdate(
                t => t.Name,
                new Tag { Name = "First Person" },
                new Tag { Name = "Third Person" },
                new Tag { Name = "Shooter" },
                new Tag { Name = "Simulation" },
                new Tag { Name = "RTS" },
                new Tag { Name = "Racing" },
                new Tag { Name = "RPG" },
                new Tag { Name = "MMO" },
                new Tag { Name = "Action" },
                new Tag { Name = "Adventure" },
                new Tag { Name = "Side Scroller" },
                new Tag { Name = "2D" },
                new Tag { Name = "3D" },
                new Tag { Name = "Turn-Based" },
                new Tag { Name = "Roguelike" }
            );

            int deptId = 0;

            context.Departments.AddOrUpdate(
                d => d.Id,
                new Department
                {
                    Id = ++deptId,
                    Name = "Retail Operations"
                },
                new Department
                {
                    Id = ++deptId,
                    Name = "Purchasing"
                },
                new Department
                {
                    Id = ++deptId,
                    Name = "Online Operations"
                }
            );

            context.Roles.AddOrUpdate(
                r => r.Id,
                new GuidIdentityRole
                {
                    Id = Guid.ParseExact("455b072e-de7d-e511-80df-001cd8b71da6", "D"),
                    Name = VeilRoles.ADMIN_ROLE
                },
                new GuidIdentityRole
                {
                    Id = Guid.ParseExact("465b072e-de7d-e511-80df-001cd8b71da6", "D"),
                    Name = VeilRoles.EMPLOYEE_ROLE
                },
                new GuidIdentityRole
                {
                    Id = Guid.ParseExact("475b072e-de7d-e511-80df-001cd8b71da6", "D"),
                    Name = VeilRoles.MEMBER_ROLE
                });

            context.Games.AddOrUpdate(
                g => g.Name,
                new Game
                {
                    Name = "Test Game",
                    ESRBRatingId = "E",
                    ShortDescription = "This is the short description",
                    LongDescription = "This is the long description",
                    MinimumPlayerCount = 1,
                    MaximumPlayerCount = 2,
                    PrimaryImageURL = "http://baconmockup.com/200/140/",
                    TrailerURL = "https://www.youtube.com/watch?v=GLWYXCOf4Ac"
                },
                new Game
                {
                    Name = "Yet Another Game",
                    ESRBRatingId = "E",
                    LongDescription = "This is the long description",
                    ShortDescription = "This is the short description",
                    MinimumPlayerCount = 1,
                    MaximumPlayerCount = 4,
                    PrimaryImageURL = "http://placebacon.net/200/150",
                    TrailerURL = "https://www.youtube.com/watch?v=GLWYXCOf4Ac"
                });

            /* Enum to Lookup Tables Setup */
            EnumToLookup enumToLookup = new EnumToLookup
            {
                TableNamePrefix = "",
                TableNameSuffix = "_Lookup",
                NameFieldLength = 64,
                UseTransaction = true
            };

            enumToLookup.Apply(context);
        }
    }
}
