using System;
using Covid_19Tracker.iOS.Renderers;
using Covid19Tracker.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomShell), typeof(CustomShellRenderer))]
namespace Covid_19Tracker.iOS.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var renderer = base.CreateShellItemRenderer(item);
            (renderer as ShellItemRenderer).TabBar.Translucent = false;
            return renderer;
        }
    }
}

//public class CustomShellRenderer : ShellRenderer
//{
//    protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
//    {
//        var renderer = base.CreateShellSectionRenderer(shellSection);
//        if (renderer != null)
//        {
//            var a = (renderer as ShellSectionRenderer);
//            (renderer as ShellSectionRenderer).NavigationBar.Translucent = false;
//        }
//        return renderer;
//    }

    
//}