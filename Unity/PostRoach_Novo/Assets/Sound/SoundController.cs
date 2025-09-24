using UnityEngine;

public class SoundController : MonoBehaviour
{
    private bool estadosom = true;

    [SerializeField] AudioSource audioAmbiente, audioNotificar;

    public void VolumeAmbiente(float valueAmbiente)
    {
        audioAmbiente.volume = valueAmbiente;
    }

    public void VolumeNotificar(float valueNotificar)
    {
        audioNotificar.volume = valueNotificar;
    }
}
