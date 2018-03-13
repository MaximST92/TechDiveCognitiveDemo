using MugenMvvmToolkit;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using maximst.CognitiveDemo.Forms.DesignTime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace maximst.CognitiveDemo.Forms
{
    public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		public App(XamarinFormsBootstrapperBase.IPlatformService platformService)
		{			
			InitializeComponent();
			
			var context = DataContext.Empty;
			
			var bootstrapperBase = XamarinFormsBootstrapperBase.Current;
			if (bootstrapperBase == null)
			{
				bootstrapperBase = CreateBootstrapper(platformService, context);
			}

			bootstrapperBase.InitializationContext = bootstrapperBase.InitializationContext.ToNonReadOnly();
			bootstrapperBase.InitializationContext.AddOrUpdate(ViewModelConstants.StateNotNeeded, true);
			bootstrapperBase.Start();
		}

		XamarinFormsBootstrapperBase CreateBootstrapper(
			XamarinFormsBootstrapperBase.IPlatformService platformService, IDataContext context)
		{
			if (platformService == null)
			{
				return new DesignBootstrapper();
			}

			return new Bootstrapper(platformService);
		}
	}
}
