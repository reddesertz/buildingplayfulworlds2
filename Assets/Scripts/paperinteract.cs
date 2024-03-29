using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paperinteract : MonoBehaviour
{

public bool isInRange;
public GameObject player;
public KeyCode interactKey;
public Animator transition;
public float transitionTime = 2f;

    void Update()
    {
        if(isInRange){
        if(Input.GetKeyDown(interactKey)){
           LoadNextLevel();
        }
    }
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo){
if (collisionInfo.gameObject.tag == "Player"){
        isInRange = true; 
        Debug.Log("in range");
    }
    }

     private void OnTriggerExit2D(Collider2D collisionInfo){
if (collisionInfo.gameObject.tag == "Player"){
        isInRange = false; 
        Debug.Log("no range");
    }
    }

    public void LoadNextLevel(){
       StartCoroutine (LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex){

        Debug.Log($"levelIndex {levelIndex}");

        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}

