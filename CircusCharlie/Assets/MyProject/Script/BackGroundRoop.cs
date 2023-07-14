using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRoop : MonoBehaviour
{
    private float width;
    public GameObject camera_; 
    
    
    public KeyCode targetKey;
    public float holdTime = 0f;

    private void Awake()
    {

        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
        
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && holdTime <= 30f)
        {
            if (transform.position.x <= camera_.transform.position.x - width * 2)
            {
                Reposition();
            }
        }
        else if (Input.GetKey(KeyCode.A) && holdTime >= 0f)
        {
            if (transform.position.x >= camera_.transform.position.x + width * 2.5)
            {
                Reposition1();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (holdTime <= 30f)
            {
                holdTime += Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (holdTime >= 0f)
            {
                holdTime -= Time.deltaTime;
            }
        }
        


        //else if (Input.GetKey(targetKey))
        //{
        //    holdTime += Time.deltaTime;
        //}
        //else if (Input.GetKeyUp(targetKey))
        //{
        //    keyHeld = false;
        //    Debug.Log("Key held for: " + holdTime + " seconds");
        //}
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 4.435f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }

    private void Reposition1()
    {
        Vector2 offset = new Vector2(-width * 4.435f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}