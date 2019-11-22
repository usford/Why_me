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
    public WeaponCharacteristic activeWeapon;

    public WeaponCharacteristic ActiveWeapon
    {
        set
        {
            activeWeapon = value;
            TakeGun();
        }
    }



    [Tooltip("Оружия")]
    [SerializeField]
    public List<WeaponCharacteristic> weapons;

    public WeaponCharacteristic addWeapon
    {
        set
        {
            weapons.Add(value);
        }
    }

    SpriteRenderer spriteCharacter;
    SpriteRenderer spriteWeapon;

    //Объект с оружием
    private GameObject gun;

    //Стрельба
    private Bullet bullet;

    public float offset;

    //Смена оружия
    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9
    };
    

    private void Awake()
    {
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");

        //Первоначальное отображение оружия
        if (activeWeapon != null)
        {
            TakeGun();
        }
    }

    private void TakeGun()
    {
        if (activeWeapon != null) Destroy(gun);
        //GameObject go = new GameObject();
        //go.AddComponent<SpriteRenderer>();
        //go.GetComponent<SpriteRenderer>().sprite = activeWeapon.SpriteWeapon;
        //go.name = activeWeapon.NameWeapon;

        GameObject go = Resources.Load<GameObject>(activeWeapon.NameWeapon);

        gun = Instantiate(go, new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.25f, -2f), go.transform.rotation);

        //Destroy(go);

        gun.transform.SetParent(gameObject.transform);
        spriteWeapon = gun.GetComponentInChildren<SpriteRenderer>();
        spriteWeapon.flipX = spriteCharacter.flipX;

        //gun.AddComponent<Weapon>();
        //gun.GetComponent<Weapon>().weaponCharacteristic = activeWeapon;
    }

    private void ChangeGun(int index)
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    int index = weapons.IndexOf(activeWeapon);
        //    int lastIndex = weapons.Count - 1;


        //    if (index + 1 > lastIndex)
        //    {
        //        index = 0;
        //    }else
        //    {
        //        index++;
        //    }
        //    ActiveWeapon = weapons[index];
        //}     

        if (index > weapons.Count - 1) return;
        ActiveWeapon = weapons[index];
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        float rotateZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, -rotateZ + offset + 90f);
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButton("Vertical")) UpDown();
        
        //if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)))  
        //{
           
        //    //ChangeGun();
        //}

        //Проверка на нажатие цифры
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                ChangeGun(i);
            }
        }
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

    
}
