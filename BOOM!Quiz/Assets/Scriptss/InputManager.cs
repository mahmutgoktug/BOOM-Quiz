using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject Oyuncu;


    private void Awake()
    {
        Oyuncu = GameObject.Find("Oyuncu");
    }


    void OnMouseDown()
    {
        if (this.transform.position.z > Oyuncu.transform.position.z&&this.transform.position.z<Oyuncu.transform.position.z+2)
        {
            Vector3 mousePos = this.transform.position;
            Oyuncu.GetComponent<OyuncuHareketManager>().HareketEt(mousePos, 0.5f);
        }


        
    }
}
