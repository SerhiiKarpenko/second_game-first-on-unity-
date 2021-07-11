using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_script : MonoBehaviour
{
    // Start is called before the first frame update
    public float bullet_speed = 20f;
    public float time_life = 2.0f;
    public int damage = 1;

   

    void Start()
    {
        Destroy(gameObject, time_life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bullet_speed);
    }


}
