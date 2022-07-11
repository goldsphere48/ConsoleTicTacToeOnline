using Client.Scenes;

namespace Client;

static class Program
{
    public static void Main()
    {
        var threadPool = new ThreadPool();
        var player = new Player();
        using var client = new Client(player);
        threadPool.StartLoop(client.Tick);
        WaitForConnection(client);
        ConsoleSceneManager.Instance.RegisterScene(new WelcomeScene());
        ConsoleSceneManager.Instance.RegisterScene(new SearchGameScene(client.RemoteServer, player));
        ConsoleSceneManager.Instance.RegisterScene(new AcceptGameScene(client.RemoteServer, player));
        ConsoleSceneManager.Instance.ActivateScene<WelcomeScene>();
        while (threadPool.IsBusy())
        {
        }
    }

    public static void WaitForConnection(Client client)
    {
        while (client.RemoteServer == null)
        {
            Console.WriteLine("Trying to connect ... ");
            Thread.Sleep(300);
            Console.Clear();
        }
    }
}