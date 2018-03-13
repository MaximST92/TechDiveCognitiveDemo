using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.ViewModels;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;

namespace maximst.CognitiveDemo.Forms.DesignTime
{
	public partial class DesignBootstrapper: XamarinFormsDesignBootstrapperBase
	{
		static DesignBootstrapper Instance
		{
			get
			{
				if (!ServiceProvider.IsDesignMode)
					return null;

				var designBootstrapper = new DesignBootstrapper();
				designBootstrapper.Initialize();
				return designBootstrapper;
			}
		}

		protected override IMvvmApplication CreateApplication()
		{
			return new Core.App();
		}

		protected override IIocContainer CreateIocContainer()
		{
			return new AutofacContainer();
		}

		protected override IList<Assembly> GetAssemblies()
		{
			return base.GetAssemblies().Where(a => a.FullName.Contains(nameof(maximst)) || a.FullName.Contains(nameof(CognitiveDemo)) || a.FullName.Contains(nameof(MugenMvvmToolkit))).ToList();
		}

		static TViewModel GetViewModel<TViewModel>() where TViewModel : IViewModel
		{
			return Instance.GetDesignViewModel(provider => provider.GetViewModel<TViewModel>());
		}
	}
}
