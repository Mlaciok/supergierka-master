using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzamy, czy obiekt, z którym nast¹pi³a kolizja, ma okreœlon¹ nazwê
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Kolizja z drugim obiektem!");
            // Tutaj mo¿esz dodaæ dodatkow¹ logikê, np. odejmowanie punktów, zniszczenie obiektu, itp.
        }
    }

}
