using GrmMusic.Domain;//
using GrmMusic.Loader.Interface;
using GrmMusic.Loader.Tests.Assets;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrmMusic.Loader.Tests
{
    [TestFixture]
    public class LoaderTests
    {

        [SetUp]
        public void Setup()
        {
            _dataLoaderService = new FileLoaderService();
            _parserService = new ParserService();
            Mocks = new Mocks();
        }

        private IDataLoaderService _dataLoaderService = null;
        private IParserService _parserService = null;
        private Mocks Mocks = null;

        [Test]
        public void LoadFileTest_Data()
        {
            var path = "Assets/musicData.txt";
            var data = _dataLoaderService.LoadFile(path);
            var expected = new string[] { "Hello Music", "Goodbye World" };
            Assert.AreEqual(expected, data);
        }

        [Test]
        public void LoadFileTest_Empty()
        {
            var path = "Assets/musicNull.txt";
            var data = _dataLoaderService.LoadFile(path);
            Assert.AreEqual(new string[0], data);
        }

        [Test]
        public void LoadFileTest_NotFound()
        {
            var path = "Assets/na";
            var data = _dataLoaderService.LoadFile(path);
            Assert.AreEqual(null, data);
        }

        [Test]
        public void ParseMechanism_DigitalDownload()
        {
            ParserService parserService = new ParserService();
            string mechanism = "digital download";

            var output = parserService.ParserMechanisms(mechanism);
            var expected = new List<DistributionMechanism> { DistributionMechanism.digitaldownload };

            Assert.AreEqual(expected.First(), output.First());
        }

        [Test]
        public void ParseMechanism_Streaming()
        {
            ParserService parserService = new ParserService();
            string mechanism = "streaming";

            var output = parserService.ParserMechanisms(mechanism);
            var expected = new List<DistributionMechanism> { DistributionMechanism.streaming };


            Assert.AreEqual(expected, output);
        }

        [Test]
        public void ParseMechanism_Both()
        {
            ParserService parserService = new ParserService();
            string mechanism = " digital download, streaming ";

            var output = parserService.ParserMechanisms(mechanism);
            var expected = new List<DistributionMechanism> { DistributionMechanism.digitaldownload, DistributionMechanism.streaming };


            Assert.AreEqual(expected.First(), output.First());
            Assert.AreEqual(expected.Last(), output.Last());
        }

        [Test]
        public void ParseMechanism_Null()
        {
            ParserService parserService = new ParserService();
            string mechanism = "unknown";

            var output = parserService.ParserMechanisms(mechanism);


            Assert.AreEqual(0, output.Count());
        }


        [Test]
        public void ParsePartner()
        {
            string[] content = File.ReadAllLines("Assets/distributionPartners.txt");
            var output = _parserService.ParseParterData(content);

            IEnumerable<DistributionPartner​Contracts> expected = Mocks.GetPartnerMock();


            var a = expected.First().DistributionMechanisms;
            var b = output.First().DistributionMechanisms;

            //TODO Add IEquatable for much higher test coverage 
            Assert.AreEqual(expected.First().DistributionMechanisms, output.First().DistributionMechanisms);
            Assert.AreEqual(expected.First().Partner, output.First().Partner);

            Assert.AreEqual(expected.Last().DistributionMechanisms, output.Last().DistributionMechanisms);
            Assert.AreEqual(expected.Last().Partner, output.Last().Partner);
        }

        [Test]
        public void ParseMusic()
        {
            string[] content = File.ReadAllLines("Assets/musicContracts.txt");
            var output = _parserService.ParseMusicData(content);

            IEnumerable<MusicContract> expected = Mocks.GetMusicContractsMocks();

            //TODO Add IEquatable for much higher test coverage 
            Assert.AreEqual(expected.First().Artist, output.First().Artist);
            Assert.AreEqual(expected.First().Title, output.First().Title);

            Assert.AreEqual(expected.Last().Artist, output.Last().Artist);
            Assert.AreEqual(expected.Last().Title, output.Last().Title);
        }

        [Test]
        public void PopulatePartners()
        {
            _parserService.PopulatePartners(Mocks.GetMusicContractsMocks(), Mocks.GetPartnerMock());



        }
    }
}