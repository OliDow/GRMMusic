using System;
using System.Collections.Generic;

namespace GrmMusic.Domain
{
    public class Music​Contract
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public IEnumerable<DistributionPartnerContracts> Usages { get; set; }
        public IEnumerable<DistributionMechanism> DistributionMechanism{ get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateStr { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndDateStr { get; set; }

       
    }
}
