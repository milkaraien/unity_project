using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpactivation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("jump");
        }
       
    }
}
