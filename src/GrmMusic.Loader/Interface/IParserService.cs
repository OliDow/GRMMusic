using GrmMusic.Domain;
using System.Collections.Generic;

namespace GrmMusic.Loader.Interface
{
    public interface  IParserService
    {
        IEnumerable<DistributionPartnerContracts> ParseParterData(string[] data);
        IEnumerable<MusicContract> ParseMusicData(string[] data);
        IEnumerable<MusicContract> ParseExclusiveData(string[] data);

        IEnumerable<MusicContract> PopulatePartners(IEnumerable<MusicContract> musicContracts, IEnumerable<DistributionPartnerContracts> partnerContracts);
    }

}
