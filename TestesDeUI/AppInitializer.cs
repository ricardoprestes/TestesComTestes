using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TestesDeUI
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            // TODO: If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif

            

            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                    .StartApp();
            }

            var iOSConfiguration = ConfigureApp.iOS;

            string appBundlePath = Environment.GetEnvironmentVariable("APP_BUNDLE_PATH");
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
