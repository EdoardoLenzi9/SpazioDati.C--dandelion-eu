using System;

namespace SpazioDati.Dandelion.Domain.Models
{
    [Flags]
    public enum IncludeOption
    {
        types,
        @abstract, //need @ because is a keyword
        categories,
        image,
        lod,
        alternate_labels,
        score_details
    }

    [Flags]
    public enum ExtraTypesOption
    {
        phone,
        vat
    }


    [Flags]
    public enum LanguageOption
    {
        de,
        en,
        es,
        fr,
        it,
        pt,
        ru,
        auto
    }

    [Flags]
    public enum CountryOption
    {
        AD,
        AE,
        AM,
        AO,
        AQ,
        AR,
        AU,
        BB,
        BR,
        BS,
        BY,
        CA,
        CH,
        CL,
        CN,
        CX,
        DE,
        FR,
        GB,
        HU,
        IT,
        JP,
        KR,
        MX,
        NZ,
        PG,
        PL,
        RE,
        SE,
        SG,
        US,
        YT,
        ZW
    }

    [Flags]
    public enum BowOption
    {
        never,
        always,
        one_empty,
        both_empty
    }

    [Flags]
    public enum QueryOption
    {
        full,
        prefix
    }
}