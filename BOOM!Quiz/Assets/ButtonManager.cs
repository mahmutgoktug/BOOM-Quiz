using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public float timer;
    public bool active;
    



    private void Start()
    {
        
    }
    private void Update()
    {
        if (active == true)
        {
            timer -= Time.deltaTime;
            
        }


        if (timer < 0)
        {
            
            SceneManager.LoadScene(1);

        }

    }

    public void Baslat()
    {
        active = true;
    }

    public void cikis()
    {
        Application.Quit();
    }
}
