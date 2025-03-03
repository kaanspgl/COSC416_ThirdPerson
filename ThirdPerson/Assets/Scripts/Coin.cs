using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure Player has "Player" tag
        {
            GameManager.instance.AddScore(1); // Increase score
            Destroy(gameObject); // Remove coin from scene
        }
    }
}
