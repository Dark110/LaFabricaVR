using UnityEngine;

public class Pendulo : MonoBehaviour
{
    public float longitud = 2f; // Longitud del péndulo
    public float gravedad = 9.8f; // Aceleración gravitatoria
    public float amortiguacion = 0.99f; // Factor de amortiguación (0.99 para un frenado gradual)
    public float anguloInicial = 45f; // Ángulo inicial en grados

    private float angulo; // Ángulo actual del péndulo (en radianes)
    private float velocidadAngular; // Velocidad angular del péndulo

    void Start()
    {
        // Convertir el ángulo inicial de grados a radianes
        angulo = anguloInicial * Mathf.Deg2Rad;
    }
    void Update()
    {
        // Calcular la aceleración angular
        float aceleracionAngular = -(gravedad / longitud) * Mathf.Sin(angulo);

        // Actualizar la velocidad angular con amortiguación
        velocidadAngular += aceleracionAngular * Time.deltaTime;
        velocidadAngular *= amortiguacion;

        // Actualizar el ángulo
        angulo += velocidadAngular * Time.deltaTime;

        // Calcular la posición de la cápsula
        float x = longitud * Mathf.Sin(angulo);
        float y = -longitud * Mathf.Cos(angulo);

        // Actualizar la posición del objeto
        transform.localPosition = new Vector3(x, y, 0f);
    }
}
