using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    public int ammoAmount;
    private int maxAmmo = 3;

    [HideInInspector] public bool canShoot = true;
    [HideInInspector] public bool isReloading = false;

    private Vector2 shootDirection = Vector2.left;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        UpdateShootDirection();
        UpdateShootPoint();

        if(ammoAmount == 0 && !isReloading)
        {
            SimulateReload();
        }
    }

    public void UpdateShootDirection()
    {
        if (Input.GetKey(KeyCode.D))
        {
            shootDirection = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            shootDirection = Vector2.left;
        }
    }

    public void UpdateShootPoint()
    {
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void SimulateReload()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        isReloading = true;

        while (ammoAmount < maxAmmo)
        {
            yield return new WaitForSeconds(1);
            ammoAmount++;
            Debug.Log("Reloading 1 ammo");

            if(ammoAmount >= maxAmmo)
            {
                Debug.Log("ReloadComplete");
            }
        }

        isReloading = false;
    }

    public void Shoot()
    {
        if (canShoot && ammoAmount > 0 && !isReloading)
        {
            canShoot = false;
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(0, 0, angle));

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = shootDirection * bulletSpeed + _playerMovement.body.velocity;

            ammoAmount--;
            StartCoroutine(FireCooldown(fireRate));
        }
    }

    private IEnumerator FireCooldown(float shootCooldown)
    {
        yield return new WaitForSeconds(shootCooldown);

        canShoot = true;
    }
}
