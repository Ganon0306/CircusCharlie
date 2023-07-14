using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLotation : MonoBehaviour
{
    public GameObject Player;
    private float offset;

    public float holdTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - Player.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (holdTime <= 40f)
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
        

        if (Player.transform.position.x > -8.21f && holdTime < 30f)
        {
            Vector3 targetPosition = new Vector3(Player.transform.position.x + offset, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }

    }
}
