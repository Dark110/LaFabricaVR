using UnityEngine;
using UnityEngine.UI;

public class TemporizadorPastel : MonoBehaviour
{
    public Image imagenPastel;
    public float tiempoMaximo = 45f;
    private float tiempoActual;
    public bool timerActivo = true;

    void Start()
    {
        tiempoActual = tiempoMaximo;
    }

    void Update()
    {
        if (!timerActivo) return;

        tiempoActual -= Time.deltaTime;
        tiempoActual = Mathf.Clamp(tiempoActual, 0, tiempoMaximo);

        if (imagenPastel != null)
            imagenPastel.fillAmount = tiempoActual / tiempoMaximo;

        if (tiempoActual <= 0)
        {
            timerActivo = false;
            Debug.Log("�Tiempo agotado!");
            // Aqu� puedes agregar l�gica para finalizar el juego si lo deseas
        }
    }

    public void A�adirTiempo(float segundos)
    {
        tiempoActual += segundos;
        tiempoActual = Mathf.Min(tiempoActual, tiempoMaximo);
    }

    public void QuitarTiempo(float segundos)
    {
        tiempoActual -= segundos;
        tiempoActual = Mathf.Max(0, tiempoActual);
    }
}
