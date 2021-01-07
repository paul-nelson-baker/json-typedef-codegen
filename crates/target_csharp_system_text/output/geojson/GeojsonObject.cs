
using System;

using System.Text.Json;

using System.Text.Json.Serialization;

namespace JtdCodegenE2E
{
    /// <summary>
    /// A Geometry object represents points, curves, and surfaces in coordinate
    /// space.  Every Geometry object is a GeoJSON object no matter where it
    /// occurs in a GeoJSON text.
    /// 
    /// o  The value of a Geometry object's "type" member MUST be one of the
    ///     seven geometry types (see Section 1.4).
    /// 
    /// o  A GeoJSON Geometry object of any type other than
    ///     "GeometryCollection" has a member with the name "coordinates". The
    ///     value of the "coordinates" member is an array.  The structure of the
    ///     elements in this array is determined by the type of geometry.
    ///     GeoJSON processors MAY interpret Geometry objects with empty
    ///     "coordinates" arrays as null objects.
    /// </summary>

    [JsonConverter(typeof(GeojsonObjectJsonConverter))]
    public abstract class GeojsonObject
    {
    }

    public class GeojsonObjectJsonConverter : JsonConverter<GeojsonObject>
    {
        public override GeojsonObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("type").GetString();

            switch (tagValue)
            {
                case "Feature":
                    return JsonSerializer.Deserialize<GeojsonObjectFeature>(ref readerCopy, options);
                case "FeatureCollection":
                    return JsonSerializer.Deserialize<GeojsonObjectFeatureCollection>(ref readerCopy, options);
                case "GeometryCollection":
                    return JsonSerializer.Deserialize<GeojsonObjectGeometryCollection>(ref readerCopy, options);
                case "LineString":
                    return JsonSerializer.Deserialize<GeojsonObjectLineString>(ref readerCopy, options);
                case "MultiLineString":
                    return JsonSerializer.Deserialize<GeojsonObjectMultiLineString>(ref readerCopy, options);
                case "MultiPoint":
                    return JsonSerializer.Deserialize<GeojsonObjectMultiPoint>(ref readerCopy, options);
                case "MultiPolygon":
                    return JsonSerializer.Deserialize<GeojsonObjectMultiPolygon>(ref readerCopy, options);
                case "Point":
                    return JsonSerializer.Deserialize<GeojsonObjectPoint>(ref readerCopy, options);
                case "Polygon":
                    return JsonSerializer.Deserialize<GeojsonObjectPolygon>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad Type_ value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, GeojsonObject value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}