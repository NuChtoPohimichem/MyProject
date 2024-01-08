using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject Scream;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Enemy_object;
    [SerializeField] GameObject Game_over;
    float currentSpeed;
    Rigidbody rb;
    bool isGameOver = false;
    [SerializeField] AudioSource ScreamSounds;
    [SerializeField] AudioClip Scream_AC;


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

    void Scream_menu()
    {
        Game_over.SetActive(true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scream.SetActive(true);
            Enemy_object.SetActive(false);
            ScreamSounds.Play();
            Invoke("Scream_menu", 0.9f);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }



}
