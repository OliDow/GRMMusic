using GrmMusic.Domain;
using System.Collections.Generic;

namespace GrmMusic.Search.Interface
{
    public interface ISearchService
    {
        void LoadData(IEnumerable<MusicContract> musicContracts);
        void Search(string command);
    }
}
