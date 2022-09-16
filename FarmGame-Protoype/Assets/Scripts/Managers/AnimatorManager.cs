using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator _playerAnimator;
    InputManager inputManager;

    ParticleSystem _particleSystem;

    private void Awake() 
    {
        inputManager = GetComponent<InputManager>();
        _playerAnimator = GetComponent<Animator>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void AllAnimations()
    {
        MovementAnimation();
    }

    void MovementAnimation()
    {
        if(inputManager.moveAmount.magnitude != 0)
        {
            _playerAnimator.SetBool("isIdle",false);
            _playerAnimator.SetBool("isWalking",true);

            _particleSystem.enableEmission = true;
            //_particleSystem.loop = true;
            //_particleSystem.Play();
            _playerAnimator.SetFloat("Horizontal", inputManager.moveAmount.x);
            _playerAnimator.SetFloat("Vertical", inputManager.moveAmount.y);
            _playerAnimator.SetFloat("Speed", inputManager.moveAmount.magnitude);
        }
        else{
            _playerAnimator.SetBool("isIdle",true);
            _playerAnimator.SetBool("isWalking",false);
            _particleSystem.enableEmission = false;
            //_particleSystem.Pause();
            //_particleSystem.loop = false;
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
