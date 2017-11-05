using System;

namespace SpazioDati.Dandelion.Models
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
    }

    [Flags]
    public enum ExtraTypesOption
    {
 	    phone, 
        vat
    }


    [Flags]
    public enum Language
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
    public enum Country
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

}