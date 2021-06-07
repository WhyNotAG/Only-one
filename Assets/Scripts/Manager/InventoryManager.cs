using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagersStatus status { get; private set; }
    private Dictionary<string, int> _ammo;
    private List<string> _guns;
    
    public void Startup()
    {
        Debug.Log("Player manager starting...");

        _ammo = new Dictionary<string, int>();
        _guns = new List<string>();

        status = ManagersStatus.Started;
    }

    public Dictionary<string, int> GetAmmoList()
    {
        return _ammo;
    }

    public List<string> GetGunsList()
    {
        return _guns;
    }

    public void AddGuns(string gunName)
    {
        if (_guns.Contains(gunName))
        {
            return;
        }
        _guns.Add(gunName);
        AddAmmo(gunName);
        
        DisplayGuns();
    }

    public void AddAmmo(string ammoName)
    {
        if (_ammo.ContainsKey(ammoName))
        {
            _ammo[ammoName] += 10;
        }
        else
        {
            _ammo[ammoName] = 10;
        }
        
        DisplayAmmo();
    }

    public void DisplayAmmo()
    {
        string items = "Ammo: ";

        foreach (KeyValuePair<string, int> ammoItem in _ammo)
        {
            items += ammoItem.Key + ": " + ammoItem.Value + " ";
        }

        Debug.Log(items);
    }
    
    public void DisplayGuns()
    {
        string guns = "Guns: ";

        foreach (KeyValuePair<string, int> ammoItem in _ammo)
        {
            guns += ammoItem.Key + ": " + ammoItem.Value + " ";
        }

        Debug.Log(guns);
    }
    
    public int GetItemCount(string itemName)
    {
        if (_ammo.ContainsKey(itemName))
        {
            return _ammo[itemName];
        }
        return 0;
    }

    public bool ContainsGun(string itemName)
    {
        return _guns.Contains(itemName);
    }
}
