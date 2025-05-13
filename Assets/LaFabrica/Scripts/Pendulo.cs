using UnityEngine;

public class Pendulo : MonoBehaviour
{
    public float longitud = 2f; // Longitud del p�ndulo
    public float gravedad = 9.8f; // Aceleraci�n gravitatoria
    public float amortiguacion = 0.99f; // Factor de amortiguaci�n (0.99 para un frenado gradual)
    public float anguloInicial = 45f; // �ngulo inicial en grados

    private float angulo; // �ngulo actual del p�ndulo (en radianes)
    private float velocidadAngular; // Velocidad angular del p�ndulo

    void Start()
    {
        // Convertir el �ngulo inicial de grados a radianes
        angulo = anguloInicial * Mathf.Deg2Rad;
    }
    void Update()
    {
        // Calcular la aceleraci�n angular
        float aceleracionAngular = -(gravedad / longitud) * Mathf.Sin(angulo);

        // Actualizar la velocidad angular con amortiguaci�n
        velocidadAngular += aceleracionAngular * Time.deltaTime;
        velocidadAngular *= amortiguacion;

        // Actualizar el �ngulo
        angulo += velocidadAngular * Time.deltaTime;

        // Calcular la posici�n de la c�psula
        float x = longitud * Mathf.Sin(angulo);
        float y = -longitud * Mathf.Cos(angulo);

        // Actualizar la posici�n del objeto
        transform.localPosition = new Vector3(x, y, 0f);
    }
}
