using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzamy, czy obiekt, z kt�rym nast�pi�a kolizja, ma okre�lon� nazw�
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Kolizja z drugim obiektem!");
            // Tutaj mo�esz doda� dodatkow� logik�, np. odejmowanie punkt�w, zniszczenie obiektu, itp.
        }
    }

}
