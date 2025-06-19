using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class SimpleFPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 3.0f; //Velocidad de desplazamiento (m/s) sobre el plano horizontal.
    public float gravity = -9.81f; //Aceleración vertical negativa; simula gravedad 

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 100f; //Qué tan “sensibles” son los movimientos del ratón para rotar la cámara.
    public Transform cameraTransform; //Referencia al objeto Cámara (su Transform), para girarla en pitch.

    CharacterController cc; //Variable privada donde guardaremos el componente CharacterController
    Vector3 velocity; //Vector de velocidad vertical usado para la gravedad
    float xRotation = 0f; //Ángulo acumulado de rotación vertical (pitch) de la cámara.

    void Awake()
    {
        cc = GetComponent<CharacterController>(); //cacheamos el CharacterController para poder movernos.
        Cursor.lockState = CursorLockMode.Locked; //Oculta y bloquea el cursor en el centro de la pantalla, típico de FPS.
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Lee movimiento horizontal del ratón
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Lee movimiento vertical del ratón

        xRotation -= mouseY; //Acumula la rotación vertical, restamos porque subir el mouse mira hacia arriba.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Limita el pitch para que no pasemos de mirar 90° arriba o abajo.
        // Aplica rotación vertical (pitch) a la cámara:
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Aplica la rotación vertical a la cámara
        transform.Rotate(Vector3.up * mouseX); //Rota todo el GameObject (el “cuerpo” del jugador)

        // Movement horizontal
        Vector3 move = transform.right * Input.GetAxis("Horizontal")
                     + transform.forward * Input.GetAxis("Vertical"); //Toma los ejes Horizontal (A/D o flechas) y Vertical (W/S o flechas)
                                                                      //y los proyecta en los ejes locales right y forward del jugador.
        cc.Move(move * speed * Time.deltaTime); //Mueve el CharacterController en el plano, multiplicando por speed y deltaTime.

        // Gravity
        if (cc.isGrounded && velocity.y < 0) //Si estamos en el suelo y ya íbamos cayendo
            velocity.y = -2f; //Reiniciamos la velocidad vertical a un pequeño valor negativo para mantener al jugador en el suelo.
        velocity.y += gravity * Time.deltaTime; //Integramos la gravedad en velocity.y cada frame.
        cc.Move(velocity * Time.deltaTime); //Aplicamos ese velocity vertical (caída) al CharacterController.
    }
}
