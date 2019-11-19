using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacter : MonoBehaviour
{
    [Tooltip("Скорость камеры")]
    [SerializeField]
    public float speed;

    public GameObject character;

    private void FixedUpdate()
    {
        transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -10f);
    }
}
