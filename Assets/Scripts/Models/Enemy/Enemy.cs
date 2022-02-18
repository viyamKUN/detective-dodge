using System.Collections.Generic;
using System.Linq;

namespace Models.Enemy
{
    public class Enemy
    {
        public string Name;
        public int HP;
        public float Speed;
        public float Power;
        public float EXPDrops;
        public List<int> ItemDrops;
        public bool ClueDrop;

        public Enemy(object name, object hp, object speed, object power, object expDrops, object clueDrop)
        {
            Name = name.ToString();
            HP = (int)hp;
            Speed = (float)speed;
            Power = (float)power;
            EXPDrops = (float)expDrops;

            // var itemDropsList = from string item in itemDrops.ToString().Split(',').ToList()
            //                     select System.Int32.Parse(item);
            // ItemDrops = itemDropsList.ToList();

            ClueDrop = clueDrop.ToString().Equals("TRUE");
        }
    }
}
