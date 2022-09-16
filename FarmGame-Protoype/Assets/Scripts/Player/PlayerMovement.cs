using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    [Header ("Propiedades Jugador")]
    // Movement
    private InputManager inputManager;
    private AnimatorManager animatorManager;

    
    private Rigidbody2D _rb;
    
    //Camera
    private Camera _cameraPlayer;
    private Transform _targetCamera;

    [Header ("Estadisticas Jugador")]
    public int playerSpeed;
    public Vector2 movementInput;
    //private Camera camera;

    private void Awake() {
        
        // Define the Input
        inputManager = GetComponent<InputManager>();
        animatorManager = GetComponent<AnimatorManager>();

        // Define the camera
        _cameraPlayer = FindObjectOfType<Camera>();

        // Define components
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        inputManager.AllMovement();
        Move(inputManager.moveAmount);
        // Animations
        animatorManager.AllAnimations();
    }

    public void Move (Vector2 inputVector){
        var movementOffset = inputVector * playerSpeed * Time.fixedDeltaTime;
        var newPosition = _rb.position + movementOffset;
        _rb.MovePosition(newPosition);
    }
}
