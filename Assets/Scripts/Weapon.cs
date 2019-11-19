using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName ="Scriptable Object/New weapon")]
public class Weapon : ScriptableObject
{
    [Tooltip("Название оружия")]
    [SerializeField]
    private string nameWeapon;

    [Tooltip("Картинка оружия")]
    [SerializeField]
    private Sprite spriteWeapon;

    [Tooltip("Урон")]
    [SerializeField]
    private int damage;

    public string NameWeapon
    {
        get
        {
            return nameWeapon;
        }
        set
        {
            nameWeapon = value;
        }
    }

    public Sprite SpriteWeapon
    {
        get
        {
            return spriteWeapon;
        }
        set
        {
            spriteWeapon = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
}
