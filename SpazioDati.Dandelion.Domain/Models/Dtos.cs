using System;
using System.Collections.Generic;

namespace SpazioDati.Dandelion.Domain.Models
{
    public class ResponseDto
    {
        public DateTime Timestamp;
        public int Time;
        public string Lang;
        public double LangConfidence;
        public string Text;
        public string Url;
    }

    public class EntityExtractionDto : ResponseDto
    {
        public List<AnnotationDto> Annotations;
    }

    public class AnnotationDto
    {
        public int Start;
        public int End;
        public string Spot;
        public double Confidence;
        public int Id;
        public string Title;
        public string Uri;
        public string Label;
    }

    public class TextSimilarityDto : ResponseDto
    {
        public string Text1;
        public string Url1;
        public string Text2;
        public string Url2;
        public double Similarity;
    }

    public class TextClassificationDto : ResponseDto
    {
        public List<Category> Categories;
    }

    public class Category
    {
        public string Name;
        public double Score;
        public List<ScoreDetail> ScoreDetails;
    }

    public class ScoreDetail
    {
        public string Entity;
        public double Weight;
    }

    public class LanguageDetectionDto : ResponseDto
    {
        public List<DetectedLang> DetectedLangs;
    }

    public class DetectedLang
    {
        public LanguageOption Lang;
        public double Confidence;
    }

    public class SentimentAnalysisDto : ResponseDto
    {
        public Sentiment Sentiment;
    }

    public class Sentiment
    {
        public double score;
        public string type; //TODO make enum
    }

    public class WikisearchDto
    {
        public DateTime Timestamp;
        public int Time;
        public int Count;
        public string Lang;
        public List<Entity> Entities;
        public string Query;
    }

    public class Entity
    {
        public double Weight;
        public int Id;
        public string Title;
        public string Uri;
        public string Label;
        public List<Type> Types;
        public List<Category> Categories;
        public string Abstract;
        public Lod Lod;
        public Image Image;
    }

    public class Lod
    {
        public string Wikipedia;
        public string DbPedia;
    }

    public class Image
    {
        public string Full;
        public string Thumbnail;
    }
}