namespace Models.Story
{
    [System.Serializable]
    public class Requirements
    {
        public int ID;
        public string[] ClueList;
    }

    [System.Serializable]
    public class RequirementsList
    {
        public Requirements[] Requires;
    }
}
