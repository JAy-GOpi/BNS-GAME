using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showpass : MonoBehaviour
{
    public InputField showPassword;

    private void Update()
    {
        
    }
    public void showHide()
    {
        if(showPassword.contentType == InputField.ContentType.Password)
        {
            showPassword.contentType = InputField.ContentType.Standard;
            
        }
        else
        {
            showPassword.contentType = InputField.ContentType.Password;
        }
        showPassword.ForceLabelUpdate();
    }
    
}
