using System.Collections.Generic;

namespace Pages.Entities
{
    public class TestCase
    {
        public static List<string> languageCases = new List<string>
        {
            "Kotlin",
            "JavaScript",
            "Ruby",
            "CSharp",
            "Python",
            "Java"
        };

        public static List<SupportedLanguage> languageAndCodeAreaCases = new List<SupportedLanguage>
        {
            new SupportedLanguage
            {
                LanguageTab = "Kotlin",
                LanguageArea = "kt"
            },
            new SupportedLanguage
            {
                LanguageTab = "JavaScript",
                LanguageArea = "js"
            },
            new SupportedLanguage
            {
                LanguageTab = "Ruby",
                LanguageArea = "rb"
            },
            new SupportedLanguage
            {
                LanguageTab = "CSharp",
                LanguageArea = "cs"
            },
            new SupportedLanguage
            {
                LanguageTab = "Python",
                LanguageArea = "py"
            },
            new SupportedLanguage
            {
                LanguageTab = "Java",
                LanguageArea = "java"
            },
        };
    }
}
