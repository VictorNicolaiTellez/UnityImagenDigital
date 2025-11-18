using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // El coche a seguir
    public float distance = 10f;    // Distancia detrás del coche
    public float height = 5f;       // Altura respecto al coche
    public float smoothSpeed = 5f;  // Suavizado del movimiento

    void LateUpdate()
    {
        if(target == null) return;

        // Posición deseada: detrás del coche usando su forward
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

        // Suavizar movimiento
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Mirar siempre al coche
        transform.LookAt(target);
    }
}
