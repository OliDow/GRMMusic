using GrmMusic.Domain;
using System.Collections.Generic;

namespace GrmMusic.Loader.Interface
{
    public interface IDataLoaderService
    {
        string[] LoadFile(string path);
        IEnumerable<MusicContract> LoadMusicContractsData();
    }
}
