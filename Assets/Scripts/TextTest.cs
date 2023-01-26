using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TextTest : MonoBehaviour
{
  // [SerializeField] Vector3 originalPosition;
    private void Start()
    {
       
    }
    public void GotMoney()
    {
        
        transform.DOPunchScale(new Vector3(.1f, .1f), 0.5f).SetEase(Ease.InOutSine);
   //    StartCoroutine(returnOriginalPosition());
    }
    
}
