using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GameObject bulletPrefab;

    private GameObject currentWeapon;
    private int bulletCount;
    
    private GameObject droppedWeapon;
    private GameObject droppedBullet;

    private void Start()
    {
        bulletCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropItem();
        }

        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            PickUpWeapon(other.gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            PickUpBullet();
            Destroy(other.gameObject);
        }
    }

    private void PickUpWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            Debug.Log("You already have a weapon!");
            return;
        }

        // Attach the weapon to the player
        weapon.transform.parent = transform;
        weapon.transform.localPosition = Vector3.zero;
        currentWeapon = weapon;
        Debug.Log("Picked up a weapon!");
    }

    private void PickUpBullet()
    {
        bulletCount++;
        Debug.Log("Picked up a bullet! Bullet count: " + bulletCount);
    }

    private void DropItem()
    {
        if (currentWeapon != null)
        {
            // Instantiate a dropped weapon in the scene
            droppedWeapon = Instantiate(currentWeapon, transform.position + transform.forward * 2f, Quaternion.identity);
            droppedWeapon.transform.parent = null;

            Destroy(currentWeapon);
            currentWeapon = null;
            Debug.Log("Dropped the weapon!");
        }
        else if (bulletCount > 0)
        {
            // Instantiate a dropped bullet in the scene
            droppedBullet = Instantiate(bulletPrefab, transform.position + transform.forward * 2f, Quaternion.identity);
            bulletCount--;
            Debug.Log("Dropped a bullet! Bullet count: " + bulletCount);
        }
        else
        {
            Debug.Log("You have nothing to drop!");
        }
    }

    private void UseWeapon()
    {
        if (currentWeapon == null)
        {
            Debug.Log("You don't have a weapon!");
            return;
        }

        if (bulletCount > 0)
        {
            bulletCount--;
            Debug.Log("Used a bullet! Bullet count: " + bulletCount);
        }
        else
        {
            Debug.Log("No bullets left!");
        }
    }
}
