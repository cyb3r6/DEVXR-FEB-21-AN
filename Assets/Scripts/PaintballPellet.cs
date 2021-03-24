using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballPellet : MonoBehaviour
{
    public List<Material> paints = new List<Material>();
    private static int paintIndex = 0;
  

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paintable")
        {
            collision.collider.GetComponent<Renderer>().material = paints[paintIndex];

            paintIndex++;
            if(paintIndex == paints.Count)
            {
                paintIndex = 0;
            }

            //Destroy(this.gameObject);
        }
    }
}
