using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName ="Scriptable Object/New weapon")]
public class WeaponCharacteristic : ScriptableObject
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

    [Tooltip("Скорострельность")]
    [SerializeField]
    private int fireDelay;



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

    public int FireDelay
    {
        get
        {
            return fireDelay;
        }
        set
        {
            fireDelay = value;
        }
    }
}
