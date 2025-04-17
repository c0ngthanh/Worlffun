using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttribute : CSVData
{
    public float Money;
    public float Experience;
    public int currentLevel;

    // public PlayerAttribute(int id, string name, int health, int money, int experience, int currentLevel, int damage)
    //     : base(id, name, health, health, damage)
    // {
    //     Money = money;
    //     Experience = experience;
    //     this.currentLevel = currentLevel;
    // }
    // public PlayerAttribute()
    // {
    //     ID = 1;
    //     Name = "Default";
    //     Health = 100;
    //     MaxHealth = 100;
    //     Money = 0;
    //     Experience = 0;
    //     currentLevel = 1;
    //     Damage = 10;
    // }
}
