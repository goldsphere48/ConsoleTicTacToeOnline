namespace Server
{
    class Room
    {
        private readonly Player _firstPlayer;
        private readonly Player _secondPlayer;

        public Room(Player firstPlayer, Player secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }
    }
}
