using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public AudioSource clickSound;

    public void ChangeSceneWithDelay(string sceneName)
    {
        StartCoroutine(PlaySoundThenLoad(sceneName));
    }

    private IEnumerator PlaySoundThenLoad(string sceneName)
    {
        if (clickSound != null)
            clickSound.Play();

        // espera el sonido del click
        if (clickSound != null && clickSound.clip != null)
            yield return new WaitForSeconds(clickSound.clip.length);

        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        if (clickSound != null)
            clickSound.Play();

        Application.Quit();

        // Solo para comprobar en el editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
