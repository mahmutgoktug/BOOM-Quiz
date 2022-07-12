using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OyuncuHareketManager : MonoBehaviour
{

    bool hareketlimi;

    Vector3 hangiYon;

    Quaternion donusYonu;

    private void Start()
    {
        
    }

    public void HareketEt(Vector3 hedefPos,float gecikmeZamani=0.25f)
    {
        if (hareketlimi)
        {
            StartCoroutine(HareketRoutine(hedefPos, gecikmeZamani));
        }
        
        StartCoroutine(HareketRoutine(hedefPos, gecikmeZamani));
    }

    IEnumerator HareketRoutine(Vector3 hedefPos, float gecikmezamani)
    {
        hareketlimi = true;

        hangiYon = new Vector3(hedefPos.x - transform.position.x, transform.position.y, hedefPos.z - this.transform.position.z);

        donusYonu = Quaternion.LookRotation(hangiYon);

        transform.DORotateQuaternion(donusYonu, .2f);

        yield return new WaitForSeconds(gecikmezamani);

        this.transform.DOMove(hedefPos, gecikmezamani);

        while (Vector3.Distance(hedefPos, this.transform.position) > 0.01f)
        {
            yield return null;
        }
        this.transform.position = hedefPos;


        hareketlimi = false;
    }


}
