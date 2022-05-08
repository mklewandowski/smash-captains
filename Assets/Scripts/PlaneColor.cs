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
    GameObject Berkeley;
    [SerializeField]
    GameObject BombPop;
    [SerializeField]
    GameObject Burger;
    [SerializeField]
    GameObject CandyCorn;
    [SerializeField]
    GameObject CheeseBurger;
    [SerializeField]
    GameObject CottonCandy;
    [SerializeField]
    GameObject Creamsicle;
    [SerializeField]
    GameObject IceCreamSandwich;
    [SerializeField]
    GameObject Lime;
    [SerializeField]
    GameObject Pizza;
    [SerializeField]
    GameObject Pack;
    [SerializeField]
    GameObject Shadow;
    [SerializeField]
    GameObject Smores;
    [SerializeField]
    GameObject Snow;
    [SerializeField]
    GameObject Teal;
    [SerializeField]
    GameObject Watermelon;

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
        Pink.SetActive(planeColor == Globals.PlaneColor.Pink);
        Berkeley.SetActive(planeColor == Globals.PlaneColor.Berkeley);
        BombPop.SetActive(planeColor == Globals.PlaneColor.BombPop);
        Burger.SetActive(planeColor == Globals.PlaneColor.Burger);
        CandyCorn.SetActive(planeColor == Globals.PlaneColor.CandyCorn);
        CheeseBurger.SetActive(planeColor == Globals.PlaneColor.CheeseBurger);
        CottonCandy.SetActive(planeColor == Globals.PlaneColor.CottonCandy);
        Creamsicle.SetActive(planeColor == Globals.PlaneColor.Creamsicle);
        IceCreamSandwich.SetActive(planeColor == Globals.PlaneColor.IceCreamSandwich);
        Lime.SetActive(planeColor == Globals.PlaneColor.Lime);
        Pizza.SetActive(planeColor == Globals.PlaneColor.Pizza);
        Pack.SetActive(planeColor == Globals.PlaneColor.Pack);
        Shadow.SetActive(planeColor == Globals.PlaneColor.Shadow);
        Smores.SetActive(planeColor == Globals.PlaneColor.Smores);
        Snow.SetActive(planeColor == Globals.PlaneColor.Snow);
        Teal.SetActive(planeColor == Globals.PlaneColor.Teal);
        Watermelon.SetActive(planeColor == Globals.PlaneColor.Watermelon);
        Pink.SetActive(planeColor == Globals.PlaneColor.Pink);

        if (GreenTank != null) GreenTank.SetActive(planeColor == Globals.PlaneColor.GreenTank);

        Globals.SaveIntToPlayerPrefs(Globals.PlaneFlavorPlayerPrefsKey, c);
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
        if (currentPlaneColor == Globals.PlaneColor.Berkeley)
            currPlane = Berkeley;
        if (currentPlaneColor == Globals.PlaneColor.BombPop)
            currPlane = BombPop;
        if (currentPlaneColor == Globals.PlaneColor.Burger)
            currPlane = Burger;
        if (currentPlaneColor == Globals.PlaneColor.CandyCorn)
            currPlane = CandyCorn;
        if (currentPlaneColor == Globals.PlaneColor.CheeseBurger)
            currPlane = CheeseBurger;
        if (currentPlaneColor == Globals.PlaneColor.CottonCandy)
            currPlane = CottonCandy;
        if (currentPlaneColor == Globals.PlaneColor.Creamsicle)
            currPlane = Creamsicle;
        if (currentPlaneColor == Globals.PlaneColor.IceCreamSandwich)
            currPlane = IceCreamSandwich;
        if (currentPlaneColor == Globals.PlaneColor.Lime)
            currPlane = Lime;
        if (currentPlaneColor == Globals.PlaneColor.Pizza)
            currPlane = Pizza;
        if (currentPlaneColor == Globals.PlaneColor.Pack)
            currPlane = Pack;
        if (currentPlaneColor == Globals.PlaneColor.Shadow)
            currPlane = Shadow;
        if (currentPlaneColor == Globals.PlaneColor.Smores)
            currPlane = Smores;
        if (currentPlaneColor == Globals.PlaneColor.Snow)
            currPlane = Snow;
        if (currentPlaneColor == Globals.PlaneColor.Teal)
            currPlane = Teal;
        if (currentPlaneColor == Globals.PlaneColor.Watermelon)
            currPlane = Watermelon;

        return currPlane;
    }
}
