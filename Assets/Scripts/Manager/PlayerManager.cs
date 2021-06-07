using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    private const int MAX_ARMOR = 150; 
    private const int MAX_HEALTH = 120; 
    public ManagersStatus status { get; private set; }
    
    [SerializeField] private int _health { get; set; }
    [SerializeField] private int _armor { get; set; }
    
    
    public void Startup()
    {
        Debug.Log("Player manager starting...");
        _health = 100;
        _armor = 100;
        status = ManagersStatus.Started;
    }
}
