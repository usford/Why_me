using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Tooltip("Характеристика оружия")]
    [SerializeField]
    public WeaponCharacteristic weaponCharacteristic;

    private int fireDelay = 5;

    private int currentAttackFrame = 0; 

    private Bullet bullet;

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
        
    }

    private void Start()
    {
        fireDelay = (weaponCharacteristic.FireDelay);
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && currentAttackFrame >= fireDelay)
        {
            Shoot();
        }else
        {
            currentAttackFrame++;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                WeaponCharacteristic wc = gameObject.GetComponent<Weapon>().weaponCharacteristic;
                other.GetComponent<Character>().addWeapon = wc;
                other.GetComponent<Character>().ActiveWeapon = wc;
                Destroy(gameObject);
            }
        }
    }

    private void Shoot()
    {
        currentAttackFrame = 0;
        Vector3 position = transform.position;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Direction = newBullet.transform.right * (gameObject.GetComponentInChildren<SpriteRenderer>().flipX ? -1.0f : 1.0f);
    }
}
