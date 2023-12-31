using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 1000;
    private Rigidbody enemyRb;
    public TMP_Text damageText;
    private bool isImmune = false;
    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            Vector3 relativeVelocity = other.gameObject.GetComponent<Rigidbody>().velocity - enemyRb.velocity;
            float velocityFloat = (Mathf.Abs(relativeVelocity.x) + Mathf.Abs(relativeVelocity.y) + Mathf.Abs(relativeVelocity.z)) / 3;
            float damage = velocityFloat * other.gameObject.GetComponent<Rigidbody>().mass / 10;
            Damage(damage);
        }
    }

    public void Damage(float damageToTake)
    {
        if(!isImmune)
        {
            health -= damageToTake;
            SpawnText(damageToTake);
            isImmune = true;
            StartCoroutine(Immunity());
        }
    }

    void SpawnText(float damageToTake)
    {
    damageText.text = damageToTake.ToString();
    Vector3 spawnPos = transform.position + new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
    Instantiate(damageText, spawnPos, damageText.transform.rotation);

    }

    IEnumerator Immunity()
    {
        yield return new WaitForSeconds(0.5f);
        isImmune = false;
    }
}
