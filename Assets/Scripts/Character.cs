using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Tooltip("Скорость персонажа")]
    [SerializeField]
    public float speed;

    [Tooltip("Активное оружие")]
    [SerializeField]
    public Weapon activeWeapon;

    SpriteRenderer spriteCharacter;
    SpriteRenderer spriteWeapon;

    //Объект с оружием
    private GameObject gun;

    //Стрельба
    private Bullet bullet;
    

    private void Awake()
    {
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");

        //Первоначальное отображение оружия
        if (activeWeapon != null)
        {
            GameObject go = new GameObject();
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<SpriteRenderer>().sprite = activeWeapon.SpriteWeapon;
            go.name = activeWeapon.NameWeapon;

            gun = Instantiate(go, new Vector3(0.1f, -0.25f, -2f), go.transform.rotation);
            Destroy(go);
            gun.transform.SetParent(gameObject.transform);
            spriteWeapon = gun.GetComponentInChildren<SpriteRenderer>();
            spriteWeapon.flipX = spriteCharacter.flipX; 
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButton("Vertical")) UpDown();
        if (Input.GetButton("Fire1")) Shoot();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * (Input.GetButton("Fire3") ? speed * 2f : speed));

        spriteCharacter.flipX = direction.x < 0.0f;
        spriteWeapon.flipX = spriteCharacter.flipX;

        
    }

    private void UpDown()
    {
        Vector3 direction = transform.up * Input.GetAxis("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * (Input.GetButton("Fire3") ? speed * 2f : speed));
    }

    private void Shoot()
    {
        Vector3 position = transform.position;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Direction = newBullet.transform.right * (spriteCharacter.flipX ? -1.0f : 1.0f);
    }
}
