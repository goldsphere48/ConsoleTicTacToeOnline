namespace Client.UI
{
    class Label : IConsoleUIElement
    {
        public string Text;

        public Label(string text)
        {
            Text = text;
        }

        public void Draw()
        {
            Console.WriteLine(Text);
        }
    }
}
