﻿using System.Collections.Generic;
using System.Globalization;

namespace maximst.CognitiveDemo.Core.Infrastructure
{
	public static partial class Translations
	{

		public static string[] Languages =
		{
			"nl",
			"fr",
		};

		public static string OK => GetString(TranslationKey.OK);

		public static string Cancel => GetString(TranslationKey.Cancel);

		static void Load()
		{ 
			TranslationItems.Add(TranslationKey.OK, new Dictionary<string, string> { { "nl", "OK" }, { "fr", "OK" } });
			TranslationItems.Add(TranslationKey.Cancel, new Dictionary<string, string> { { "nl", "Annuleren" }, { "fr", "Annuler" } });
		}
	}

	public enum TranslationKey
	{
		    OK,
	    Cancel,
	}
}
