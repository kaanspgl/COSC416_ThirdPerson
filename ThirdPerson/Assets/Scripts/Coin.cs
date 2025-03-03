using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 50f; 

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager.instance.AddScore(1); 
            Destroy(gameObject); 
        }
    }
}
