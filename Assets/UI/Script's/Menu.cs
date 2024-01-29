using System.Collections;
using UnityEngine;


namespace FWC
{
    public class Menu : MonoBehaviour
    {

        // In the Inspector, put the name you wan't the Menu to have
        public string menuName;

        // In the Inspector, mark this bool only on the Menu that will start the Scene open
        public bool open;


        public void Open()
        {
            open = true;
            gameObject.SetActive(true);
        }

        public void Close()
        {
            open = false;
            gameObject.SetActive(false);

        }

    }

}
