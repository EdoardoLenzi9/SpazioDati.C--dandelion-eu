using System;
using System.Collections.Generic;

namespace SpazioDati.Dandelion.Models
{
    
    public class LanguageDetectionDto
    {
        public int Time;
        public List<DetectedLangsDto> DetectedLangs;
        public string Text;
        public string Url;
        public DateTime Timestamp;
    }

    public class DetectedLangsDto
    {
        public string Lang;
        public float Confidence;
    }
}