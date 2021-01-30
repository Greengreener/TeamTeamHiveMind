using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkPlayerInitializer : NetworkBehaviour
{
    [SerializeField] GameObject playerMain;
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject face;
    //[SerializeField] GameObject playerCanvas;
    //[SerializeField] CameraLook cameraBody;
    //[SerializeField] GameObject playerGun;
    public override void OnStartAuthority()
    {
        // GetComponentInChildren<PlayerInfo>().enabled = true;
        // GetComponentInChildren<Movement>().enabled = true;
        // cameraBody.enabled = true;
        playerMain.SetActive(true);
        playerCamera.SetActive(true);
        face.SetActive(true);
        GetComponentInChildren<PlayerInput>().enabled = true;
        GetComponentInChildren<CharacterController>().enabled = true;
        // playerCanvas.SetActive(true);
        // playerGun.SetActive(true);
    }
}