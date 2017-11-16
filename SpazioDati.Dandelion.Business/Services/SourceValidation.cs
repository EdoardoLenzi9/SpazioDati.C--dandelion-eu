using System;
using System.Collections.Generic;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Services
{
    public class SourceValidation
    {
        public static List<KeyValuePair<string, string>> verifySingleSource(SourceParameters parameters)
        { //TODO testme
            var key = "";
            var value = "";
            if (!String.IsNullOrEmpty(parameters.Text))
            {
                key = "text";
                value = $"{parameters.Text}";
            }
            else if (!String.IsNullOrEmpty(parameters.Url) && Uri.IsWellFormedUriString(parameters.Url, UriKind.RelativeOrAbsolute))
            {
                if (!String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ErrorMessages.MultipleSources, ErrorMessages.Url);
                }
                key = "url";
                value = $"{parameters.Url}";
            }
            else if (!String.IsNullOrEmpty(parameters.Html))
            {
                if (!String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ErrorMessages.MultipleSources, ErrorMessages.Html);
                }
                key = "html";
                value = $"{parameters.Html}";
            }
            else if (!String.IsNullOrEmpty(parameters.HtmlFragment))
            {
                if (!String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ErrorMessages.MultipleSources, ErrorMessages.HtmlFragment);
                }
                key = "html_fragment";
                value = $"{parameters.HtmlFragment}";
            }
            if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ErrorMessages.WrongSource);
            }
            var source = new List<KeyValuePair<string, string>>();
            source.Add(new KeyValuePair<string, string>(key, value));
            return source;
        }

        public static List<KeyValuePair<string, string>> verifySingleSource(WikisearchParameters parameters)
        {
            if (String.IsNullOrEmpty(parameters.Text))
            {
                throw new ArgumentException(ErrorMessages.WrongText, ErrorMessages.Text);
            }
            var source = new List<KeyValuePair<string, string>>();
            source.Add(new KeyValuePair<string, string>("text", $"{parameters.Text}"));
            return source;
        }

        public static List<KeyValuePair<string, string>> verifyMultipleSources(TextSimilarityParameters parameters)
        {
            var key1 = "";
            var value1 = "";
            var key2 = "";
            var value2 = "";

            if (!String.IsNullOrEmpty(parameters.Text1))
            {
                key1 = "text1";
                value1 = $"{parameters.Text1}";
            }
            if (!String.IsNullOrEmpty(parameters.Url1) && !Uri.IsWellFormedUriString(parameters.Url1, UriKind.RelativeOrAbsolute))
            {
                if (!String.IsNullOrEmpty(value1))
                {
                    throw new ArgumentException(ErrorMessages.WrongSource1, ErrorMessages.Url1);
                }
                key1 = "url1";
                value1 = $"{parameters.Url1}";
            }
            if (!String.IsNullOrEmpty(parameters.Html1))
            {
                if (!String.IsNullOrEmpty(value1))
                {
                    throw new ArgumentException(ErrorMessages.WrongSource1, ErrorMessages.Html1);
                }
                key1 = "html1";
                value1 = $"{parameters.Html1}";
            }
            if (!String.IsNullOrEmpty(parameters.HtmlFragment1))
            {
                if (!String.IsNullOrEmpty(value1))
                {
                    throw new ArgumentException(ErrorMessages.WrongSource1, ErrorMessages.HtmlFragment1);
                }
                key1 = "html_fragment1";
                value1 = $"{parameters.HtmlFragment1}";
            }

            if (!String.IsNullOrEmpty(parameters.Text2))
            {
                key2 = "text2";
                value2 = $"{parameters.Text2}";
            }
            if (!String.IsNullOrEmpty(parameters.Url2) && !Uri.IsWellFormedUriString(parameters.Url2, UriKind.RelativeOrAbsolute))
            {
                if (!String.IsNullOrEmpty(value2))
                {
                    throw new ArgumentException(ErrorMessages.WrongSource2, ErrorMessages.Url2);
                }
                key2 = "url2";
                value2 = $"{parameters.Url2}";
            }
            if (!String.IsNullOrEmpty(parameters.Html2))
            {
                if (!String.IsNullOrEmpty(value2))
                {
                    throw new ArgumentException(ErrorMessages.WrongSource2, ErrorMessages.Html2);
                }
                key2 = "html2";
                value2 = $"{parameters.Html2}";
            }
            if (!String.IsNullOrEmpty(parameters.HtmlFragment2))
            {
                if (!String.IsNullOrEmpty(value2))
                {
                    throw new ArgumentException(ErrorMessages.WrongSource2, ErrorMessages.HtmlFragment2);
                }
                key2 = "html_fragment2";
                value2 = $"{parameters.HtmlFragment2}";
            }

            if (String.IsNullOrEmpty(value1) || String.IsNullOrEmpty(value2))
            {
                throw new ArgumentException(ErrorMessages.WrongSources);
            }

            var source = new List<KeyValuePair<string, string>>();
            source.Add(new KeyValuePair<string, string>(key1, value1));
            source.Add(new KeyValuePair<string, string>(key2, value2));
            return source;
        }
    }
}