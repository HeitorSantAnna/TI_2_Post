using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Escalada : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float input, speed;
    public float sensibitlity = 3;
    bool pressing;
    [SerializeField] GameObject player;
    Rigidbody rb;
    public MovimentoCamera scriptPlayer;

    void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
        scriptPlayer.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
        scriptPlayer.enabled = true;
    }

    void Update()
    {
        if(pressing)
        {
            input += Time.deltaTime * sensibitlity;
        }
        else
        {
            input -= Time.deltaTime * (sensibitlity * 10000);
        }

        input = Mathf.Clamp(input, 0, 2f);

        player.transform.Translate(0, speed * input * Time.deltaTime, 0);
    }
}
