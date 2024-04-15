using Api.Presentation.V1.GetShapes;

namespace Api.Converters;

public sealed class ShapeJsonConverter : JsonConverter<IShapeDto>
{
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
                JsonSerializer.Serialize(writer, circleDto);
                break;
            case SquareDto squareDto:
                JsonSerializer.Serialize(writer, squareDto);
                break;
            case RectangleDto rectangleDto:
                JsonSerializer.Serialize(writer, rectangleDto);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), $"Unexpected type {value.GetType()}");
        }
    }
}