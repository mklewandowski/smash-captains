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
    [SerializeField]
    MeshRenderer GreenTankRenderer;

    [SerializeField]
    Material TankMaterial;
   [SerializeField]
    Material WhiteMaterial;

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

    public void ChangeToTank()
    {
        TankFlash(false);
        if (GreenTank.activeSelf)
            return;

        GreenTank.transform.localScale = new Vector3(.1f, .1f, .1f);
        GreenTank.SetActive(true);
        GreenTank.GetComponent<GrowAndShrink>().StartEffect();

        GameObject currPlane = GetCurrentPlane();

        currPlane.GetComponent<ShrinkAndHide>().StartEffect();
    }

    public void TankFlash(bool flash)
    {
        Material[] materialArray = GreenTankRenderer.materials;
        materialArray[0] = flash ? WhiteMaterial : TankMaterial;
        GreenTankRenderer.materials = materialArray;
    }

    public void RestorePlaneColor()
    {
        if (!GreenTank.activeSelf)
            return;

        GameObject currPlane = GetCurrentPlane();
        currPlane.transform.localScale = new Vector3(.1f, .1f, .1f);
        currPlane.SetActive(true);
        currPlane.GetComponent<GrowAndShrink>().StartEffect();

        GreenTank.GetComponent<ShrinkAndHide>().StartEffect();
    }

    GameObject GetCurrentPlane()
    {
        GameObject currPlane = Red;
        if (currentPlaneColor == Globals.PlaneColor.Yellow)
            currPlane = Yellow;
        if (currentPlaneColor == Globals.PlaneColor.Orange)
            currPlane = Orange;
        if (currentPlaneColor == Globals.PlaneColor.Blue)
            currPlane = Blue;
        if (currentPlaneColor == Globals.PlaneColor.Pink)
            currPlane = Pink;
        return currPlane;
    }
}
