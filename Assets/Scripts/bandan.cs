using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tancong : MonoBehaviour
{
    public float speed;
    Rigidbody2D mybody;

     void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        mybody.AddForce(new Vector2 (1, 0)*speed,ForceMode2D.Impulse);


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
