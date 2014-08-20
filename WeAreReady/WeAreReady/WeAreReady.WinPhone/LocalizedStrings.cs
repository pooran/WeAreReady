using WeAreReady.WinPhone.Resources;

namespace WeAreReady.WinPhone
{
    /// <summary>
    /// Provides access to string resources. abc
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}
