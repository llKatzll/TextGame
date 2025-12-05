using System;

namespace TextGame
{
    internal class Player
    {
        // 기본 정보
        public string Gender { get; set; } = "";
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;

        // 도덕 수치
        public int Karma { get; set; } = 0;
        public int Divine { get; set; } = 0;

        // 스탯
        public int Level { get; set; } = 1;
        public float CurrentHp { get; private set; } = 100;
        public float MaxHp { get; private set; } = 100;
        public float Atk { get; set; } = 3;
        public float DefChance { get; set; } = 50;
        public float DgdChance { get; set; } = 30;

        // 장비
        public Equipment Equip { get; } = new Equipment();

        public bool IsDead => CurrentHp <= 0;

        public void TakeDamage(float damage)
        {
            CurrentHp -= damage;
            if (CurrentHp < 0)
                CurrentHp = 0;
        }

        public void Heal(float heal)
        {
            CurrentHp += heal;
            if (CurrentHp > MaxHp)
                CurrentHp = MaxHp;
        }
    }
}
