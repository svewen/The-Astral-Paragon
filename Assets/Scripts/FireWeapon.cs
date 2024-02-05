using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Animator anim;
    public ParticleSystem ps;
    public Transform orientation;

    private bool canFire = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire)
        {
            Fire();
        }

    }

    private GameObject enemy;
    private void Fire()
    {
        canFire = false;

        // play animation and muzzle flash
        anim.SetBool("fireGun", true);
        ps.Play();

        // cooldown for half a sec
        Invoke("ResetFire", 0.5f);

        // shoot out raycast
        Ray ray = new Ray(new Vector3(orientation.position.x, orientation.position.y + 0.5f, orientation.position.z), orientation.forward);
        RaycastHit hit;

        // if raycast hits an enemy, kill
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                enemy = hit.collider.gameObject;
                enemy.GetComponent<EnemyController>().TakeDamage();
            }
        }
    }

    private void ResetFire()
    {
        anim.SetBool("fireGun", false);
        canFire = true;
    }
}
