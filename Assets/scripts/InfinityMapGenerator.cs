using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
    public GameObject backgroundPrefab; //tlo mapy
    public Transform player; // referencja do gracza
    public float backgroundWidth = 10f; // szerokosc jednego kafla tla
    public float backgroundHeight = 10f;
    public int preloadAmount = 3; // liczba sekcji w przod (zeby unikac pustych miejsc xD)

    private Queue<GameObject> activeBackgrounds = new Queue<GameObject>();
    private Vector2 lastPosition;


    void Start()
    {
        // generuj pocztakowe sekcje mapy
        for (int i = 0; i < preloadAmount; i++)
        {
            Vector3 spawnPosition = new Vector3(i * backgroundWidth, i * backgroundHeight, 0);
            GameObject background = Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
            activeBackgrounds.Enqueue(background);
            lastPosition = spawnPosition;

        }
    }

    void Update()
    {
        // sprawdz, czy gracz zbliza sie do konca aktywnej mapy :3
        float playerXPosition = player.position.x;
        float playerYPosition = player.position.y;

        if (Mathf.Abs(playerXPosition - lastPosition.x) < backgroundWidth ||
            Mathf.Abs(playerYPosition - lastPosition.y) >= backgroundHeight)
        {
            SpawnNextBackground();
        }
    }

    void SpawnNextBackground()
    {
        // tworz nowy kafelek 
        Vector3 spawnPosition = new Vector3(lastPosition.x + backgroundWidth, lastPosition.y + backgroundHeight, 0);
        GameObject background = Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
        activeBackgrounds.Enqueue(background);


        lastPosition += new Vector2(backgroundWidth, backgroundHeight);

        // opcjonalne usun stary kacefel aby zwolnic pamiec :3
        if (activeBackgrounds.Count > preloadAmount)
        {
            GameObject oldBackground = activeBackgrounds.Dequeue();
            Destroy(oldBackground);
        }
    }
}