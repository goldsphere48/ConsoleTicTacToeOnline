namespace CommandNetLib
{
    internal class CommandRegistryFromAttributes : CommandsRegistry
    {
        private readonly object _target;

        public CommandRegistryFromAttributes(object target)
        {
            _target = target;
        }

        public override void RegisterCommands()
        {
            var methods = _target.GetType()
                .GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0)
                .ToList();

            foreach (var methodInfo in methods)
            {
                
            }
        }
    }
}
