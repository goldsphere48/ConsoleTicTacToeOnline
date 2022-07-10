using Client.Scenes;

namespace Client;

static class Program
{
    public static void Main()
    {
        var player = new Player();
        using var client = new Client(player);
        client.StartListening();
        WaitForConnection(client);
        ConsoleSceneManager.Instance.RegisterScene(new WelcomeScene());
        ConsoleSceneManager.Instance.RegisterScene(new SearchGameScene(client.RemoteServer, player));
        ConsoleSceneManager.Instance.RegisterScene(new AcceptGameScene(client.RemoteServer));
        ConsoleSceneManager.Instance.ActivateScene<WelcomeScene>();
        ConsoleSceneManager.Instance.StartLoop();
        while (true)
        {
        }
    }

    public static void WaitForConnection(Client client)
    {
        while (client.RemoteServer == null)
        {
            
        }
    }
}