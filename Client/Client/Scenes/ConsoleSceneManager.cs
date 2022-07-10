using Client.UI;

namespace Client.Scenes
{
    class ConsoleSceneManager : IConsoleUIElement
    {
        public static ConsoleSceneManager Instance => _instance ??= new ConsoleSceneManager();

        private readonly Dictionary<Type, ConsoleScene> _scenes = new Dictionary<Type, ConsoleScene>();
        private ConsoleScene _currentScene;
        private static ConsoleSceneManager _instance;

        private ConsoleSceneManager() { }

        public void RegisterScene(ConsoleScene scene)
        {
            var type = scene.GetType();

            if (_scenes.ContainsKey(type))
                throw new InvalidOperationException("Scene already registered");

            _scenes[type] = scene;
        }

        public void ActivateScene<T>()
        {
            if (!_scenes.ContainsKey(typeof(T)))
                throw new InvalidOperationException("Scene is not registered");

            _currentScene?.OnDisable();

            _currentScene = _scenes[typeof(T)];

            _currentScene.OnEnable();
        }

        public void Draw()
        {
            _currentScene.Draw();
        }

        public void Update()
        {
            _currentScene.Update();
        }

        public void StartLoop()
        {
            void UpdateLoop()
            {
                while (true)
                {
                    Draw();
                    Update();
                    Console.Clear();
                }
            }

            var loopTask = new Task(UpdateLoop);
            loopTask.Start();
        }
    }
}
