using System;
using System.Collections.Generic;

namespace SpazioDati.Dandelion.Models
{
    public class EntitiesDto
    {
        public int Time;
        public List<AnnotationDto> Annotations;
        public string Lang;
        public float LangConfidence;
        public string Text;
        public string Url;
        public DateTime Timestamp;
    }

    public class AnnotationDto
    {
        public int Start;
        public int End;
        public string Spot;
        public float Confidence;
        public int Id;
        public string Title;
        public string Uri;
        public string Label;
    }
}