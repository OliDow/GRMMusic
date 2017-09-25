using GrmMusic.Domain;
using GrmMusic.Loader.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using GrmMusic.Infrastructure;

namespace GrmMusic.Loader
{
    public class ParserService : IParserService
    {
        #region Constructor

        public ParserService()
        {

        }
        #endregion

        #region IParserService

        public IEnumerable<DistributionPartnerContracts> ParseParterData(string[] data)
        {
            IEnumerable<DistributionPartnerContracts> partnerList = data.Skip(1).Select((p, i) =>
            {
                string[] split = p.Split('|');
                var partner = new DistributionPartnerContracts(split[0])
                {
                    DistributionMechanisms = ParserMechanisms(split[1]).ToList()
                };
                return partner;
            }).ToList();
            return partnerList;
        }

        public IEnumerable<MusicContract> ParseMusicData(string[] data)
        {
            IEnumerable<MusicContract> musicList = data.Skip(1).Select((c, i) =>
            {
                string[] split = c.Split('|');
                var startDate = split[3].RemoveDateTimeChars();
                var musicContract = new MusicContract
                {
                    Artist = split[0],
                    Title = split[1],

                    StartDateStr = startDate,
                    StartDate = DateTime.Parse(startDate)
                };

                var mechanisms = ParserMechanisms(split[2]);
                musicContract.DistributionMechanism = mechanisms;

                if (split.Length > 4 && !string.IsNullOrEmpty(split[4].Trim()))
                {
                    var endDate = split[4].RemoveDateTimeChars();

                    musicContract.EndDateStr = endDate;
                    musicContract.EndDate = DateTime.Parse(endDate);
                }
                return musicContract;
            }).ToList();
            return musicList;
        }

        public IEnumerable<MusicContract> ParseExclusiveData(string[] data)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MusicContract> PopulatePartners(IEnumerable<MusicContract> musicContracts, IEnumerable<DistributionPartnerContracts> partnerContracts)
        {
            foreach (MusicContract mc in musicContracts)
            {
                List<DistributionPartnerContracts> mechanisms = partnerContracts.Where(d => d.DistributionMechanisms.Any(m => mc.DistributionMechanism.Contains(m))).ToList();
                mc.Usages = mechanisms;
            }

            return musicContracts;
        }
        #endregion


        public IEnumerable<DistributionMechanism> ParserMechanisms(string mechanisms)
        {
            string[] mechanismStrs = mechanisms.Split(",");

            var mechanismList = new List<DistributionMechanism>();
            foreach(string m in mechanismStrs)
            {
                if (m.Trim() == "digital download")
                    mechanismList.Add(DistributionMechanism.digitaldownload);
                else if (m.Trim() == "streaming")
                    mechanismList.Add(DistributionMechanism.streaming);
            }
            return mechanismList;
        }
    }
}
