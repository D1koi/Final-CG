using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody rb;
    
    

    public GameObject character;
    public GameObject reinicio;
    

    [SerializeField] private float dashForce;
    [SerializeField] private float dashCD;
    [SerializeField] private float remolinoCD;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();   
               
    }
    
    #region Dash Code : Aqui esta la lógica del Dash
    
    public void Dash()
    {
        _animator.SetBool("isDashing", true);
        rb.AddForce(transform.forward * dashForce);
        Invoke("StopDash", dashCD);
    }
    private void StopDash()
    {
        _animator.SetBool("isDashing", false);
        Invoke("ResetPosition",0.5f);
    }

    private void ResetPosition()
    {
        character.transform.position = reinicio.transform.position;
    }
    #endregion

    public void Remolino()
    {
        _animator.SetBool("castRemolino", true);
        
        Invoke("StopRemolino", remolinoCD);
    }
    private void StopRemolino()
    {
        _animator.SetBool("castRemolino", false);
        
    }

    


}
