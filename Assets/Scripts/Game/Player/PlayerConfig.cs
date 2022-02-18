namespace Game.Player
{
    public class PlayerConfig
    {
        public float MoveSpeed { get; set; }

        public PlayerConfig()
        {
            // TODO: config는 json파일로 분리
            MoveSpeed = 5f;
        }
    }
}
