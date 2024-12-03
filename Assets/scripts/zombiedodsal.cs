using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiedodsal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pocisk"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
