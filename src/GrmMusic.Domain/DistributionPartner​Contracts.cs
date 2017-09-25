using System.Collections.Generic;

namespace GrmMusic.Domain
{
    public class DistributionPartner​Contracts
    {
        public DistributionPartner​Contracts(string partner)
        {
            Partner = partner;
            DistributionMechanisms = new List<DistributionMechanism>();
        }
        //TODO Turn this into an object once we get more info about partners
        public string Partner { get; set; }

        public List<DistributionMechanism> DistributionMechanisms { get; set; }        
    }
}