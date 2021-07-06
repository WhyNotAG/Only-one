using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagersStatus status { get; private set; }
    private Dictionary<string, int> _ammo;
    private List<string> _guns;
    [SerializeField] private GameObject weaponSwitch;
    [SerializeField] private WeaponHolder _weaponHolder;
    private string _activeIGun;
    
    public void Startup()
    {
        Debug.Log("Player manager starting...");

        _ammo = new Dictionary<string, int>();
        _guns = new List<string>();
        SelectWeapon(-1);
        _activeIGun = null;
        
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
        SelectWeapon(selectedGun: gunName);
        DisplayGuns();
    }

    public void AddAmmo(string ammoName)
    {
        if (_ammo.ContainsKey(ammoName))
        {
            _ammo[ammoName] += 10;
            if (_ammo[ammoName] > 100)
            {
                _ammo[ammoName] = 100;
            }
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

    public int DicrementItem(string itemName)
    {
        if (_ammo.ContainsKey(itemName) && _ammo[itemName] > 0)
        {
            _ammo[itemName]--;
            Debug.Log(_ammo[itemName]);
            return _ammo[itemName];
        }
        return 0;
    }

    public bool ContainsGun(string itemName)
    {
        return _guns.Contains(itemName);
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            StopAllCoroutines();
            SelectWeapon(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }


        if (_activeIGun != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_weaponHolder.GetWeaponActiveGun().GunType == HandleWeapon.GunTypes.AUTO)
                    StartCoroutine(Shooting());
                else if (DicrementItem(_weaponHolder.GetWeaponActiveGun().Name) > 0)
                    _weaponHolder.Shoot();
            }

            if (Input.GetMouseButtonUp(0))
            {
                StopAllCoroutines();
            }
        }

    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            if (DicrementItem(_weaponHolder.GetWeaponActiveGun().Name) > 0) {
                _weaponHolder.Shoot();
            }
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void SelectWeapon(int weaponId = -1, string selectedGun = null)
    {
        int i = 0;
        
        foreach (Transform weapon in weaponSwitch.transform)
        {
            bool addGun = weapon.GetComponent<HandleWeapon>().Name.Equals(selectedGun);

            if (addGun || i == weaponId && ContainsGun(weapon.GetComponent<HandleWeapon>().Name))
            {
                weapon.gameObject.SetActive(true);
                _weaponHolder.SetWeaponActiveGuns(weapon.gameObject.GetComponent<HandleWeapon>());
                _activeIGun = weapon.gameObject.GetComponent<HandleWeapon>().name;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
