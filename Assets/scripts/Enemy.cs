using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject Scream;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Enemy_object;
    float currentSpeed;
    Rigidbody rb;
    bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        transform.LookAt(player.transform);
        rb.MovePosition(transform.position + transform.forward * currentSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        {
            Move();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scream.SetActive(true);
            Enemy_object.SetActive(false);
            //flashlight.SetActive(false);
        }
    }


}
