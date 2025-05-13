using UnityEngine;

public class DestruirBotella : MonoBehaviour
{
    public float tiempoAEliminar = 5f; // Tiempo a quitar cuando se destruye una botella
    public float tiempoAA�adir = 0f;  // Tiempo a a�adir si es necesario (puedes configurarlo)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Botella"))
        {
            // Notificar al script de interacci�n que la botella ser� destruida
            InteractuarConObjeto interactor = FindObjectOfType<InteractuarConObjeto>();
            if (interactor != null)
            {
                interactor.ForzarSoltarSiEs(other.gameObject);
            }

            // Interactuar con el temporizador
            TemporizadorPastel temporizador = FindObjectOfType<TemporizadorPastel>();
            if (temporizador != null)
            {
                if (tiempoAEliminar > 0)
                {
                    temporizador.QuitarTiempo(tiempoAEliminar);
                }

                if (tiempoAA�adir > 0)
                {
                    temporizador.A�adirTiempo(tiempoAA�adir);
                }
            }
            else
            {
                Debug.LogWarning("No se encontr� un componente TemporizadorPastel en la escena.");
            }

            // Destruir la botella
            Destroy(other.gameObject);
        }
    }
}
