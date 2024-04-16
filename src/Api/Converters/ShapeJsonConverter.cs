using Api.Presentation.V1.GetShapes;

namespace Api.Converters;

public sealed class ShapeJsonConverter : JsonConverter<IShapeDto>
{
    private static readonly JsonSerializerOptions CamelCaseOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(IShapeDto).IsAssignableFrom(typeToConvert);
    }
    
    public override IShapeDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IShapeDto value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case CircleDto circleDto:
                JsonSerializer.Serialize(writer, circleDto, CamelCaseOptions);
                break;
            case SquareDto squareDto:
                JsonSerializer.Serialize(writer, squareDto, CamelCaseOptions);
                break;
            case RectangleDto rectangleDto:
                JsonSerializer.Serialize(writer, rectangleDto, CamelCaseOptions);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), $"Unexpected type {value.GetType()}");
        }
    }
}