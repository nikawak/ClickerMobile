using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> ObjectsToHide;
    public IEnumerator LoadBoss(Enemy enemy, Action callback)
    {
        ObjectsToHide.Add(enemy.gameObject);

        
        UnityEngine.SceneManagement.SceneManager.LoadScene("CutScene", LoadSceneMode.Additive);
        SetActiveMultiple(false);
        yield return new WaitForSeconds(5);

        SetActiveMultiple(true);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("CutScene");

        ObjectsToHide.Remove(enemy.gameObject);

        callback.Invoke();
    }
    private void SetActiveMultiple(bool isActive)
    {
        foreach (var obj in ObjectsToHide)
        {
            obj.SetActive(isActive);
        }
    }
}