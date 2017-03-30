using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explo : MonoBehaviour {

    public GameObject explo;
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Kubel")
        {
            Instantiate(explo, transform.position, transform.rotation);
            
            Destroy(gameObject,1.0f);
        }
    }
}
