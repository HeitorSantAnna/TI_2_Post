using Unity.VisualScripting;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float velocity = 10;
    public float aux = 10;
    public Rigidbody rb;
    float time = 10, aceleracao = 0, desaceleracao = 0;
    [SerializeField] GameObject vitoria;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vitoria.SetActive(false);
    }

#if UNITY_STANDALONE_WIN
    private void Awake()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    private void Update()
    {
        float velocidadeAngularTotal = 20f + aceleracao - desaceleracao;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * vertical * velocity);
        }

        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * vertical * velocity);
        }

        transform.Rotate(0, horizontal/2, 0);

        if (velocidadeAngularTotal > 0)
        {
            rb.maxAngularVelocity = velocidadeAngularTotal;
            aux = velocidadeAngularTotal + 5;
        }
        else if (velocidadeAngularTotal <= 0)
        {
            while (time > 0)
            {
                Debug.Log("Congelado");
                time--;
            }
            if (time == 0)
            {
                velocidadeAngularTotal = aux;
                time = 10;
            }
        }
        Ver();
    }



#elif UNITY_ANDROID

    private void Awake()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float velocidadeAngularTotal = 20f + aceleracao - desaceleracao;

        Ver();

        Vector3 direction = cameraTransform.forward;
        direction.Normalize();

        rb.AddForce(direction * velocity);

        if (velocidadeAngularTotal > 0)
        {
            rb.maxAngularVelocity = velocidadeAngularTotal;
            aux = velocidadeAngularTotal + 5;
        }
        else if (velocidadeAngularTotal <= 0)
        {
            while (time > 0)
            {
                Debug.Log("Congelado");
                time--;
            }
            if (time == 0)
            {
                velocidadeAngularTotal = aux;
                time = 10;
            }
        }
        Ver();
    }

#endif
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Entrega"))
        {
            SimpleHud.cartasEntregues++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Acelerar"))
        {
            aceleracao += 5;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Desacelerar"))
        {
            desaceleracao += 5;
            Destroy(other.gameObject);
        }
    }

    void Ver()
    {
        if(SimpleHud.cartasEntregues == SimpleHud.totalCartas)
        {
            Time.timeScale = 0;
            vitoria.SetActive(true);
        }
    }
}
