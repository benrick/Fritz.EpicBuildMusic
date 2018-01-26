using Fritz.EpicBuildMusic.Core;
using Moq;

namespace Test.GivenTheOptionsDialog
{
  public abstract class GivenTheOptionsDialogBase
  {
    protected MockRepository _Mockery;
    protected GeneralOptionsUserControl _Control;

    protected void Initialize()
    {
      _Mockery = new MockRepository(MockBehavior.Loose);
      _Control = new GeneralOptionsUserControl();
    }
  }

}
