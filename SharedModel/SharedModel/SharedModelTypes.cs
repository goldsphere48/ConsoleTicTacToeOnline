using CommandNetLib;

namespace SharedModel
{
    public class SharedModelTypes : TypesRegistry
    {
        public override void RegisterPackets()
        {
            RegisterType<PlayerData>();
        }
    }
}
