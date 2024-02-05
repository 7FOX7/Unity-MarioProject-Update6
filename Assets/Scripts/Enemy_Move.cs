using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public float enemySpeed = 4f;
    // moveX takes participation in all cases (whenever we rotate the object or want it to take participaiton in speed calculation) 
    private int moveX; 
    
    // Update is called once per frame
    void Update()
    {
        EnemyReycast(); 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, 0) * enemySpeed;
    }

    void EnemyReycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveX, 0));
        if (hit.distance < 0.8f)
        {
            Flip();
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
    void Flip()
    {
        if(moveX > 0)
        {
            moveX = -1; 
        }
        else
        {
            moveX = 1; 
        }
    }
}
