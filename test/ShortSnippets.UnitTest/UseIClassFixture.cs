namespace ShortSnippets.UnitTest;

public class UserServiceTest : IClassFixture<UserDataSource>
{
    private readonly string userId;

    public UserServiceTest(UserDataSource dataSource)
    {
        userId = dataSource.GetUserId(); // here userId is already generated in the UserDataSource class
    }

    [Fact]
    public void Test1() { /*code*/ }

    [Fact]
    public void Test2() { /*code*/ }

    [Fact]
    public void Test3() { /*code*/ }
}

public class UserDataSource
{
    private readonly string userId;

    public UserDataSource()
    {
        userId = Guid.NewGuid().ToString();
    }

    public string GetUserId() => userId;
}
