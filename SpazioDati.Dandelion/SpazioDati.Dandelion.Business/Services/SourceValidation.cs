using System;
using SpazioDati.Dandelion.Models;

namespace SpazioDati.Dandelion.Services
{
    public class SourceValidation
    {
        public static string verifySingleSource(SourceParameters parameters){
            var source = "";
            if(!String.IsNullOrEmpty(parameters.Text))
            {
                source = $"text={parameters.Text}";
            }
            else if(!String.IsNullOrEmpty(parameters.Url))
            {
                if(!Uri.IsWellFormedUriString(parameters.Url, UriKind.RelativeOrAbsolute))
                {
                    throw new ArgumentException("Not well formed Url", "Url"); //TODO use inner exception
                } 
                else 
                {
                     source = $"url={parameters.Url}";
                }
            }
            else if(!String.IsNullOrEmpty(parameters.Html))
            {
                source = $"html={parameters.Html}";
            }
            else if(!String.IsNullOrEmpty(parameters.HtmlFragment))
            {
                source = $"html_fragment={parameters.HtmlFragment}";
            }
            if(String.IsNullOrEmpty(source))
            {            
                throw new ArgumentException("At least one filed between Text, Url, Html and HtmlFragment must be set"); 
            }
            return source;
        }

         public static string verifyMultipleSources(TextSimilarityParameters parameters){
            var source1 = "";
            var source2 = "";
            var errorMessage1 = "Only one parameter between Text1, Url1, Html1 and HtmlFragment1 must be set";
            var errorMessage2 = "Only one parameter between Text2, Url2, Html2 and HtmlFragment2 must be set";

            if(!String.IsNullOrEmpty(parameters.Text1))
            {
                source1 = $"text1={parameters.Text1}";
            }
            if(!String.IsNullOrEmpty(parameters.Url1) && !Uri.IsWellFormedUriString(parameters.Url1, UriKind.RelativeOrAbsolute))
            {
                if(!String.IsNullOrEmpty(source1))
                {
                    throw new ArgumentException(errorMessage1, "Url1");
                }
                source1 = $"url1={parameters.Url1}";
            }
            if(!String.IsNullOrEmpty(parameters.Html1))
            {
                if(!String.IsNullOrEmpty(source1))
                {
                    throw new ArgumentException(errorMessage1, "Html1");
                }
                source1 = $"html1={parameters.Html1}";
            }
            if(!String.IsNullOrEmpty(parameters.HtmlFragment1))
            {
                if(!String.IsNullOrEmpty(source1))
                {
                    throw new ArgumentException(errorMessage1, "HtmlFragment1");
                }
                source1 = $"html_fragment1={parameters.HtmlFragment1}";
            }

            if(!String.IsNullOrEmpty(parameters.Text2))
            {
                source2 = $"text2={parameters.Text2}";
            }
            if(!String.IsNullOrEmpty(parameters.Url2) && !Uri.IsWellFormedUriString(parameters.Url2, UriKind.RelativeOrAbsolute))
            {
                if(!String.IsNullOrEmpty(source2))
                {
                    throw new ArgumentException(errorMessage2, "Url2");
                }
                source2 = $"url2={parameters.Url2}";
            }
            if(!String.IsNullOrEmpty(parameters.Html2))
            {
                if(!String.IsNullOrEmpty(source2))
                {
                    throw new ArgumentException(errorMessage2, "Html2");
                }
                source2 = $"html2={parameters.Html2}";
            }
            if(!String.IsNullOrEmpty(parameters.HtmlFragment2))
            {
                if(!String.IsNullOrEmpty(source2))
                {
                    throw new ArgumentException(errorMessage2, "HtmlFragment2");
                }
                source2 = $"html_fragment2={parameters.HtmlFragment2}";
            }

            if(String.IsNullOrEmpty(source1) || String.IsNullOrEmpty(source2) )
            {
                throw new ArgumentException("Two text sources are needed"); 
            }
            return $"{source1}&{source2}";
         }
    }
}