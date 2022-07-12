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
        Vector3 mousePos = this.transform.position;
        Oyuncu.GetComponent<OyuncuHareketManager>().HareketEt(mousePos, 0.5f);
    }
}
