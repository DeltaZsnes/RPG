using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerFollow : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            float h = 0;
            float v = 0;

            if(Vector3.Distance(target.transform.position, this.transform.position) > 1.2f)
            {
                h = Mathf.Clamp(target.transform.position.x - this.transform.position.x, -1.0f, +1.0f);
                v = Mathf.Clamp(target.transform.position.y - this.transform.position.y, -1.0f, +1.0f);
            }

            GetComponent<Walker>().inputHorizontal = h;
            GetComponent<Walker>().inputVertical = v;
        }
    }
}
