using UnityEngine;
using System.Collections;

public class GCPause : MonoBehaviour{

    bool isPause;

    void Pause(){
        Time.timeScale = 0;
    }

    void UnPause()
    {
        Time.timeScale = 1;
    }

     void Update(){
        if (Input.GetKeyDown(KeyCode.P)){
          isPause = !isPause;

            if (isPause){

                Pause();
            }else{
                UnPause();
            }
                
        }
        

    }
}

   
