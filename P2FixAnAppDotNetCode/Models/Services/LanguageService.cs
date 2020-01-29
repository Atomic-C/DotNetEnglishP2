using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language) //We're passing language
        {
            string culture = "";
            switch (language) // We're taking a look at the value of language with a switch case, found here https://www.w3schools.com/cs/cs_switch.asp
            {
                case "French":
                    culture = "fr";
                    break;

                case "Spanish":
                    culture = "es";
                    break;
                default: //The default switch will make sure any other language request which is not available will be presented with English.
                    culture = "en";
                    break;
            }            
            // TODO complete the code 
            // Default language is "en", french is "fr" and spanish is "es".
            
            return culture;
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
