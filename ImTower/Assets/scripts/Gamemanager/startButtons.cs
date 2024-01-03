using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtons : MonoBehaviour
{
    public Animator anim;

   public void PlayGame()
    {
        StartCoroutine(MainLevel());
        
    }

    IEnumerator MainLevel()
    {
        anim.SetTrigger("In");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        anim.SetTrigger("Out");
    }
}
