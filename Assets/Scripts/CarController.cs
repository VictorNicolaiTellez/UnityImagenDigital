using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.down * 0.5f;
    }

    void FixedUpdate()
    {
        if(rb == null) return;

        // Leer teclado con Input System
        float move = 0f;
        float turn = 0f;

        if(Keyboard.current.wKey.isPressed) move += 1f;
        if(Keyboard.current.sKey.isPressed) move -= 1f;
        if(Keyboard.current.aKey.isPressed) turn -= 1f;
        if(Keyboard.current.dKey.isPressed) turn += 1f;

        // Movimiento hacia adelante
        Vector3 forwardMove = transform.forward * move * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Giro
        float turnAmount = turn * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
