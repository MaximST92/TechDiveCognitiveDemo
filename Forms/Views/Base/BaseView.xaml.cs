using MugenMvvmToolkit.Xamarin.Forms;
using Xamarin.Forms;

namespace maximst.CognitiveDemo.Forms.Views.Base
{
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
        }

		protected override bool OnBackButtonPressed()
		{
			return this.HandleBackButtonPressed(() => base.OnBackButtonPressed());
		}
    }
}
