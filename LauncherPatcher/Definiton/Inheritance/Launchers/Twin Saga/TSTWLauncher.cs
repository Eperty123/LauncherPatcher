using LauncherPatcher.Definiton.Enum;

namespace LauncherPatcher.Definiton.Inheritance.Launchers.Twin_Saga
{
    public class TSTWLauncher : Launcher
    {
        #region Constructors
        public TSTWLauncher(LauncherInfo launcherInfo, string file) : base(launcherInfo, file)
        {
        }

        public TSTWLauncher(LauncherRegionType launcherRegionType, string header) : base(launcherRegionType, header)
        {
        }

        public TSTWLauncher(LauncherRegionType launcherRegionType, string header, LauncherInfo launcherInfo) : base(launcherRegionType, header, launcherInfo)
        {
        }
        #endregion
    }
}
