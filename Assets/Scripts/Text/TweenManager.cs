using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TweenManager : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] TextMeshProUGUI moneyText, deliveryText;
    [SerializeField] SpriteRenderer player;

    public void PlayerGotPackageSprite(SpriteRenderer sprite)
    {
        sprite.color= Color.white;
    }
    
    public void DeliveryInfoTween(float outcomeNumber)
    {
        if(outcomeNumber == 1) // delivery started
        {
            deliveryText.DOColor(Color.blue, .3f);
            deliveryText.transform.DOPunchScale(new Vector3(.01f, .01f), 1f).SetEase(Ease.InBounce);
        }
        if(outcomeNumber == 2) // delivery fail
        {
            deliveryText.DOColor(Color.red, .1f);
            deliveryText.transform.DOPunchScale(new Vector3(.1f, .1f), 1f).SetEase(Ease.InBounce);
        }
        if(outcomeNumber == 3) // delivery completed
        {
            deliveryText.DOColor(Color.green, .3f);
            deliveryText.transform.DOPunchScale(new Vector3(.01f, .01f), 1f).SetEase(Ease.InBounce);
        }
        StartCoroutine(returnTextToSize(deliveryText));
    }
   public void MoneyTextTween()
    {
        moneyText.transform.DOPunchScale(new Vector3(.1f, .1f), 0.5f).SetEase(Ease.InOutSine);
        StartCoroutine(returnTextToSize(moneyText));        
    }
    private IEnumerator returnTextToSize(TextMeshProUGUI text)
    {              
        yield return new WaitForSeconds(.5f);
        print("maymay");
        text.transform.DOScale(1, 1);
    }
}
