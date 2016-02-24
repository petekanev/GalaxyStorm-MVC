namespace GalaxyStorm.Common.Tests.Mocks.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Data.Models.PlayerObjects;
    using Data.Repositories;
    using Moq;

    public class PlayerObjectsRepositoryMock
    {
        private static readonly Random random = new Random();

        public static IRepository<PlayerObject> Create()
        {
            var pOList = new List<PlayerObject>();

            pOList.Add(new PlayerObject
                {
                    ApplicationUserId = "app-user-id-" + 100,
                    Buildings = new Buildings
                    {
                        BarracksLevel = 8,
                        CrystalExtractorLevel = 13,
                        HeadQuartersLevel = 13,
                        MetalScrapperLevel = 12,
                        ResearchCentreLevel = 4,
                        SolarCollectorLevel = 13,
                        Id = 100
                    },
                    Planet = new Planet
                    {
                        CrystalModifier = 5,
                        MetalModifier = 5,
                        EnergyModifier = 5,
                        IsPopulated = true,
                        X = 2 * 10 + 100 + 3,
                        Y = 2 * 10 + 2*2 + 1,
                        Title = "Planet " + 100,
                        Shard = new Shard
                        {
                            Title = "Shard XYZ",
                            BuildSpeed = 0.2,
                            ShardSize = ShardSize.Large
                        }
                    },
                    Resources = new Resources
                    {
                        Crystal = 1000,
                        Energy = 1000,
                        Metal = 1000
                    },
                    Units = new Units
                    {
                        ScoutsQuantity = 100,
                        CarriersQuantity = 110,
                        FighterQuantity = 100
                    },
                    Points = new Points
                    {
                        PointsCombat = 500,
                        PointsNeutral = 700,
                        PointsPlanet = 1000
                    },
                    Reports = new List<Report>(),
                    Technologies = new Technologies
                    {
                        ArmoredFleetLevel = 1,
                        CheaperFleetLevel = 2,
                        MoreResourcesLevel = 1
                    }
                });

            for (int i = 0; i < 20; i++)
            {
                pOList.Add(new PlayerObject
                {
                    ApplicationUserId = "app-user-id-" + i,
                    Buildings = new Buildings
                    {
                        BarracksLevel = random.Next(0,10),
                        CrystalExtractorLevel = random.Next(0, 15),
                        HeadQuartersLevel = random.Next(5, 16),
                        MetalScrapperLevel = random.Next(0, 15),
                        ResearchCentreLevel = random.Next(0, 5),
                        SolarCollectorLevel = random.Next(0, 15),
                        Id = i
                    },
                    Planet = new Planet
                    {
                        CrystalModifier = i,
                        MetalModifier = i,
                        EnergyModifier = i,
                        IsPopulated = i % 2 == 0,
                        X = i * 10 + i + 3,
                        Y = i * 10 + i*2 + 1,
                        Title = "Planet " + i,
                        Shard = new Shard
                        {
                            Title = "Shard XYZ",
                            BuildSpeed = 0.2,
                            ShardSize = ShardSize.Large
                        }
                    },
                    Resources = new Resources
                    {
                        Crystal = 1000,
                        Energy = 1000,
                        Metal = 1000
                    },
                    Units = new Units
                    {
                        ScoutsQuantity = 100,
                        CarriersQuantity = 110,
                        FighterQuantity = 100
                    },
                    Points = new Points
                    {
                        PointsCombat = 500,
                        PointsNeutral = 500 + i,
                        PointsPlanet = i * 100
                    },
                    Reports = new List<Report>(),
                    Technologies = new Technologies
                    {
                        ArmoredFleetLevel = random.Next(0, 3),
                        CheaperFleetLevel = random.Next(0, 3),
                        MoreResourcesLevel = 1
                    }
                });
            }

            var pOasQueryable = pOList.AsQueryable();

            var repo = new Mock<IRepository<PlayerObject>>();
            repo.Setup(r => r.All()).Returns(pOasQueryable);
            repo.Setup(r => r.Add(It.IsAny<PlayerObject>())).Callback<PlayerObject>(pObject =>
            {
                pOList.Add(pObject);
            });
            repo.Setup(x => x.Delete(It.IsAny<PlayerObject>())).Verifiable();
            repo.Setup(x => x.Update(It.IsAny<PlayerObject>())).Verifiable();
            repo.Setup(x => x.SaveChanges()).Verifiable();

            return repo.Object;
        }
    }
}
