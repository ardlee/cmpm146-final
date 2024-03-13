using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public TMP_Text speedText;
    public Rigidbody playerRigidbody;

    private void Update()
    {
        // Get the player's current speed
        float speed = playerRigidbody.velocity.magnitude;

        // Display the speed in the TMP Text element
        speedText.text =  speed.ToString("F2") + " m/h"; 
        //not accurate unitys of speed, idk what the exact velocity really is and what units to use
    }
}
