using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // what we are following
    public Transform player;
    // zeros out the velocity
    Vector3 veocity = Vector3.zero;
    // time to follow player
    public float smoothTime = .15f;
    //enable and set the maximum y value
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;
    // enable and set the minimum y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;
    // enable and set the maximum x value
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;
    // enable and set the minimum x value
    public bool XMinEnabled = false;
    public float XMinValue = 0;
    void FixedUpdate()
    {//player position
        Vector3 playerPosition = player.position;

        // Vertical
        if (YMinEnabled && YMaxEnabled)
        {
            playerPosition.y = Mathf.Clamp(player.position.y, YMinValue, YMaxValue);
        }
        else if (YMinEnabled)
        {
            playerPosition.y = Mathf.Clamp(player.position.y, YMinValue, player.position.y);
        }
        else if (YMaxEnabled)
        {
            playerPosition.y = Mathf.Clamp(player.position.y, player.position.y, YMaxValue);
        }
        // Horizontal 
        if (XMinEnabled && XMaxEnabled)
        {
            playerPosition.x = Mathf.Clamp(player.position.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            playerPosition.x = Mathf.Clamp(player.position.x, XMinValue, player.position.x);
        }
        else if (XMaxEnabled)
        {
            playerPosition.x = Mathf.Clamp(player.position.x, player.position.x, XMaxValue);
        }
            // aligns the camera and the target z position
            playerPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position,playerPosition, ref veocity,smoothTime);

    }
}
