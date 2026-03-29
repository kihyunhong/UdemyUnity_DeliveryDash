using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;
    [SerializeField] private float destroyDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package Picked Up");
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
        }
    }
}
