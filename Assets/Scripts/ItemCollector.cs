using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public GameObject popup;
    private Animator anim;
    private int items = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            
            items++;
            popup.SetActive(true);
            //Text();
            
        }
    }
    /**
    private void Text()
    {
        anim.SetTrigger("collect");
    }
    */

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item")) 
        {
            popup.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    
}
