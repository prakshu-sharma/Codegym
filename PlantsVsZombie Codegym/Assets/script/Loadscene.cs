using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadscene : MonoBehaviour
{
    public void ChangeTO(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }
}
