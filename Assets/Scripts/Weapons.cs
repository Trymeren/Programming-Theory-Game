using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private GameObject player;

    private Rigidbody rb;

    private Vector3 positionOffset = new Vector3(1, 1, 1);
    [SerializeField] private float speed;
    [SerializeField] private float abilityForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GoTowardsPlayer();
        CheckForAbility();
    }

    void GoTowardsPlayer()
    {
        rb.AddForce(((player.transform.position + positionOffset) - transform.position) * Time.deltaTime * speed);
    }

    public virtual void CheckForAbility()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((MainCanvas.mousePos - transform.position).normalized * abilityForce, ForceMode.Impulse);
        }
    }

}
