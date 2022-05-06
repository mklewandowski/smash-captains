using UnityEngine;

public class PlaneColor : MonoBehaviour
{
    [SerializeField]
    GameObject Red;
    [SerializeField]
    GameObject Yellow;
    [SerializeField]
    GameObject Orange;
    [SerializeField]
    GameObject Blue;
    [SerializeField]
    GameObject Pink;
    [SerializeField]
    GameObject GreenTank;

    Globals.PlaneColor currentPlaneColor = Globals.PlaneColor.Yellow;

    public void SetPlaneColor(int c)
    {
        Globals.PlaneColor planeColor = (Globals.PlaneColor)c;
        if (planeColor != Globals.PlaneColor.GreenTank)
            currentPlaneColor = planeColor;
        Red.SetActive(planeColor == Globals.PlaneColor.Red);
        Yellow.SetActive(planeColor == Globals.PlaneColor.Yellow);
        Orange.SetActive(planeColor == Globals.PlaneColor.Orange);
        Blue.SetActive(planeColor == Globals.PlaneColor.Blue);
        if (Pink != null) Pink.SetActive(planeColor == Globals.PlaneColor.Pink);
        if (GreenTank != null) GreenTank.SetActive(planeColor == Globals.PlaneColor.GreenTank);
    }

    public void RestorePlaneColor()
    {
        Red.SetActive(currentPlaneColor == Globals.PlaneColor.Red);
        Yellow.SetActive(currentPlaneColor == Globals.PlaneColor.Yellow);
        Orange.SetActive(currentPlaneColor == Globals.PlaneColor.Orange);
        Blue.SetActive(currentPlaneColor == Globals.PlaneColor.Blue);
        if (Pink != null) Pink.SetActive(currentPlaneColor == Globals.PlaneColor.Pink);
        if (GreenTank != null) GreenTank.SetActive(currentPlaneColor == Globals.PlaneColor.GreenTank);
    }
}
