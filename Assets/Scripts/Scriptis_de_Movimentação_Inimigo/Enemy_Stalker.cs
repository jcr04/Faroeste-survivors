using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stalker : MonoBehaviour
{

    private Transform playerTransform;

    public float moveSpeed;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        fallowPlayer();    
    }

    private void fallowPlayer()
    {
        if(playerTransform.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
        if (playerTransform == null) return;
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            
        }
        
    }




   
}
