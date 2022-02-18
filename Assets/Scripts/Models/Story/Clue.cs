namespace Models.Story
{
    [System.Serializable]
    public class Clue
    {
        public string Name;
        public string Contents;
        public int Rarity;

        public Clue(object name, object contents, object rarity)
        {
            Name = name.ToString();
            Contents = contents.ToString();
            Rarity = (int)rarity;
        }
    }
}
