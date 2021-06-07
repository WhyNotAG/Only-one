using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(PlayerManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player1 { get; set; }
    public static PlayerManager Player2 { get; set; }
    public static InventoryManager Inventory1 { get; set; }
    public static InventoryManager Inventory2 { get; set; }
    
    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Player1 = GetComponent<PlayerManager>();
        Inventory1 = GetComponent<InventoryManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player1);
        _startSequence.Add(Inventory1);
        StartCoroutine(StartupManager());
    }


    IEnumerator StartupManager()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;
        
        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;

            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagersStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModules);
                yield return null;
            }
        }

        Debug.Log("All managers started up");
    }
}
