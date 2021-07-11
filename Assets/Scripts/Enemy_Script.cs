using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public int health = 2;

    public Transform enemy_laser;
    public float how_far_from_enemy = 0.5f;
    public float time_before_next_shoot = 2.0f;
    public float time_between_shoots = 6.0f;


    // Start is called before the first frame update


    private void Start()
    {
        StartCoroutine(shootbullet());
    }

    private void Update()
    {
        if(enemy_laser.transform.position.y <= -6.02f)
        {
            Destroy(enemy_laser);
        }
    }

    IEnumerator shootbullet()
    {
        yield return new WaitForSeconds(time_before_next_shoot);
        while(true)
        {
            float posX = this.transform.position.x + (Mathf.Cos
              ((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -how_far_from_enemy);
            float posY = this.transform.position.y + (Mathf.Sin
                ((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) + -1);

            Instantiate(enemy_laser, new Vector3(posX, posY, 0), this.transform.rotation);
          yield return new WaitForSecondsRealtime(6);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("laser"))
        {
            //Debug.Log("Collision");
            laser_script laser = collision.gameObject.GetComponent("laser_script") as laser_script;
            health -= laser.damage;
            Destroy(collision.gameObject);
        }

        if (health <= 0)
        {

            Destroy(this.gameObject);
            GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
            gameController.EnemyDeath();
        }
    }

    
}
