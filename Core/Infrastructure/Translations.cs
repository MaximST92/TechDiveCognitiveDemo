﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace maximst.CognitiveDemo.Core.Infrastructure
{
	public static partial class Translations
	{
		static Dictionary<TranslationKey, Dictionary<string, string>> TranslationItems { get; }

		static Translations()
		{
			SetCultures(CultureInfo.CurrentCulture, new CultureInfo(Languages.First()));
			TranslationItems = new Dictionary<TranslationKey, Dictionary<string, string>>();
			Load();
		}

		static CultureInfo _currentCultureForTranslationKeys;

		public static CultureInfo Culture => _currentCultureForTranslationKeys;
		public static CultureInfo CultureWithRegion => CultureInfo.CurrentCulture;

		public static void SetCulture(CultureInfo culture)
		{
			// this method can be customized to accept a list of locales from the device OS and pick the language automatically
			SetCultures(culture, culture);
		}

		static void SetCultures(CultureInfo cultureWithRegion, CultureInfo translationKeyCulture)
		{
			_currentCultureForTranslationKeys = translationKeyCulture;
			CultureInfo.CurrentCulture = cultureWithRegion;
			CultureInfo.CurrentUICulture = cultureWithRegion;
			CultureInfo.DefaultThreadCurrentCulture = cultureWithRegion;
			CultureInfo.DefaultThreadCurrentUICulture = cultureWithRegion;
		}

		public static string GetString(TranslationKey key, CultureInfo culture = null)
		{
			if (culture == null)
			{
				culture = Culture;
			}

			var found = TranslationItems.TryGetValue(key, out var translations);
			if (!found)
			{
				return $"[{culture}]{key}";
			}

			found = translations.TryGetValue(culture.ToString(), out var translation);
			if (!found)
			{
				return $"[{culture}]{key}";
			}

			if (string.IsNullOrEmpty(translation) && translation != "|")
			{
				return $"[{culture}]{key}";
			}
			return translation;
		}
	}
}
