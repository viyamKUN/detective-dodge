using System.Collections.Generic;
using System.Linq;

namespace Models.Enemy
{
    public class Wave
    {
        /// <summary>
        /// 웨이브의 몬스터 생성 모양
        /// </summary>
        public string Shape;
        public List<(int id, int count)> Enemies;
        /// <summary>
        /// 몬스터 생성 횟수
        /// </summary>
        public int Times;

        public Wave(object shape, object enemies, object times)
        {
            Shape = shape.ToString();
            Enemies = new List<(int id, int count)>();
            enemies.ToString().Split(',').ToList().ForEach(x =>
            {
                var pair = x.Split(':');
                Enemies.Add((int.Parse(pair[0]), int.Parse(pair[1])));
            });
            Times = (int)times;
        }
    }
}
