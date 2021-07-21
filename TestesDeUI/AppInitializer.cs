using System;
using Xamarin.UITest;

namespace TestesDeUI
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {            
            string appBundlePath = Environment.GetEnvironmentVariable("APP_BUNDLE_PATH");

            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile (appBundlePath)
                    .StartApp();
            }

            var iOSConfiguration = ConfigureApp.iOS;

            if (!string.IsNullOrEmpty(appBundlePath))
            {
                iOSConfiguration.AppBundle(appBundlePath);
            }

            string iosSimulatorUdid = Environment.GetEnvironmentVariable("IOS_SIMULATOR_UDID");
            if (!string.IsNullOrEmpty(iosSimulatorUdid))
            {
                iOSConfiguration.DeviceIdentifier(iosSimulatorUdid);
            }

            return iOSConfiguration.StartApp();
        }
    }
}
