using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Covid_19Tracker.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer.Init();
            Syncfusion.XForms.iOS.TabView.SfTabViewRenderer.Init();
            Syncfusion.SfMaps.XForms.iOS.SfMapsRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Rg.Plugins.Popup.Popup.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
