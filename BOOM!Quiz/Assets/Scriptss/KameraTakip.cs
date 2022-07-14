using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KameraTakip : MonoBehaviour
{
    [SerializeField]
    Transform hedef;

    Vector3 hedefUzaklik;


    public void MenuDon()
    {
        SceneManager.LoadScene(0);
    }


    private void Start()
    {
        hedefUzaklik = transform.position - hedef.position;

    }


    private void LateUpdate()
    {
        if (hedef)
        {
            transform.position = Vector3.Lerp(transform.position, hedef.position + hedefUzaklik, .1f);
        }
    }
}
