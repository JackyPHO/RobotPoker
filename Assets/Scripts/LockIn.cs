using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockIn : MonoBehaviour
{
    public Button lockButton;
    public Template template;

    void Start()
    {   
        Button btn = lockButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if (template.isComplete()){
            //call battle manager
        }
    }


}
