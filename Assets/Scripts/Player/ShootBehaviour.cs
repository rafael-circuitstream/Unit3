using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectPool bulletsPool;
    [SerializeField] private List<WeaponData> inventory = new List<WeaponData>();
    [SerializeField] private WeaponData equippedWeapon;

    [Header("Shooting Settings")]
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Camera myCamera;

    private int currentIndex;
    private void Start()
    {
        ChangeWeapon(0);
    }
    public void ShootWeapon()
    {
        PooledObject pooledObj = bulletsPool.RetrievePoolObject();
        Rigidbody projectileClone = pooledObj.GetRigidbody();
        projectileClone.position = weaponTip.position;
        projectileClone.rotation = weaponTip.rotation;
        projectileClone.AddForce(myCamera.transform.forward * equippedWeapon.GetBulletSpeed(), ForceMode.Impulse);
        //setting damage on a possible bullet script
        //start cooldown here with a timer maybe, from the fire rate in the equipped weapon

        pooledObj.ResetPooledObject(4f);
    }
    
    public void ChangeWeapon(int index)
    {
        currentIndex = (currentIndex + index) % inventory.Count;

        equippedWeapon = inventory[currentIndex];
        Debug.Log("My weapon is now " + equippedWeapon.WeaponName);
    }
}
