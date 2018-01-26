using Fritz.EpicBuildMusic.Core;
using Moq;
using NUnit.Framework;

namespace Test.GivenTheOptionsDialog
{

  [TestFixture]
  public class WhenDefaultDuringBuildMusicSelected : GivenTheOptionsDialogBase
  {

    private Mock<IBuildMusicOptions> _BuildMusicOptions;

    [SetUp]
    public void TestSetup()
    {
      // arrange
      Initialize();
      _BuildMusicOptions = _Mockery.Create<IBuildMusicOptions>();
      _BuildMusicOptions.SetupAllProperties();
      _BuildMusicOptions.Object.DuringBuildMusic = "somethingAlreadySet.mp3";

      _Control.Initialize(_BuildMusicOptions.Object);
      _Control.DefaultMusicDuringBuild = true;

    }

    [Test]
    public void ThenShouldClearOtherDuringBuildMusic()
    {

      // act
      _Control.PersistDuringMusicSelection();

      // assert
      Assert.AreEqual(MusicPlayer.DefaultFileName, _BuildMusicOptions.Object.DuringBuildMusic, "Did not clear out the during build music setting");


    }

  }

}
