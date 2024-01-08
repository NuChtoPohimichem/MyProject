using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] int Gun_Player = 0;
    [SerializeField] TMP_Text score;
    [SerializeField] GameObject Win;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Gun_Player + "/3";
        if (Gun_Player == 3) 
        {
            Win.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            Gun_Player += 1;
            Destroy(other.gameObject);
        }
    }


}
