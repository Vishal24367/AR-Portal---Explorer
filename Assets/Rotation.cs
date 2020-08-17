using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{


    [SerializeField]
    GameObject rotationGizmo;

    [SerializeField]
    private bool _show_rotation;



    Transform rotationIconTransform, rotationTriangleTransform;
    Text rotationValueText;



    #region Properties




    public bool Show_rotation
    {
        get
        {
            return _show_rotation;
        }

        set
        {
            _show_rotation = value;
        }
    }


    #endregion

    void Start()
    {

        SetRotationGizmoParts();


    }


    void Update()
    {

        DisplayRotationGizmo(ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info);

    }

    #region Display Methods


    /// <summary>
    /// Displays the rotation tracked from a hand onto a visual gizmo
    /// </summary>
    /// <param name="tracking_info"> Requires tracking information</param>
    void DisplayRotationGizmo(TrackingInfo tracking_info)
    {
        rotationGizmo.SetActive(Show_rotation);

        if (Show_rotation)
        {
            float angle = Mathf.LerpAngle(rotationIconTransform.rotation.z, tracking_info.rotation, 0.8f);
            rotationIconTransform.eulerAngles = new Vector3(0, 0, -angle);
            rotationTriangleTransform.eulerAngles = new Vector3(0, 0, -angle);
            rotationValueText.text = tracking_info.rotation.ToString();
        }
        else
        {
            float angle = Mathf.LerpAngle(rotationIconTransform.rotation.z, 0, 0.8f);
            rotationIconTransform.eulerAngles = new Vector3(0, 0, angle);
            rotationTriangleTransform.eulerAngles = new Vector3(0, 0, angle);
            rotationValueText.text = "0";
        }
    }




    #endregion



    /// <summary>
    /// Initializes the components of Rotation Gizmo
    /// </summary>
    void SetRotationGizmoParts()
    {
        rotationIconTransform = rotationGizmo.transform.Find("RotationIcon").GetComponent<Transform>();
        rotationTriangleTransform = rotationIconTransform.Find("Triangle").GetComponent<Transform>();
        rotationValueText = rotationGizmo.transform.Find("Value").GetComponent<Text>();
    }




}
