using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera front; 
    public Camera back; 

    private void Update()
    {
        // Check if the Shift key is being held down
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
           
            back.gameObject.SetActive(true);
            front.gameObject.SetActive(false);
        }
        else
        {
            
            front.gameObject.SetActive(true);
            back.gameObject.SetActive(false);
        }
    }
}
