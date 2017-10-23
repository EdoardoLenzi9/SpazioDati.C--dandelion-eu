using System;
using System.Collections.Generic;

namespace SpazioDati.Dandelion
{
    class LanguageDetectionDto
    {
        public int Time;
        public List<DetectedLangsDto> DetectedLangs;
        public string Text;
        public string Url;
        public DateTime Timestamp;
    }

    class DetectedLangsDto
    {
        public string Lang;
        public float Confidence;
    }
}