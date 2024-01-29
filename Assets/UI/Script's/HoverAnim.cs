using UnityEngine;
using UnityEngine.EventSystems;

namespace FWC
{
    public class HoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {

        [SerializeField] float scaleChange = 1.1f;

        [SerializeField] AudioSource source;


        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale *= scaleChange;

            if (source.clip == null) return;

            source.PlayOneShot(source.clip);

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
