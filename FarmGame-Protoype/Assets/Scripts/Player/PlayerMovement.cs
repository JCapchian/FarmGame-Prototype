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
    private PlayerControls _playerControls;
    public Vector2 movementInput;
    private Rigidbody2D _rb;
    
    //Animation
    private Animator _playerAnimator;
    private Vector2 _animatorValues;

    //Particle Effect
    ParticleSystem _particleSystem;
    
    //Camera
    private Camera _cameraPlayer;
    private Transform _targetCamera;

    [Header ("Estadisticas Jugador")]
    public int playerSpeed;
    //private Camera camera;

    private void Awake() {
        
        // Define the Input
        _playerControls = new PlayerControls();

        // Define the animator
        _playerAnimator = GetComponent<Animator>();

        //  Assing the particle system
        _particleSystem = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
        _particleSystem.Stop();

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
        PollInput();

        // Animations
        AnimationValues();
    }

    private void OnEnable() {
        _playerControls.Enable();
    }
    private void OnDisable() {
        _playerControls.Disable();
    }

    #region MovementRegion

    void PollInput(){
        var movementInputVector = _playerControls.Player.Move.ReadValue<Vector2>();
        movementInput = movementInputVector;
        //Debug.Log(movementInput);
        Move(movementInputVector);
    }

    public void Move (Vector2 inputVector){
        var movementOffset = inputVector * playerSpeed * Time.fixedDeltaTime;
        var newPosition = _rb.position + movementOffset;
        _animatorValues = movementOffset;
        _rb.MovePosition(newPosition);
        //MyAnimator.SetFloat("Movimiento", movementOffset);
    }



    #endregion

    #region AnimationRegion
    
    void AnimationValues(){
        if(_animatorValues.magnitude == 0){
            _playerAnimator.SetBool("isIdle",true);
            _playerAnimator.SetBool("isWalking",false);
            _particleSystem.Stop();
        }
        else{
            _playerAnimator.SetBool("isIdle",false);
            _playerAnimator.SetBool("isWalking",true);
            _particleSystem.Play();
            _playerAnimator.SetFloat("Horizontal", _animatorValues.x);
            _playerAnimator.SetFloat("Vertical", _animatorValues.y);
            _playerAnimator.SetFloat("Speed", _animatorValues.magnitude);
        }
    }

    #endregion
}
