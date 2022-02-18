namespace Models.Story
{
    public enum ClueType
    {
        Essential, Base, TMI
    }
    [System.Serializable]
    public class Clue
    {
        public ClueType Type;
        public string Name;
        public string Contents;
        public int Rarity;

        public Clue(object key, object name, object contents, object rarity)
        {
            Name = name.ToString();
            if (key.ToString().Contains("essential"))
            {
                Type = ClueType.Essential;
            }
            else if (key.ToString().Contains("base"))
            {
                Type = ClueType.Base;
            }
            else if (key.ToString().Contains("tmi"))
            {
                Type = ClueType.TMI;
            }
            Contents = contents.ToString();
            Rarity = (int)rarity;
        }
    }
}
