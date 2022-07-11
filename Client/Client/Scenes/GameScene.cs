using Client.UI;
using SharedModel;

namespace Client.Scenes
{
    internal class GameScene : ConsoleScene
    {
        private readonly PlayerType _playerType;

        public GameScene(PlayerType playerType)
        {
            _playerType = playerType;
            AddNode(new Label($"Welcome, you are {playerType.GetSymbol(true)}"));
            AddNode(new MapPresenter());
        }
    }
}
