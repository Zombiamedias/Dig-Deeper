using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;  // El jugador (o el objeto que la cámara debe seguir)
    public float smoothSpeed = 0.125f;  // Velocidad de suavizado
    public Vector3 offset;  // Desplazamiento de la cámara con respecto al jugador

    void LateUpdate()
    {
        if (target != null)
        {
            // La posición deseada de la cámara es la del jugador más el desplazamiento
            Vector3 desiredPosition = target.position + offset;
            
            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // Establece la nueva posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
