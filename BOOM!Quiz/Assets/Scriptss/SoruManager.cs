using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class SoruManager : MonoBehaviour
{
    [SerializeField]
    List<soruItem> sorularList;

    [SerializeField]
    TMP_Text soruTxt;


    [SerializeField]
    GameObject cevapPrefab;

    [SerializeField]
    Transform cevapContainer;

    public string dogruSecenek;


    int kacinciSoru;

    private void Start()
    {
        sorularList = sorularList.OrderBy(i => Random.value).ToList();
        SorulariYazdir();
    }


    void SorulariYazdir()
    {
        soruTxt.text = sorularList[kacinciSoru].soru;

        soruTxt.GetComponent<CanvasGroup>().alpha = 0f;
        soruTxt.GetComponent<RectTransform>().localScale = Vector3.zero;
        CevaplariOlustur();
    }


    void CevaplariOlustur()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject cevapObje = Instantiate(cevapPrefab);
        }
    }

}
