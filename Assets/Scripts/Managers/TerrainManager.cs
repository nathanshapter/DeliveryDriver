using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] private LayerMask grass, dirt, road;
    private void Awake()
    {
        grass = LayerMask.NameToLayer("grass");
        dirt = LayerMask.NameToLayer("dirt");
        road = LayerMask.NameToLayer("Road");
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        print(player.name);
    }
}
