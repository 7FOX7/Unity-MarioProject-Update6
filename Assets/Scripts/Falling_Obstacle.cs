using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Falling_Obstacle : MonoBehaviour
{

    private float fallDelay = 0.1f;
    private float rotationSpeed = 5f;
    private Quaternion _targetRot; 
    [SerializeField] private Rigidbody2D rb;
    private float destroyDelay = 3.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall()); 
            //Fall(); 
        }
    }
    private IEnumerator Fall()
    //private void Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
        // gameObject.transform.Rotate(0, 0, 90); 
        _targetRot = Quaternion.AngleAxis(90, transform.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, rotationSpeed * Time.deltaTime);
        _targetRot = transform.rotation; 
    }
}
