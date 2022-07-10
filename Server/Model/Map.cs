namespace Model
{
    internal class Map
    {
        private byte[] _data = new byte[9];

        public void MarkCell(int x, int y, byte type)
        {
            _data[y * 3 + x] = type;
        }
    }
}
