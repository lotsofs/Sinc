using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEntranceMenu : MonoBehaviour {

    public MenuController menuController;

    public void StartTV()
    {
        menuController.StartTV();
        gameObject.SetActive(false);
    }
}