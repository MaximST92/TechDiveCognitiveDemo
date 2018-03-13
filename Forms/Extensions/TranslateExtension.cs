using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using maximst.CognitiveDemo.Core.Notifications;
using maximst.CognitiveDemo.Core.Infrastructure;

namespace maximst.CognitiveDemo.Forms.Extensions
{
	[ContentProperty(nameof(Key))]
	public class TranslateExtension : IMarkupExtension<BindingBase>
	{
		public TranslationKey Key { get; set; }
		public bool UpperCase { get; set; }
		public string Suffix { get; set; }

		BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
		{
			return GetBinding();
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return GetBinding();
		}

		public Binding GetBinding()
		{
			var binding = new Binding(nameof(TranslateBinding.Value))
			{
				Source = new TranslateBinding(Key, UpperCase, Suffix)
			};
			return binding;
		}
	}

	public class TranslateBinding : INotifyPropertyChanged, IDisposable
	{
		readonly ISubscriber _languageChanged;
		readonly TranslationKey _key;
		readonly bool _upperCase;
		readonly string _suffix;

		public TranslateBinding(TranslationKey key, bool upperCase, string suffix)
		{
			_key = key;
			_upperCase = upperCase;
			_suffix = suffix;
			if(!ServiceProvider.IsDesignMode)
			{
				_languageChanged = ServiceProvider.EventAggregator.Subscribe<LanguageChangedNotification>(OnLanguageChanged);
			}
		}

		~TranslateBinding()
		{
			Dispose(false);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public object Value
		{
			get
			{
				var result = Translations.GetString(_key, Translations.Culture);
				if (_upperCase) result = result.ToUpper();
				return result + _suffix;
			}
		}

		void OnLanguageChanged(object o, LanguageChangedNotification args)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_languageChanged != null)
				{
					ServiceProvider.EventAggregator.Unsubscribe(_languageChanged);
				}
			}
		}
	}
}



