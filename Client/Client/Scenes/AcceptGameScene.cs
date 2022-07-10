using Client.UI;
using CommandNetLib;

namespace Client.Scenes
{
    internal class AcceptGameScene : ConsoleScene
    {
        private readonly RemoteServer _server;

        public AcceptGameScene(RemoteServer server)
        {
            _server = server;
            AddNode(new Label("Accept game ? (y/n)"));
        }

        public override void Update()
        {
            string answer = "";
            do
            {
                answer = Console.ReadLine();
            } while (answer == "y" || answer == "n");

            switch (answer)
            {
                case "y":

                    break;
                case "n":

                    break;
            }
        }
    }
}
