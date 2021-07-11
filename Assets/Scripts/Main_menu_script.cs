using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class Main_menu_script : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public int selectedskin = 0;
    public GameObject playerskin;

    private void Start()
    {
        sr.sprite = skins[0];
    }

    public void NextOption()
    {

        selectedskin += 1;
        if (selectedskin == skins.Count)
            selectedskin = 0;
        sr.sprite = skins[selectedskin];
        
    }

    public void BackOption()
    {
        selectedskin -= 1;
        if (selectedskin < 0)
            selectedskin = skins.Count - 1;
        sr.sprite = skins[selectedskin];
    }

   public void Play()
   {
        SceneManager.LoadScene("Main_Game_Scene");
   }

   public void Exit()
    {
        Application.Quit();
    }


}
