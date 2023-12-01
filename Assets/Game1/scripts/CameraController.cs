using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;
   
   public float panSpeed = 30f;
   public float panBorderThickness = 5f;
   public float minY = 20f;
   public float maxY = 100f;

   public float scrollSpeed = 5f;

    // Update is called once per frame
    void Update() {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;
        
        if (Input.GetKey("w") )//|| Input.mousePosition.y >= Screen.height - panBorderThickness) 
        {
            transform.Translate(Vector3.back/*would normally be Vector3.forward, but messed up camera in unity itself*/ * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") )//|| Input.mousePosition.y <= panBorderThickness) 
        {
            transform.Translate(Vector3.forward/*would normally be Vector3.back, but messed up camera in unity itself*/ * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") )//|| Input.mousePosition.x >= Screen.width - panBorderThickness) 
        {
            transform.Translate(Vector3.left/*would normally be Vector3.right, but messed up camera in unity itself*/ * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") )//|| Input.mousePosition.x <= panBorderThickness) 
        {
            transform.Translate(Vector3.right/*would normally be Vector3.left, but messed up camera in unity itself*/ * panSpeed * Time.deltaTime, Space.World);
        }
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp (pos.y, minY, maxY);

        transform.position = pos;
    }
}
