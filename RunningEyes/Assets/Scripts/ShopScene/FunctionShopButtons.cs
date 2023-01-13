using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionShopButtons : MonoBehaviour
{
    public void GoBackInMenu()
    {
        SceneManager.LoadScene(0);
    }
}
