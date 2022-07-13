using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject soruPaneli;

    [SerializeField]
    GameObject dogruIcon, yanlisIcon;

    public bool soruCevaplansinmi;

    public string dogruCevap;

    SoruManager soruManager;

    private void Awake()
    {
        soruManager = Object.FindObjectOfType<SoruManager>();
    }


    private void Start()
    {
        StartCoroutine(OyunuAcRoutine());
    }



    IEnumerator OyunuAcRoutine()
    {
        yield return new WaitForSeconds(.1f);
        soruPaneli.GetComponent<RectTransform>().DOAnchorPosX(30,1f);

        yield return new WaitForSeconds(1.1f);
        soruManager.SorulariYazdir();

    }



    public void SonucuKontrolEt(string gelenCevap)
    {
        if (gelenCevap == dogruCevap)
        {
            //sonuc dogru ise yapilacak islemler
            DogruIconuAktiflestir();
        }
        else
        {
            //sonuc yanlis ise yapilacak islemler
            YanlisIconuAktiflestir();
        }
    }


    void DogruIconuAktiflestir()
    {
        dogruIcon.GetComponent<CanvasGroup>().DOFade(1, .3f);

        Invoke("DogruIconuPasiflestir", .8f);
    }


    void YanlisIconuAktiflestir()
    {
        yanlisIcon.GetComponent<CanvasGroup>().DOFade(1, .3f);
        Invoke("YanlisIconuPasiflestir", .8f);
    }

    void DogruIconuPasiflestir()
    {
        dogruIcon.GetComponent<CanvasGroup>().DOFade(0, .3f);
    }

    void YanlisIconuPasiflestir()
    {
        yanlisIcon.GetComponent<CanvasGroup>().DOFade(0, .3f);
    }
}
