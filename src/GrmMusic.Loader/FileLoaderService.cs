using System.Collections.Generic;
using GrmMusic.Domain;
using GrmMusic.Loader.Interface;
using System.IO;
using System.Linq;
using System;

namespace GrmMusic.Loader
{
    public class FileLoaderService : IDataLoaderService
    {
        #region Constructor
        public FileLoaderService(IParserService parserService)
        {
            _parserService = parserService;
        }

        public FileLoaderService()
        {

        }
        #endregion

        #region Properties
        private IParserService _parserService;
        #endregion

        #region IDataLoaderService
        public string[] LoadFile(string path)
        {
            if (File.Exists(path))
            {
                string[] content = File.ReadAllLines(path);
                return content;
            }
            return null;
        }

        public IEnumerable<MusicContract> LoadMusicContractsData()
        {
            var partnerFileData = LoadFile("Resources/distribution​Partner​Contracts.txt");
            var partnerData = _parserService.ParseParterData(partnerFileData);

            var musicFileData = LoadFile("Resources/musicContracts.txt");
            var musicData = _parserService.ParseMusicData(musicFileData);

            Console.WriteLine("Loading Data");
            return _parserService.PopulatePartners(musicData, partnerData);
        }
        #endregion
    }
}
