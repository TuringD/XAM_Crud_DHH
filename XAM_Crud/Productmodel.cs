namespace XAM_Crud
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Productmodel
    {
        [JsonProperty("product")]
        public Product[] Product { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public long Price { get; set; }

        [JsonProperty("Creation")]
        public DateTimeOffset Creation { get; set; }

        [JsonProperty("Modification")]
        public DateTimeOffset Modification { get; set; }
    }

    public partial class Productmodel
    {
        public static Productmodel FromJson(string json) => JsonConvert.DeserializeObject<Productmodel>(json, XAM_Crud.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Productmodel self) => JsonConvert.SerializeObject(self, XAM_Crud.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
