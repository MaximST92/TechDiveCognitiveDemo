using System.Globalization;
using System.Linq;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Xamarin.Forms.Infrastructure;
using maximst.CognitiveDemo.Core.Infrastructure;

namespace maximst.CognitiveDemo.Forms
{
    public class Bootstrapper: XamarinFormsBootstrapperBase
    {
        public Bootstrapper(IPlatformService platformService):base(platformService)
        {
        }

        protected override IMvvmApplication CreateApplication()
        {
            return new Core.App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        protected override System.Collections.Generic.IList<System.Reflection.Assembly> GetAssemblies()
        {
            return base.GetAssemblies().Where(a => a.FullName.Contains(nameof(maximst)) || a.FullName.Contains(nameof(CognitiveDemo)) || a.FullName.Contains(nameof(MugenMvvmToolkit))).ToList();
        }

		void RestoreServices()
		{
#if DEBUG
			Tracer.TraceInformation = true;
			Tracer.TraceWarning = true;
			Tracer.TraceError = true;
#endif
		}

		protected override void InitializeInternal()
		{
			base.InitializeInternal();
			RestoreServices();
		}
	}
}
