using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGizmoController : MonoBehaviour
{
    // Reference to the Canvas you want to interact with
    public List<Canvas> canvases;

    private void Update()
    {
        // Listen for user input (e.g., mouse click)
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            // Disable the Canvas GameObject
            //canvas.gameObject.SetActive(false);
            

            canvases.ForEach(canvas => { 
                Outline outline = canvas.GetComponent<Outline>();

                if (outline != null)
                {
                    outline.enabled = !outline.enabled;
                }
            }); 
        }
    }
}
