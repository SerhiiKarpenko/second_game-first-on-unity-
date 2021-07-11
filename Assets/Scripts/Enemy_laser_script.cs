using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_laser_script : MonoBehaviour
{
    public int dmg = 1;
    public float speed = 5f;
    public float time_life = 3.0f;
    

    private void Start()
    {
        Destroy(gameObject, time_life);
    }

    private void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


}
