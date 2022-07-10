namespace Sandbox;

static class Program
{
    public static void Main()
    {
        var server = new Server();
        
        while (true)
        {
            server.Tick();
            Thread.Sleep(100);
        }
    }
}