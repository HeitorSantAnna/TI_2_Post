using UnityEngine;

public class MecanicasWin : MonoBehaviour
{
    public float input, speed;
    [SerializeField] GameObject player;
    public Transform cameraTransform;
    public float velocity = 5;
    public float altura;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            player.transform.Translate(0, speed * input * Time.deltaTime, 0);
        }

        //Esperar para fazer
        /*
        if(Input.GetKey(KeyCode.Alpha2))
        {
            if (player.transform.position.y > 2)
            {
                Vector3 direction = cameraTransform.forward;
                direction.y = -10;
                direction.Normalize();

                player.transform.position += direction * velocity * Time.deltaTime;
            }
        }
        */
    }
}
