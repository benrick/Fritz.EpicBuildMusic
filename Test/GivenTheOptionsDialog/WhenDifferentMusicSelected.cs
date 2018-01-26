using Fritz.EpicBuildMusic.Core;
using Moq;
using NUnit.Framework;

namespace Test.GivenTheOptionsDialog
{

  [TestFixture]
  public class WhenDifferentMusicSelected : GivenTheOptionsDialogBase
  {
    private Mock<IBuildMusicOptions> _FullBuildMusicOptions;

    [SetUp]
    public void TestSetup()
    {
      // arrange
      Initialize();

      _FullBuildMusicOptions = _Mockery.Create<IBuildMusicOptions>();
      _FullBuildMusicOptions.SetupProperty(o => o.DuringBuildMusic);
      _FullBuildMusicOptions.Object.DuringBuildMusic = "someOther.mp3";

    }

    [Test]
    public void ShouldClearCheckDefaultMusicCheckbox()
    {

      // act
      _Control.Initialize(_FullBuildMusicOptions.Object);

      // assert
      Assert.IsFalse(_Control.DefaultMusicDuringBuild, "Music was selected, but the DefaultMusicDuringBuild checkbox was checked");


    }

    [Test]
    public void ShouldSetDuringBuildMusicTextbox()
    {

      // act
      _Control.Initialize(_FullBuildMusicOptions.Object);

      // assert
      Assert.IsNotEmpty(_Control.OtherMusicDuringBuild, "Music was selected, but the DefaultMusicDuringBuild textbox had no content");


    }


  }


}
