using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] Button escalada, voar;
    [SerializeField] GameObject player;
    [SerializeField] Escalada escaladas;

    void Start()
    {
        escalada.interactable = false;
        voar.interactable = false;
        escaladas.enabled = false;
    }

    void Update()
    {
        if(player.transform.position.y > 2)
        {
            voar.interactable = true;
        }
        else
        {
            voar.interactable = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            escalada.interactable = true;
            escaladas.enabled = true;
        }
        else
        {
            escalada.interactable = false;
            escaladas.enabled = false;
        }
    }
}
