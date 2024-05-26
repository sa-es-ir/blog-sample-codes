using Microsoft.Extensions.Options;

namespace ShortSnippets;

public class SampleService
{
    private readonly IOptions<SampleOptions> options;

    public SampleService(IOptions<SampleOptions> options)
    {
        this.options = options;
    }

    public string? GetMessage()
    {
        return options.Value.Message;
    }
}

public class SampleOptions
{
    public string? Message { get; set; }
}
