using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemy;
   

    public int enemies_per_wave = 5;
    public int current_number_enemy = 0;

    public float time_before_spawning = 1.5f;
    public float time_between_enemies_spawning = 0.25f;
    public float time_before_enemies_wawes = 2.0f;

    public float time_between_enemies_position = 0.15f;

    
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(time_before_spawning);
        while(true)
        {
            if (current_number_enemy <= 0)
            {
                float posX;
                float posY;
                

                for (int i = 0; i < 5; i++)
                {
                    posX = Random.Range(-6.84f, 6.84f);
                    posY = Random.Range(7.1f, 9.63f);
                    
                    //yield return new WaitForSeconds(time_between_enemies_position);

                    Instantiate(enemy, new Vector3(posX, posY, 0), this.transform.rotation);
                    current_number_enemy++;

                    yield return new WaitForSeconds(time_between_enemies_spawning);

                }
            }
            yield return new WaitForSeconds(time_before_enemies_wawes);

        }
    }

   



    public void EnemyDeath()
    {
        current_number_enemy--;
    }
}
