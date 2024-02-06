using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    [SerializeField] GameObject _outZone;
    [SerializeField] GameObject _shop;
    [SerializeField] GameObject _backpack;
    [SerializeField] GameObject _settings;
    [SerializeField] GameObject _menu;
    [SerializeField] float _menuClosedPosition;
    [SerializeField] float _menuOpenedPosition;
    [SerializeField] List<GameObject> _objectsToHide;

    public void CloseMenu()
    {
        StartCoroutine(CloseMenuWithAnimation());
    }
    public void ShopOpen()
    {
        CloseAll();
        Open(_shop);
        if (_menu.transform.localPosition.y <= _menuClosedPosition)
            StartCoroutine(OpenMenuWithAnimation());
    }
    public void BackpackOpen()
    {
        CloseAll();
        Open(_backpack);
        if (_menu.transform.localPosition.y <= _menuClosedPosition)
            StartCoroutine(OpenMenuWithAnimation());
    }
    public void SettingsOpen()
    {
        CloseAll();
        Open(_settings);
        if (_menu.transform.localPosition.y <= _menuClosedPosition)
            StartCoroutine(OpenMenuWithAnimation());
    }
    private IEnumerator OpenMenuWithAnimation()
    {
        float speed = 1f;
        while (_menu.transform.localPosition.y < _menuOpenedPosition)
        {
            var pos = _menu.transform.localPosition;
            _menu.transform.localPosition = new Vector3(pos.x, Mathf.Lerp(_menu.transform.localPosition.y, _menuOpenedPosition, speed * Time.deltaTime), pos.z);
            yield return new WaitForFixedUpdate();
            speed *= 1.5f;
        }
        _outZone.SetActive(true);
    }
    private IEnumerator CloseMenuWithAnimation()
    {
        float speed = 1f;
        while(_menu.transform.localPosition.y > _menuClosedPosition)
        {
            var pos = _menu.transform.localPosition;
            _menu.transform.localPosition = new Vector3(pos.x, Mathf.Lerp(_menu.transform.localPosition.y, _menuClosedPosition, speed * Time.deltaTime), pos.z);
            yield return new WaitForFixedUpdate();
            speed *= 1.5f;
        }
        _outZone.SetActive(false);

        CloseAll();
    }
    private void Open(GameObject obj)
    {
        obj.SetActive(true);
        _objectsToHide.ForEach(x => x.SetActive(false));
    }
    private void CloseAll()
    {
        _settings.SetActive(false);
        _backpack.SetActive(false);
        _shop.SetActive(false);

        _objectsToHide.ForEach(x => x.SetActive(true));
    }
}
