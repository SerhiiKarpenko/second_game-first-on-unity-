using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;



public class Player_Controller : MonoBehaviour
{

    public int hp = 3;
    public float player_speed = 10f;
    private Rigidbody2D rd;
    private Vector2 moveVector;

    [SerializeField] private Image Haelth;
    [SerializeField] private Text txt;

    

    bool isDead = false;

    public Transform laser;

    public float bullet_distance_from_our_sheep = 0.2f; //Как далеко должна появиться пуля от нашего самёлта

    //куладун, частота выстрела
    public float time_between_bullets_appearance = 0.3f;

    //счётчик до слеуйдщего выстрела
    private float time_before_next_shoot = 0.0f;


  

    private Sprite playersprite;




    // Start is called before the first frame update
    void Start()
    {
        txt.text = ((int)hp).ToString();
        rd = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        

        Player_Move();
        if (Input.GetKey(KeyCode.Space) && time_before_next_shoot < 0)
        {
            time_before_next_shoot = time_between_bullets_appearance;
            Shoot_Bullet();
        }
        time_before_next_shoot -= Time.deltaTime;
    }

    

    private void Shoot_Bullet()
    {
        float posX = this.transform.position.x + (Mathf.Cos
            ((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -bullet_distance_from_our_sheep);
        float posY = this.transform.position.y + (Mathf.Sin
            ((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -bullet_distance_from_our_sheep);

        Instantiate(laser, new Vector3(posX, posY, 0), this.transform.rotation);

    }

    private void Player_Move()
    {

        if (this.transform.position.x <= -6.78f)
            this.transform.position = new Vector3(-6.78f, this.transform.position.y, 0);
        else if (this.transform.position.x >= 6.78)
            this.transform.position = new Vector3(6.78f, this.transform.position.y, 0);

        if (this.transform.position.y >= 4.258f)
            this.transform.position = new Vector3(this.transform.position.x, 4.258f, 0);
        else if (this.transform.position.y <= -4.04f)
            this.transform.position = new Vector3(this.transform.position.x, -4.04f, 0);

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVector = moveInput.normalized * player_speed;


    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Death_Scene");
        }
        
        if (collision.gameObject.name.Contains("Laser2"))
        {
           
            Enemy_laser_script pp = collision.gameObject.GetComponent("Enemy_laser_script") as Enemy_laser_script;
            hp -= pp.dmg;
            updateHpTExt();
            Destroy(collision.gameObject);
           
        }
        if (hp <= 0)
        {
            isDead = true;
            Destroy(this.gameObject);
            SceneManager.LoadScene("Death_Scene");
        }
    }

    private void updateHpTExt()
    {
        txt.text = ((int)hp).ToString();
    }

    void FixedUpdate()
    {
        rd.MovePosition(rd.position + moveVector * Time.fixedDeltaTime);
    }

   
}


