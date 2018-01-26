using Fritz.EpicBuildMusic.Core;
using Moq;
using NUnit.Framework;

namespace Test.GivenTheOptionsDialog
{
  [TestFixture]
  public class WhenOtherDuringBuildMusicSelected : GivenTheOptionsDialogBase
  {
    private const string otherBuildMusic = "someOtherBuildMusic.mp3";
    private Mock<IBuildMusicOptions> _BuildMusicOptions;
    private Mock<IFileSystemHandler> _FileHandler;

    [SetUp]
    public void TestSetup()
    {
      // arrange
      Initialize();

      _BuildMusicOptions = _Mockery.Create<IBuildMusicOptions>();
      _BuildMusicOptions.SetupAllProperties();
      _BuildMusicOptions.Object.DuringBuildMusic = MusicPlayer.DefaultFileName;

      _FileHandler = _Mockery.Create<IFileSystemHandler>();
      _FileHandler.Setup<bool>(h => h.FileExists(It.IsAny<string>())).Returns(true);

      _Control.Initialize(_BuildMusicOptions.Object, _FileHandler.Object);
      _Control.DefaultMusicDuringBuild = false;
      _Control.OtherMusicDuringBuild = otherBuildMusic;
    }

    [Test]
    public void ThenShouldPersistOtherDuringBuildMusic()
    {

      // act
      _Control.PersistDuringMusicSelection();

      // assert
      Assert.AreEqual(otherBuildMusic, _BuildMusicOptions.Object.DuringBuildMusic, "Did not clear out the during build music setting");


    }

  }

}
