using UnityEngine;

public class MoverEnX : MonoBehaviour
{
    public float velocidad = 2.2f;
    public bool moverALaDerecha = true;
    public Rigidbody rb;
    public bool mover = true;
    private bool Grabbing = false;
    private Vector3 posicionInicial;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = gameObject.transform.position;
    }
    void Update()
    {
        if (mover)
        {
            float direccion = moverALaDerecha ? 1f : -1f;
            transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);
        }
    }

    public void hacerDinamico()
    {
        rb.isKinematic = false;
        mover = false;
        Grabbing = true;
    }

    public void soltar()
    {
        Grabbing = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barra") && !Grabbing)
        {
            mover = true;
            rb.isKinematic = true;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, posicionInicial.y, posicionInicial.z);
        }
    }
}
