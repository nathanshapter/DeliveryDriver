using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawn : MonoBehaviour
{
    [SerializeField] Transform[] packageSpawn;
    [SerializeField] GameObject package;
    [SerializeField] Driver driver;
    //todo add vfx

    public bool packageSpawned;
    
    private void Start()
    {
       packageSpawned= false;
        GetComponentsInChildren<PackageSpawn>();
        SpawnAPackage();
       
    }

    public void SpawnAPackage()
    {
        if(!packageSpawned) { Instantiate(package, packageSpawn[Random.Range(0, packageSpawn.Length)]); }
        

        packageSpawned= true;

    }
   
}
