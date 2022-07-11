using Client.Scenes;

namespace Client
{
    internal class ThreadPool
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void Start(Action action)
        {
            var task = new Task(action);
            _tasks.Add(task);
            task.Start();
        }

        public void StartLoop(Action action)
        {
            void LoopedTask()
            {
                while (true)
                {
                    action?.Invoke();
                }
            }
            var task = new Task(LoopedTask);
            _tasks.Add(task);
            task.Start();
        }

        public bool IsBusy()
        {
            var s = ConsoleSceneManager.Instance;
            return _tasks.Any(t => !t.IsCompleted);
        }
    }
}
