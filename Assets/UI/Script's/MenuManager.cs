using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FWC
{
    public class MenuManager : MonoBehaviour
    {

        //In the inspector, drag and drop the objects with the Menu Script attached to here
        [SerializeField] Menu[] menus;

        public static MenuManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        /* 1 - Use the functions bellow to Activate and Deactivate the Menus 

        2 - You can call them on you script, or attach them to a Button 

        3 - When you use the function "OpenMenu", the script will automatically close the last Menu openned  */

        public void OpenMenu(string menuName)
        {
            for (int i = 0; i < menus.Length; i++)
            {
                if (menus[i].menuName == menuName)
                {
                    menus[i].Open();
                }
                else if (menus[i].open)
                {
                    CloseMenu(menus[i]);
                }
            }
        }

        public void OpenMenu(Menu menu)
        {


            for (int i = 0; i < menus.Length; i++)
            {
                if (menus[i].open)
                {
                    CloseMenu(menus[i]);
                }

            }

            menu.Open();
        }

        public void CloseMenu(string menuName)
        {
            for (int i = 0; i < menus.Length; i++)
            {
                if (menus[i].menuName == menuName)
                {

                    CloseMenu(menus[i]);

                }
            }

        }

        public void CloseMenu(Menu menu)
        {
            menu.Close();
        }
    }

}