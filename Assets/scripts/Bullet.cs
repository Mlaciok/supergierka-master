using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject targetZombie;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == targetZombie)
        {
            // znisz go
            Destroy(targetZombie);

            //zniszcz KULE
            Destroy(gameObject);
        }
    }
}
