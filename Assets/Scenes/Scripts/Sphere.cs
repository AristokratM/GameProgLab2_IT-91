using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    [SerializeField] KeyCode keyUp; 
    [SerializeField] KeyCode keyDown;
    [SerializeField] KeyCode keyLeft;
    [SerializeField] KeyCode keyRight;

     private Rigidbody _rb;
 
    Vector3 _UpVector;
    Vector3 _RightVector;
    const float speed = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //This Vector is set to 1 in the z axis (for moving upwards)
        _UpVector = Vector3.forward;
        //This Vector is set to 1 in the x axis (for moving in the right direction)
        _RightVector = Vector3.right;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyDown)) 
        {
            _rb.velocity += _UpVector*speed; 
        }
        
        if (Input.GetKey(keyUp)) 
        { 
            _rb.velocity -= _UpVector*speed; 
        }

        if (Input.GetKey(keyLeft)) 
        { 
            _rb.velocity += _RightVector*speed; 
        }

        if (Input.GetKey(keyRight)) 
        { 
            _rb.velocity -= _RightVector*speed; 
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}