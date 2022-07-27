using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController rubyController = collision.GetComponent<RubyController>();
        if (rubyController!=null)
        {
            if (rubyController.Health<rubyController.maxHealth)
            {
                rubyController.ChangeHealth(1);
                Destroy(gameObject);
            }
            
        }
        
    }
}
