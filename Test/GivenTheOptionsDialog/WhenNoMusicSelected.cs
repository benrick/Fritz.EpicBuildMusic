using Fritz.EpicBuildMusic.Core;
using Moq;
using NUnit.Framework;

namespace Test.GivenTheOptionsDialog
{

    [TestFixture]
  public class WhenNoMusicSelected : GivenTheOptionsDialogBase
  {
    protected Mock<IBuildMusicOptions> _buildMusicOptions;

    [SetUp]
    public void TestSetup()
    {
      // arrange
      Initialize();
      _buildMusicOptions = _Mockery.Create<IBuildMusicOptions>();
    }

    [Test]
    public void ShouldCheckDefaultMusicCheckbox()
    {

      // act
      _Control.Initialize(_buildMusicOptions.Object);

      // assert
      Assert.IsTrue(_Control.DefaultMusicDuringBuild, "No music was selected, but the DefaultMusicDuringBuild checkbox was not checked");


    }

    [Test]
    public void ShouldEmptyDefaultMusicTextbox()
    {

      // act
      _Control.Initialize(_buildMusicOptions.Object);

      // assert
      Assert.IsEmpty(_Control.OtherMusicDuringBuild, "No music was selected, but the DefaultMusicDuringBuild textbox had content");


    }
  }


}
