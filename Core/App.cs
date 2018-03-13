using System;
using maximst.CognitiveDemo.Core.ViewModels;
using MugenMvvmToolkit;

namespace maximst.CognitiveDemo.Core
{
	public class App : MvvmApplication
	{
		public override Type GetStartViewModelType()
		{
		    return typeof(MainViewModel);
		}

		protected override void OnInitialize(System.Collections.Generic.IList<System.Reflection.Assembly> assemblies)
		{
			base.OnInitialize(assemblies);

#if DEBUG
			Tracer.TraceInformation = true;
			Tracer.TraceWarning = true;
			Tracer.TraceError = true;
#endif
		}
	}
}
