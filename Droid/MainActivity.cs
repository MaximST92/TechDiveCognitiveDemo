using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using maximst.CognitiveDemo.Forms;
using MugenMvvmToolkit.Xamarin.Forms.Android;
using Plugin.Permissions;

namespace maximst.CognitiveDemo.Droid
{
	[Activity(Label = "CognitiveDemo", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

            var application = new App(new PlatformBootstrapperService(() => this));
			LoadApplication(application);
		}

	    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	    {
	        PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	    }
    }
}
