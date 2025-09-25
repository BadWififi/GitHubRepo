using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player is on the checkpoint");
            SceneManager.LoadScene("SecretArea");

        }
        if (SceneManager.GetActiveScene().name == "SecretArea")
        {
            StartCoroutine(ChangeAfter4SecondsCoroutine());
        }
    }
    IEnumerator ChangeAfter4SecondsCoroutine()
        {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("GameLevel");
        }

}