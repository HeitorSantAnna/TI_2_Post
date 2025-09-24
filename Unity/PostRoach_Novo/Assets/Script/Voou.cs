using UnityEngine;
using UnityEngine.EventSystems;

public class Voou : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float velocity = 5;
    public Transform cameraTransform;
    bool pressing;
    public GameObject player;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
    }

    void Update()
    {
        if (pressing && player.transform.position.y > 2)
        {
            // Movimento automático pela direção da câmera
            Vector3 direction = cameraTransform.forward;
            direction.y = -10;
            direction.Normalize();

            player.transform.position += direction * velocity * Time.deltaTime;
        }
    }
}
