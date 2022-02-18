namespace Game.Player
{
    public class PlayerConfig
    {
        public float MoveSpeed { get; }
        public int MaxHP { get; }
        public float EXP { get; }

        public PlayerConfig()
        {
            // TODO: config는 json파일로 분리
            MoveSpeed = 5f;
            MaxHP = 100;
            EXP = DefaultSystem.PlayerSaveData.GetPlayer.EXP;
        }
    }
}
