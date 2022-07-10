using Client.UI;

namespace Client.Scenes
{
    class ConsoleScene : IConsoleUIElement
    {
        private readonly List<IConsoleUIElement> _layout;

        public ConsoleScene()
        {
            _layout = new List<IConsoleUIElement>();
        }

        public void AddNode(IConsoleUIElement element)
        {
            _layout.Add(element);
        }

        public void Draw()
        {
            foreach (var element in _layout)
                element.Draw();
        }

        public virtual void Update()
        {

        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }
    }
}
