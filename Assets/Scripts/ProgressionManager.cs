using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
   [SerializeField] GameObject[] jacques, seventh, eastern, northwest;
    HUDManager hud;
    private bool fivePackages = false, twenty5Packages = false, fiftyPackages = false, hundredPackages = false, two50Packages = false;

    public int packagesDelivered;
    ArcadeMode am;

    private void Start()
    {        
    hud = GetComponent<HUDManager>();
        am = FindObjectOfType<ArcadeMode>();
        packagesDelivered= 0;
    }

    public void IncreaseLevel()
    {
        if(packagesDelivered >= 5) { fivePackages= true; }
        if (packagesDelivered >= 25) { twenty5Packages = true; }
        if(packagesDelivered >= 50) { fiftyPackages= true; }
        if(packagesDelivered >= 100) { hundredPackages= true; }
        if(packagesDelivered >= 250) { two50Packages= true; }
        SpawnMailboxes();
    }
    public void SpawnMailboxes()
    {
        if(fivePackages == true)
        {
            foreach(GameObject i in jacques)
            {
                i.SetActive(true);
                print("they should have activated lol");
            }
            FivePackages();
        }
        if(twenty5Packages == true)
        {
            foreach(GameObject i in seventh)
            {
                i.SetActive(true);
            }
            TwentyFivePackages();
        }
        if(fiftyPackages == true)
        {
            foreach(GameObject i in northwest)
            {
                i.SetActive(true);
            }
            Fiftypackages();
        }
        if(hundredPackages == true)
        {
            foreach(GameObject i in eastern) { i.SetActive(true); }
            HundredPackages();
        }
    }
    public void FivePackages()
    {

    }
    public void TwentyFivePackages()
    {

    }
    public void Fiftypackages()
    {

    }
    public void HundredPackages()
    {

    }
}
