using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody playerRb;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity += new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * moveSpeed;
    }
}
