using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMemeSound5.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace AppMemeSound5.iOS
{
    public class Share : IShare
    {
        // MUST BE CALLED FROM THE UI THREAD
        public async Task Show(string title, string message, string filePath)
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            filePath = Path.Combine(documentsPath, filePath);

            var items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(filePath) };
            var activityController = new UIActivityViewController(items, null);
            var vc = GetVisibleViewController();

            NSString[] excludedActivityTypes = null;

            if (excludedActivityTypes != null && excludedActivityTypes.Length > 0)
                activityController.ExcludedActivityTypes = excludedActivityTypes;

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                if (activityController.PopoverPresentationController != null)
                {
                    activityController.PopoverPresentationController.SourceView = vc.View;
                }
            }
            await vc.PresentViewControllerAsync(activityController, true);
        }

        UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootController.PresentedViewController).TopViewController;
            }

            if (rootController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            }

            return rootController.PresentedViewController;
        }
    }
}