using FluentAssertions;
using Microsoft.Extensions.Options;

namespace ShortSnippets.UnitTest
{
    public class SampleServiceTest
    {
        [Fact]
        public void CallGetMessageMethod()
        {
            IOptions<SampleOptions> options = Options.Create(new SampleOptions
            {
                Message = "Hello, World!"
            });

            var service = new SampleService(options);

            var message = service.GetMessage();

            message.Should().NotBeNull();
            message.Should().Be("Hello, World!");
        }
    }
}