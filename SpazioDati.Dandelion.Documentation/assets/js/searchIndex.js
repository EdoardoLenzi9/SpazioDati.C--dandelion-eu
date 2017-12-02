
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"Program",
        content:"Program",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"CustomModelCategoryParameters",
        content:"CustomModelCategoryParameters",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"EntityExtractionDto",
        content:"EntityExtractionDto",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"EntityExtractionParameters",
        content:"EntityExtractionParameters",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"SentimentAnalysisDto",
        content:"SentimentAnalysisDto",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"TextSimilarityService",
        content:"TextSimilarityService",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"ServiceFixture",
        content:"ServiceFixture",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"DetectedLang",
        content:"DetectedLang",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"Entity",
        content:"Entity",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"TextSimilarityParameters",
        content:"TextSimilarityParameters",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"CustomSpotDataParameters",
        content:"CustomSpotDataParameters",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"CustomSpotService",
        content:"CustomSpotService",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"LanguageOption",
        content:"LanguageOption",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"SentimentAnalysisService",
        content:"SentimentAnalysisService",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"DefaultsDto",
        content:"DefaultsDto",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"RedundancyList",
        content:"RedundancyList",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"Lifestyle",
        content:"Lifestyle",
        description:'',
        tags:''
    });

    a({
        id:17,
        title:"CustomSpotListParameters",
        content:"CustomSpotListParameters",
        description:'',
        tags:''
    });

    a({
        id:18,
        title:"Lod",
        content:"Lod",
        description:'',
        tags:''
    });

    a({
        id:19,
        title:"SentimentAnalysisValidationTests",
        content:"SentimentAnalysisValidationTests",
        description:'',
        tags:''
    });

    a({
        id:20,
        title:"CustomModelsListDto",
        content:"CustomModelsListDto",
        description:'',
        tags:''
    });

    a({
        id:21,
        title:"LanguageDetectionDto",
        content:"LanguageDetectionDto",
        description:'',
        tags:''
    });

    a({
        id:22,
        title:"Image",
        content:"Image",
        description:'',
        tags:''
    });

    a({
        id:23,
        title:"ApiClient",
        content:"ApiClient",
        description:'',
        tags:''
    });

    a({
        id:24,
        title:"WikisearchValidationTests",
        content:"WikisearchValidationTests",
        description:'',
        tags:''
    });

    a({
        id:25,
        title:"WikisearchParameters",
        content:"WikisearchParameters",
        description:'',
        tags:''
    });

    a({
        id:26,
        title:"TextClassificationParameters",
        content:"TextClassificationParameters",
        description:'',
        tags:''
    });

    a({
        id:27,
        title:"Localizations",
        content:"Localizations",
        description:'',
        tags:''
    });

    a({
        id:28,
        title:"SourceValidationTests",
        content:"SourceValidationTests",
        description:'',
        tags:''
    });

    a({
        id:29,
        title:"EntityExtractionService",
        content:"EntityExtractionService",
        description:'',
        tags:''
    });

    a({
        id:30,
        title:"CustomModelDataParameters",
        content:"CustomModelDataParameters",
        description:'',
        tags:''
    });

    a({
        id:31,
        title:"DefaultValues",
        content:"DefaultValues",
        description:'',
        tags:''
    });

    a({
        id:32,
        title:"CustomModelDataDto",
        content:"CustomModelDataDto",
        description:'',
        tags:''
    });

    a({
        id:33,
        title:"ListDto",
        content:"ListDto",
        description:'',
        tags:''
    });

    a({
        id:34,
        title:"SourceParameters",
        content:"SourceParameters",
        description:'',
        tags:''
    });

    a({
        id:35,
        title:"CategoriesDto",
        content:"CategoriesDto",
        description:'',
        tags:''
    });

    a({
        id:36,
        title:"EntityExtractionValidationTests",
        content:"EntityExtractionValidationTests",
        description:'',
        tags:''
    });

    a({
        id:37,
        title:"TextClassificationService",
        content:"TextClassificationService",
        description:'',
        tags:''
    });

    a({
        id:38,
        title:"LanguageDetectionService",
        content:"LanguageDetectionService",
        description:'',
        tags:''
    });

    a({
        id:39,
        title:"Category",
        content:"Category",
        description:'',
        tags:''
    });

    a({
        id:40,
        title:"ExtraTypesOption",
        content:"ExtraTypesOption",
        description:'',
        tags:''
    });

    a({
        id:41,
        title:"CustomModelParameters",
        content:"CustomModelParameters",
        description:'',
        tags:''
    });

    a({
        id:42,
        title:"Parameters",
        content:"Parameters",
        description:'',
        tags:''
    });

    a({
        id:43,
        title:"CountryOption",
        content:"CountryOption",
        description:'',
        tags:''
    });

    a({
        id:44,
        title:"CustomSpotsListDto",
        content:"CustomSpotsListDto",
        description:'',
        tags:''
    });

    a({
        id:45,
        title:"AnnotationDto",
        content:"AnnotationDto",
        description:'',
        tags:''
    });

    a({
        id:46,
        title:"SourceValidationService",
        content:"SourceValidationService",
        description:'',
        tags:''
    });

    a({
        id:47,
        title:"ErrorMessages",
        content:"ErrorMessages",
        description:'',
        tags:''
    });

    a({
        id:48,
        title:"ResponseDto",
        content:"ResponseDto",
        description:'',
        tags:''
    });

    a({
        id:49,
        title:"CustomSpotDto",
        content:"CustomSpotDto",
        description:'',
        tags:''
    });

    a({
        id:50,
        title:"BowOption",
        content:"BowOption",
        description:'',
        tags:''
    });

    a({
        id:51,
        title:"Sentiment",
        content:"Sentiment",
        description:'',
        tags:''
    });

    a({
        id:52,
        title:"TextClassificationDto",
        content:"TextClassificationDto",
        description:'',
        tags:''
    });

    a({
        id:53,
        title:"QueryOption",
        content:"QueryOption",
        description:'',
        tags:''
    });

    a({
        id:54,
        title:"WikisearchDto",
        content:"WikisearchDto",
        description:'',
        tags:''
    });

    a({
        id:55,
        title:"TextSimilarityDto",
        content:"TextSimilarityDto",
        description:'',
        tags:''
    });

    a({
        id:56,
        title:"Container",
        content:"Container",
        description:'',
        tags:''
    });

    a({
        id:57,
        title:"WikisearchService",
        content:"WikisearchService",
        description:'',
        tags:''
    });

    a({
        id:58,
        title:"CustomSpotParameters",
        content:"CustomSpotParameters",
        description:'',
        tags:''
    });

    a({
        id:59,
        title:"CustomSpotsDataDto",
        content:"CustomSpotsDataDto",
        description:'',
        tags:''
    });

    a({
        id:60,
        title:"TextClassificationValidationTests",
        content:"TextClassificationValidationTests",
        description:'',
        tags:''
    });

    a({
        id:61,
        title:"CustomModelService",
        content:"CustomModelService",
        description:'',
        tags:''
    });

    a({
        id:62,
        title:"SentimentAnalysisParameters",
        content:"SentimentAnalysisParameters",
        description:'',
        tags:''
    });

    a({
        id:63,
        title:"ScoreDetail",
        content:"ScoreDetail",
        description:'',
        tags:''
    });

    a({
        id:64,
        title:"DandelionUtils",
        content:"DandelionUtils",
        description:'',
        tags:''
    });

    a({
        id:65,
        title:"IncludeOption",
        content:"IncludeOption",
        description:'',
        tags:''
    });

    a({
        id:66,
        title:"ServiceUtils",
        content:"ServiceUtils",
        description:'',
        tags:''
    });

    a({
        id:67,
        title:"CustomModelDto",
        content:"CustomModelDto",
        description:'',
        tags:''
    });

    a({
        id:68,
        title:"LanguageDetectionParameters",
        content:"LanguageDetectionParameters",
        description:'',
        tags:''
    });

    y({
        url:'/api/SpazioDati.Dandelion.ConsoleApp/Program',
        title:"Program",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomModelCategoryParameters',
        title:"CustomModelCategoryParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/EntityExtractionDto',
        title:"EntityExtractionDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/EntityExtractionParameters',
        title:"EntityExtractionParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/SentimentAnalysisDto',
        title:"SentimentAnalysisDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/TextSimilarityService',
        title:"TextSimilarityService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Test/ServiceFixture',
        title:"ServiceFixture",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/DetectedLang',
        title:"DetectedLang",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Entity',
        title:"Entity",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/TextSimilarityParameters',
        title:"TextSimilarityParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomSpotDataParameters',
        title:"CustomSpotDataParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/CustomSpotService',
        title:"CustomSpotService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/LanguageOption',
        title:"LanguageOption",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/SentimentAnalysisService',
        title:"SentimentAnalysisService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/DefaultsDto',
        title:"DefaultsDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Extensions/RedundancyList',
        title:"RedundancyList",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Containers/Lifestyle',
        title:"Lifestyle",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomSpotListParameters',
        title:"CustomSpotListParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Lod',
        title:"Lod",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Test.ValidationTests/SentimentAnalysisValidationTests',
        title:"SentimentAnalysisValidationTests",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomModelsListDto',
        title:"CustomModelsListDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/LanguageDetectionDto',
        title:"LanguageDetectionDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Image',
        title:"Image",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Clients/ApiClient',
        title:"ApiClient",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Test.ValidationTests/WikisearchValidationTests',
        title:"WikisearchValidationTests",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/WikisearchParameters',
        title:"WikisearchParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/TextClassificationParameters',
        title:"TextClassificationParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Localizations',
        title:"Localizations",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Test.ValidationTests/SourceValidationTests',
        title:"SourceValidationTests",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/EntityExtractionService',
        title:"EntityExtractionService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomModelDataParameters',
        title:"CustomModelDataParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/DefaultValues',
        title:"DefaultValues",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomModelDataDto',
        title:"CustomModelDataDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/ListDto',
        title:"ListDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/SourceParameters',
        title:"SourceParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CategoriesDto',
        title:"CategoriesDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Test.ValidationTests/EntityExtractionValidationTests',
        title:"EntityExtractionValidationTests",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/TextClassificationService',
        title:"TextClassificationService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/LanguageDetectionService',
        title:"LanguageDetectionService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Category',
        title:"Category",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/ExtraTypesOption',
        title:"ExtraTypesOption",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomModelParameters',
        title:"CustomModelParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Parameters',
        title:"Parameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CountryOption',
        title:"CountryOption",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomSpotsListDto',
        title:"CustomSpotsListDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/AnnotationDto',
        title:"AnnotationDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/SourceValidationService',
        title:"SourceValidationService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/ErrorMessages',
        title:"ErrorMessages",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/ResponseDto',
        title:"ResponseDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomSpotDto',
        title:"CustomSpotDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/BowOption',
        title:"BowOption",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/Sentiment',
        title:"Sentiment",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/TextClassificationDto',
        title:"TextClassificationDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/QueryOption',
        title:"QueryOption",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/WikisearchDto',
        title:"WikisearchDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/TextSimilarityDto',
        title:"TextSimilarityDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Containers/Container',
        title:"Container",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/WikisearchService',
        title:"WikisearchService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomSpotParameters',
        title:"CustomSpotParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomSpotsDataDto',
        title:"CustomSpotsDataDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Test.ValidationTests/TextClassificationValidationTests',
        title:"TextClassificationValidationTests",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/CustomModelService',
        title:"CustomModelService",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/SentimentAnalysisParameters',
        title:"SentimentAnalysisParameters",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/ScoreDetail',
        title:"ScoreDetail",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business/DandelionUtils',
        title:"DandelionUtils",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/IncludeOption',
        title:"IncludeOption",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Business.Services/ServiceUtils',
        title:"ServiceUtils",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/CustomModelDto',
        title:"CustomModelDto",
        description:""
    });

    y({
        url:'/api/SpazioDati.Dandelion.Domain.Models/LanguageDetectionParameters',
        title:"LanguageDetectionParameters",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
