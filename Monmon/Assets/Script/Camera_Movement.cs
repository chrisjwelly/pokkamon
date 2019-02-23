using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform pet ;
    public Vector3 scene1;
    public Vector3 scene2;
    private int i = 1;
    public int noOfScenes = 4;
   
    public void moveRight() {
        i = (i + 1)% noOfScenes;
        
        move();
    }
    public void moveLeft()
    {
        if (i <= 0)
        {
            i = noOfScenes - 1;
        }
        else
        {
            i = (i - 1) % noOfScenes;
        }
        
        move();
    }
    void move()
    {
        switch (i)
        {
            case 0:
                transform.position = scene1 - new Vector3(30, 0, 0);
                break;
            
            case 1:
                transform.position = scene1;
                pet.position = scene1 + Vector3.forward * 7;
               
                break;
            case 2:
                transform.position = scene2;
                pet.position = scene2 + Vector3.forward * 7;
                
                break;
            case 3:
                transform.position = scene2 + new Vector3(28, 0, 0);
                pet.position = scene2 + new Vector3(28, 0, 7);
                break;
            default:
                transform.position = scene1;
                pet.position = scene1 + Vector3.forward* 7; 
                i = 1;
                break;
       
        }
    }


}
