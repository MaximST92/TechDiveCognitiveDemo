using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MugenMvvmToolkit;
using MugenMvvmToolkit.ViewModels;

namespace maximst.CognitiveDemo.Core.ViewModels.Base
{
	public abstract class BaseViewModel : WorkspaceViewModel
	{
	    public IUserDialogs Dialogs => UserDialogs.Instance;
		public virtual Task<bool> Initialize(bool showErrorMessagesOnFailure = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Empty.TrueTask;
		}

		protected override void OnNavigatedTo(MugenMvvmToolkit.Interfaces.Navigation.INavigationContext context)
		{
			ThreadManager.Invoke(ThreadManager.IsUiThread ? MugenMvvmToolkit.Models.ExecutionMode.AsynchronousOnUiThread : MugenMvvmToolkit.Models.ExecutionMode.Asynchronous, async () => await OnNavigatedToAsync(context)); ;
			base.OnNavigatedTo(context);
		}

		protected virtual Task OnNavigatedToAsync(MugenMvvmToolkit.Interfaces.Navigation.INavigationContext context)
		{
			return Empty.Task;
		}
	}
}
