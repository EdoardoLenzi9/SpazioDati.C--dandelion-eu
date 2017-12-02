using System;
using System.Collections.Generic;

namespace SpazioDati.Dandelion.Domain.Models
{
    ///<summary> 
    ///     Generic model class extended by any other Dto class 
    ///</summary>
    public class ResponseDto
    {
        public DateTime Timestamp;
        public int Time;
        public string Lang;
        public double LangConfidence;
        public string Text;
        public string Url;
    }

    ///<summary> 
    ///     Model class for deserialize the response of an EntityExtraction API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/nex/v1/#response">Dandelion page</see>
    ///</summary>
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

    ///<summary> 
    ///     Model class for deserialize the response of an TextSimilarity API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/sim/v1/#response">Dandelion page</see>
    ///</summary>
    public class TextSimilarityDto : ResponseDto
    {
        public string Text1;
        public string Url1;
        public string Text2;
        public string Url2;
        public double Similarity;
    }

    ///<summary> 
    ///     Model class for deserialize the response of an TextClassification API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/cl/v1/#response">Dandelion page</see>
    ///</summary>
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

    ///<summary> 
    ///     Model class for deserialize the response of an LanguageDetection API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/li/v1/#response">Dandelion page</see>
    ///</summary>
    public class LanguageDetectionDto : ResponseDto
    {
        public List<DetectedLang> DetectedLangs;
    }

    public class DetectedLang
    {
        public LanguageOption Lang;
        public double Confidence;
    }

    ///<summary> 
    ///     Model class for deserialize the response of an SentimentAnalysis API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/sent/v1/#response">Dandelion page</see>
    ///</summary>
    public class SentimentAnalysisDto : ResponseDto
    {
        public Sentiment Sentiment;
    }

    public class Sentiment
    {
        public double score;
        public string type; //TODO make enum
    }

    ///<summary> 
    ///     Model class for deserialize the response of an Wikisearch API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datagraph/wikisearch/#response">Dandelion page</see>
    ///</summary>
    public class WikisearchDto
    {
        public DateTime Timestamp;
        public int Time;
        public int Count;
        public string Lang;
        public List<Entity> Entities;
        public string Query;
    }

    ///<summary> 
    ///     Model class for deserialize the response of an CustomSpot API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/">Dandelion page</see>
    ///</summary>
    public class CustomSpotDto
    {
        public string Id;
        public CustomSpotsDataDto Data;
        public DateTime Created;
        public DateTime Modified;
        public string DataType;
        public DateTime Timestamp;
    }

    public class CustomSpotsListDto
    {
        public int Count;
        public List<CustomSpotDto> Items;
    }

    public class CustomSpotsDataDto
    {
        public string Lang;
        public DefaultsDto Defaults;
        public ListDto List;
        public string Description;
    }

    public class DefaultsDto
    {
        public bool ExactMatch;
        public bool Greedy;
        public bool NamedEntity;
    }

    public class ListDto
    {
        public string Spot;
        public string Topic;
        public bool ExactMatch;
        public bool Greedy;
        public bool NamedEntity;
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

    public class CustomModelsListDto
    {
        public int Count;
        public List<CustomModelDto> Items;
    }

    ///<summary> 
    ///     Model class for deserialize the response of an CustomModel API call; 
    ///     Complete description of the variables on the <see href="https://dandelion.eu/docs/api/datatxt/cl/v1/">Dandelion page</see>
    ///</summary>
    public class CustomModelDto
    {
        public string Id;
        public CustomModelDataDto Data;
        public DateTime Created;
        public DateTime Modified;
    }

    public class CustomModelDataDto
    {
        public string Lang;
        public List<CategoriesDto> Categories;
        public string Description;
    }

    public class CategoriesDto
    {
        public string Name;
        public Dictionary<string, float> Topics;
    }
}