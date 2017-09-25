using GrmMusic.Domain;
using GrmMusic.Infrastructure;
using GrmMusic.Search.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrmMusic.Search
{
    public class SearchService : ISearchService
    {
        #region Constructor
        public SearchService()
        {

        }
        #endregion

        #region Properties
        private IEnumerable<MusicContract> _musicContracts;
        #endregion

        #region ISearchService
        public void LoadData(IEnumerable<MusicContract> musicContracts)
        {
            _musicContracts = musicContracts;
        }

        public void Search(string command)
        {
            string app = command.FirstFromSplit(' ');
            string dateStr = "";
            try
            {
                dateStr = command.Substring((app.Length + 1)).RemoveDateTimeChars();
            }
            catch (Exception e)
            {
                Console.WriteLine("You need to enter type and date");
                return;
            }

            DateTime dateTimeOut;
            if (!DateTime.TryParse(dateStr, out dateTimeOut))
            {
                Console.WriteLine("Failed to parse date segment");
                return;
            }
            Console.WriteLine("Artist|Title|Usage|StartDate|EndDate");
            _musicContracts.Reverse().Where(c => c.StartDate < dateTimeOut && (c.EndDateStr == null || c.EndDate > dateTimeOut) && c.Usages.Any(u => u.Partner == app)).ToList().ForEach(m => Console.WriteLine(FormatContract(m, app)));
        }

        private string FormatContract(MusicContract contract, string app)
        {
            var mechanismEnum = contract.Usages.First(m => m.Partner == app).DistributionMechanisms.First();
            var mechanism = mechanismEnum.GetDisplayName(); ;
            string output = $"{contract.Artist}|{contract.Title}|{mechanism}|{contract.StartDateStr}";

            if (!string.IsNullOrEmpty(contract.EndDateStr))
                output += $"|{contract.EndDateStr}";

            return output;
        }
    }

    #endregion
}

