using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController rubyController = collision.GetComponent<RubyController>();

        if (rubyController!=null)
        {
            rubyController.ChangeHealth(-1);
        }
       
    }
}
