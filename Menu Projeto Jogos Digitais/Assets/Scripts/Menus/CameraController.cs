using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 3f;
    public float panBorderThickness = 0.1f;
    public float scrollSpeed = 5f;

    void Update()
    {
        if (GameManager.jogoAcabou)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
            doMovement = !doMovement;

        if (!doMovement)
            return;            

        if (Input.mousePosition.y >= Screen.height - panBorderThickness) // Movimento com bordas da tela
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Zoom com scroll do mouse
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
