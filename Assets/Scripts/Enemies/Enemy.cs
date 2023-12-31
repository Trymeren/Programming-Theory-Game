using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody enemyRb;
    public TMP_Text damageText;
    private bool isImmune = false;
    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Move();
        CheckForDeath();
    }

    protected void CheckForDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
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

        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().Damaged(damage);
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
        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-1,1), 3, Random.Range(-1,1));
        Instantiate(damageText, spawnPos, damageText.transform.rotation);

    }

    IEnumerator Immunity()
    {
        yield return new WaitForSeconds(0.5f);
        isImmune = false;
    }

    virtual protected void Move()
    {
        Vector3 relativePos = GameObject.Find("Player").transform.position - transform.position;
        enemyRb.AddForce(relativePos.normalized * speed * Time.deltaTime);
    }
}
