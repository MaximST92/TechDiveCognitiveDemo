using System;
using System.Reflection;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;

namespace maximst.CognitiveDemo.Core
{
	public class Module: IModule
	{
		public bool Load(IModuleContext context)
		{
			//TODO: add context.IocContainer.Bind<Interface, Implementation>(lifecycle)

			return true;
		}

		public void Unload(IModuleContext context)
		{
			throw new NotImplementedException();
		}

		public int Priority => ApplicationSettings.ModulePriorityDefault;
		
	}
}
