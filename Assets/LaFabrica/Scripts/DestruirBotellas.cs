using UnityEngine;

public class DestruirBotella : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Botella"))
        {
            // Destruir la botella
            Destroy(other.gameObject);
        }
    }
}
