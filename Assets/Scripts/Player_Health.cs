using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // use 'SceneManagement' for version 2



// Version 1 and Version 2: 
//public class Player_Health : MonoBehaviour
//{
//    private int health;
//    private bool hasDied;
//    public float dieDelay = 2.0f;
//    // Start is called before the first frame update
//    void Start()
//    {
//        hasDied = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Version 1 (call 'Check' from Update):
//        // Check(); 

//        // Version 2 (create 'if' statements):
//        if (gameObject.transform.position.y <= -6)
//        {
//            hasDied = true;
//        }
//        if (hasDied == true)
//        {
//            StartCoroutine(Die());
//        }
//    }

//    // Version 1 (use 'Check' method): 

//    //private void Check()
//    //{
//    //    if (gameObject.transform.position.y <= -6)
//    //    {
//    //        //Debug.Log("Player has died"); 
//    //        hasDied = true;
//    //    }
//    //    if (hasDied == true)
//    //    {
//    //        StartCoroutine(Die());
//    //    }
//    //}

//    // Version 1 of how we can handle when the player falls and dies (by using 'Check' method): 
//    //IEnumerator Die()
//    //{
//    //    Debug.Log("Player has fallen");
//    //    yield return new WaitForSeconds(dieDelay);
//    //    Debug.Log("Player has died"); 
//    //}


//    // Version 2 of how we can handle when the player falls and dies (we simply come back to the beginning) 
//    IEnumerator Die()
//    {
//        SceneManager.LoadScene("SampleScene");
//        gameObject.transform.position = new Vector3(0, 0, 0);
//        yield return null;
//    }
//}

// Version 3: 
public class Player_Health : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if (gameObject.transform.position.y <= -6)
        {
            Die(); 
        }
    }

    void Die()
    {
        SceneManager.LoadScene("SampleScene");
        gameObject.transform.position = Vector3.zero; 
    }
}