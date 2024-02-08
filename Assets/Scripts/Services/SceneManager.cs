using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> ObjectsToHide;
    [SerializeField] private GameObject Canvas;
    public static string EnemyTag;
    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetAllScenes().Length == 1) return;
        ObjectsToHide.ForEach(x => x.SetActive(true));
        var notBosses = ObjectsToHide.Where(x => !x.CompareTag(EnemyTag)).ToList();
        Canvas.gameObject.GetComponentsInChildren(typeof(TextMeshProUGUI)).ToList().ForEach(x=>x.gameObject.SetActive(false));
        notBosses.ForEach(x => x.SetActive(false));
    }
    public IEnumerator LoadBoss(Enemy enemy, Action callback)
    {
        EnemyTag = enemy.tag;
        ObjectsToHide.Add(enemy.gameObject);

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("CutScene", LoadSceneMode.Additive);

        SetActiveMultiple(false);
        yield return new WaitForSeconds(4f);

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