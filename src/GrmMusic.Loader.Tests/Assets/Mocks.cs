using GrmMusic.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace GrmMusic.Loader.Tests.Assets
{
    public class Mocks
    {
        public IEnumerable<DistributionPartner​Contracts> GetPartnerMock()
        {
            return new List<DistributionPartnerContracts>{
                    new DistributionPartnerContracts("ITunes")
                    {
                        DistributionMechanisms = new List<DistributionMechanism> {DistributionMechanism.digitaldownload}
                    },
                    new DistributionPartnerContracts("YouTube")
                    {
                        DistributionMechanisms = new List<DistributionMechanism> {DistributionMechanism.streaming}
                    }
            };
        }

        public IEnumerable<MusicContract> GetMusicContractsMocks()
        {
            return new List<MusicContract>
            {
                new MusicContract()
                {
                    Artist = "Tinie Tempah",
                    Title = "Frisky (Live from SoHo)",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.digitaldownload, DistributionMechanism.streaming},
                    StartDate = DateTime.ParseExact("2012-02-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //EndDate = 
                },
                new MusicContract()
                {
                    Artist = "Tinie Tempah",
                    Title = "Miami 2 Ibiza",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.digitaldownload },
                    StartDate = DateTime.ParseExact("2012-02-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),

                    //EndDate = 
                },
                new MusicContract()
                {
                    Artist = "Tinie Tempah",
                    Title = "Till I'm Gone",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.digitaldownload },
                    StartDate = DateTime.ParseExact("2012-08-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),  
                    //EndDate = 
                },
                new MusicContract()
                {
                    Artist = "Monkey Claw",
                    Title = "Black Mountain",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.digitaldownload },
                    StartDate = DateTime.ParseExact("2012-02-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //EndDate = 
                },
                new MusicContract()
                {
                    Artist = "Monkey Claw",
                    Title = "Iron Horse",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.digitaldownload,DistributionMechanism.streaming },
                    StartDate = DateTime.ParseExact("2012-06-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //EndDate = 
                },
                new MusicContract()
                {
                    Artist = "Monkey Claw",
                    Title = "Motor Mouth",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.digitaldownload,DistributionMechanism.streaming },
                    StartDate = DateTime.ParseExact("2011-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //EndDate = 
                },
                new MusicContract()
                {
                    Artist = "Monkey Claw",
                    Title = "Christmas Special",
                    DistributionMechanism = new List<DistributionMechanism> { DistributionMechanism.streaming },
                    StartDate = DateTime.ParseExact("2012-12-25", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2012-12-31", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                }
            };
        }
    }
}
