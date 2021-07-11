using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Down_Enemy : MonoBehaviour
{
    
    public float enemy_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * Time.deltaTime * enemy_speed);
        if (transform.position.y <= -5.82f)
        {
            Destroy(gameObject);
            GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
            gameController.EnemyDeath();
            
        }


    }
}
