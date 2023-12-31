using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStaff : Weapons
{
    [SerializeField] private GameObject projectile;
    public override void CheckForAbility()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 offset = transform.position - GameObject.Find("Player").transform.position;
            Vector3 positionToSpawn = new Vector3((transform.position + offset.normalized).x, 1, (transform.position + offset.normalized).z);
            GameObject clone = Instantiate(projectile, positionToSpawn, projectile.transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
        }
    }
}
