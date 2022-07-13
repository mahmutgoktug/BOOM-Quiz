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

    [SerializeField]
    GameObject oyuncuPrefab;

    [SerializeField]
    GameObject robot_1, robot_2, robot_3;

    public bool soruCevaplansinmi;

    public string dogruCevap;


    int kalanHak;

    SoruManager soruManager;


    OyuncuHareketManager oyuncuHareketManager;


    private void Awake()
    {
        oyuncuHareketManager = Object.FindObjectOfType<OyuncuHareketManager>();
        soruManager = Object.FindObjectOfType<SoruManager>();
    }


    private void Start()
    {
        kalanHak = 3;

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
            StartCoroutine(OyuncuHataYaptiGeriGeldi());
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

    IEnumerator OyuncuHataYaptiGeriGeldi()
    {
        yield return new WaitForSeconds(1f);

        oyuncuHareketManager.OyuncuHataYapti();

        yield return new WaitForSeconds(1.4f);

        kalanHak--;

        HakKaybet();
        if (kalanHak > 0)
        {
            oyuncuHareketManager.OyuncuGeriGelsin();

            yield return new WaitForSeconds(1f);
            soruManager.SorulariYazdir();
        }
        else
        {
            //oyun bitti
            print("oyun bitti");
        }

        
    }



    void HakKaybet()
    {
        if (kalanHak == 2)
        {
            robot_3.SetActive(false);
            robot_2.SetActive(true);
            robot_1.SetActive(true);
        }
        else if(kalanHak==1)
        {
            robot_3.SetActive(false);
            robot_2.SetActive(false);
            robot_1.SetActive(true);
        }
        else if (kalanHak == 0)
        {
            robot_3.SetActive(false);
            robot_2.SetActive(false);
            robot_1.SetActive(false);
        }
    }



}
