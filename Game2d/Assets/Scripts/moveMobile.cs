using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMobile : MonoBehaviour {

   // public GameObject thePlayer;
    //playerController theController;
    void Start()
    {
        //theController = thePlayer.GetComponent<playerController>();
        
    }
    public void moveLeft()
    {
        //theController.move = -1;
        Debug.Log("Klikłeś", gameObject);

    }
    public void moveRight()
    {
        //theController.move = 1;
    }
}
