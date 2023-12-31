using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private bool isImmune = false;
    public float health;

    private Rigidbody playerRb;
    [SerializeField] private float moveSpeed;
    private GameObject weapon;

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        weapon = GameObject.FindWithTag("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity += new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * moveSpeed;
    }

    IEnumerator Immunity()
    {
        yield return new WaitForSeconds(0.5f);
        isImmune = false;
    }

    public void Damaged(float damage)
    {
        if(!isImmune)
        {
            health -= damage;
            isImmune = true;
            StartCoroutine(Immunity());
        }
    }
}
