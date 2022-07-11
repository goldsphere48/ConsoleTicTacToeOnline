using Client.UI;
using CommandNetLib;
using Packets;

namespace Client.Scenes
{
    class WelcomeScene : ConsoleScene
    {
        public WelcomeScene()
        {
            AddNode(new Label("Welcome to Tic Tac Tor online game!"));
            AddNode(new Label("Available commands:"));
            AddNode(new Label("game - Find opponent and start game"));
            AddNode(new Label("exit - Quit the game"));
        }

        public override void OnEnable()
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "game":
                    ConsoleSceneManager.Instance.ActivateScene<SearchGameScene>();
                    break;
                case "exit":
                    break;
            }
        }
    }
}
