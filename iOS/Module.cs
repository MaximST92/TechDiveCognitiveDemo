using System;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models.IoC;
using maximst.CognitiveDemo.Core.WebServices.Interfaces;
using maximst.CognitiveDemo.iOS.Services;

namespace maximst.CognitiveDemo.iOS
{
	public class Module: IModule
	{
		public bool Load(IModuleContext context)
		{
			context.IocContainer.Bind<IHttpMessageHandlerProvider, HttpMessageHandlerProvider>(DependencyLifecycle.SingleInstance);

			return true;
		}

		public void Unload(IModuleContext context)
		{
			throw new NotImplementedException();
		}

		public int Priority => ApplicationSettings.ModulePriorityDefault;
		
	}
}
