using System.Collections.Generic;

namespace SpazioDati.Dandelion.Models
{
    public class EntityExtractionParameters
    {
        public string Text;
        public string Url;
        public string Html;
        public string HtmlFragment;
        public Language Lang = Language.auto; 
        public int TopEntities = 0; 
        public float MinConfidence = 0.6F;
        public int MinLength = 2; 
        public bool SocialHashtag = false;  
        public bool SocialMention = false;
        public List<IncludeOption> Include = null; 
        public List<ExtraTypesOption> ExtraTypes = null;
        public Country? Country = null;
        public string CustomSpots = "";                            
    }
}