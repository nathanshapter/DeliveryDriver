using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawn : MonoBehaviour
{
    [SerializeField] Transform[] packageSpawn;
    [SerializeField] GameObject package;
    [SerializeField] Driver driver;
    //todo add vfx
    
    private void Start()
    {
        GetComponentsInChildren<PackageSpawn>();
        SpawnAPackage();      
         
    }

    public void SpawnAPackage()
    {
        Instantiate(package, packageSpawn[Random.Range(0, packageSpawn.Length )]);
    }
   
}
