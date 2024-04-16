namespace Tests.Helpers;

public static class FluentAssertionsExtensions
{
    public static AndConstraint<StringAssertions> BeValidCamelCaseJson<T>(
        this StringAssertions stringAssertions,
        Expression<Func<T, bool>>? expression = null,
        string because = "",
        params object[] becauseArgs)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return stringAssertions.BeValidJson(expression, options, because, becauseArgs);
    }
    
    private static AndConstraint<StringAssertions> BeValidJson<T>(
        this StringAssertions stringAssertions,
        Expression<Func<T, bool>>? expression = null,
        JsonSerializerOptions? options = null,
        string because = "",
        params object[] becauseArgs)
    {
        try
        {
            var obj = JsonSerializer.Deserialize<T>(stringAssertions.Subject, options);
            obj.Should().NotBeNull().And.Match(expression ?? (_ => true));
        }
        catch (Exception ex)
        {
            Execute.Assertion.BecauseOf(because, becauseArgs)
                .FailWith("Expected json to be valid camel case, but parsing failed with {0}.", ex.Message);
        }

        return new AndConstraint<StringAssertions>(stringAssertions);
    }
}