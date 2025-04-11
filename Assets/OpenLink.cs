using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // Hàm mở đường link

    [SerializeField] GameObject mainMenuscreen;
    [SerializeField] GameObject Contactscreen;

    public GameObject Panel;


   
    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/snoke.881");
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/yourprofile");
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://instagram.com/yourprofile");
    }

    public void OpenContact()
    {
        Contactscreen.SetActive(true);
        Panel.transform.Find("Play").gameObject.SetActive(false);
        Panel.transform.Find("Setting").gameObject.SetActive(false);
        Panel.transform.Find("Information").gameObject.SetActive(false);
        Panel.transform.Find("Achievements").gameObject.SetActive(false);
        Panel.transform.Find("Contact").gameObject.SetActive(false);
    }

    public void CloseContact()
    {
        Contactscreen.SetActive(false);
        Panel.transform.Find("Play").gameObject.SetActive(true);
        Panel.transform.Find("Setting").gameObject.SetActive(true);
        Panel.transform.Find("Information").gameObject.SetActive(true);
        Panel.transform.Find("Achievements").gameObject.SetActive(true);
        Panel.transform.Find("Contact").gameObject.SetActive(true);
    }
}
