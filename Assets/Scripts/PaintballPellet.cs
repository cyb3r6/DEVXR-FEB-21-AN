using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballPellet : MonoBehaviour
{
    public List<Material> paints = new List<Material>();
    private int paintIndex = 0;
    
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paintable")
        {
            collision.collider.GetComponent<Renderer>().material = paints[paintIndex];

            paintIndex++;


            //Destroy(this.gameObject);
        }
    }
}
