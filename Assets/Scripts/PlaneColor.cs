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
    GameObject Christmas;
    [SerializeField]
    GameObject Tiger;
    [SerializeField]
    GameObject ApplePie;
    [SerializeField]
    GameObject CherryPie;
    [SerializeField]
    GameObject Zebra;
    [SerializeField]
    GameObject PumpkinPie;
    [SerializeField]
    GameObject CandyCane;
    [SerializeField]
    GameObject CheeseBroc;
    [SerializeField]
    GameObject StrawberryBanana;
    [SerializeField]
    GameObject Pretzel;
    [SerializeField]
    GameObject Sherbet;
    [SerializeField]
    GameObject Rainbow;
    [SerializeField]
    GameObject Latte;
    [SerializeField]
    GameObject RootBeer;
    [SerializeField]
    GameObject Twinkie;
    [SerializeField]
    GameObject Neo;
    [SerializeField]
    GameObject Cocoa;
    [SerializeField]
    GameObject Grape;
    [SerializeField]
    GameObject Pickle;

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
        Christmas.SetActive(planeColor == Globals.PlaneColor.Christmas);
        Tiger.SetActive(planeColor == Globals.PlaneColor.Tiger);
        ApplePie.SetActive(planeColor == Globals.PlaneColor.ApplePie);
        CherryPie.SetActive(planeColor == Globals.PlaneColor.CherryPie);
        Zebra.SetActive(planeColor == Globals.PlaneColor.Zebra);
        PumpkinPie.SetActive(planeColor == Globals.PlaneColor.PumpkinPie);
        CandyCane.SetActive(planeColor == Globals.PlaneColor.CandyCane);
        CheeseBroc.SetActive(planeColor == Globals.PlaneColor.CheeseBroc);
        StrawberryBanana.SetActive(planeColor == Globals.PlaneColor.StrawberryBanana);
        Pretzel.SetActive(planeColor == Globals.PlaneColor.Pretzel);
        Sherbet.SetActive(planeColor == Globals.PlaneColor.Sherbet);
        Rainbow.SetActive(planeColor == Globals.PlaneColor.Rainbow);
        Latte.SetActive(planeColor == Globals.PlaneColor.Latte);
        RootBeer.SetActive(planeColor == Globals.PlaneColor.RootBeer);
        Twinkie.SetActive(planeColor == Globals.PlaneColor.Twinkie);
        Neo.SetActive(planeColor == Globals.PlaneColor.Neo);
        Cocoa.SetActive(planeColor == Globals.PlaneColor.Cocoa);
        Grape.SetActive(planeColor == Globals.PlaneColor.Grape);
        Pickle.SetActive(planeColor == Globals.PlaneColor.Pickle);

        if (GreenTank != null) GreenTank.SetActive(planeColor == Globals.PlaneColor.GreenTank);

        Globals.SaveIntToPlayerPrefs(Globals.PlaneFlavorPlayerPrefsKey, c);
    }

    public void ChangeToTank()
    {
        TankFlash(false);
        if (GreenTank.activeSelf && !GreenTank.GetComponent<ShrinkAndHide>().IsShrinking())
            return;

        GreenTank.GetComponent<ShrinkAndHide>().StopEffect();
        GreenTank.transform.localScale = new Vector3(.1f, .1f, .1f);
        GreenTank.SetActive(true);
        GreenTank.GetComponent<GrowAndShrink>().StartEffect();

        GameObject currPlane = GetCurrentPlane();
        currPlane.GetComponent<GrowAndShrink>().StopEffect();
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
        currPlane.GetComponent<ShrinkAndHide>().StopEffect();
        currPlane.transform.localScale = new Vector3(.1f, .1f, .1f);
        currPlane.SetActive(true);
        currPlane.GetComponent<GrowAndShrink>().StartEffect();

        GreenTank.GetComponent<GrowAndShrink>().StopEffect();
        GreenTank.GetComponent<ShrinkAndHide>().StartEffect();
    }

    GameObject GetCurrentPlane()
    {
        GameObject currPlane = Red;
        if (currentPlaneColor == Globals.PlaneColor.Yellow)
            currPlane = Yellow;
        else if (currentPlaneColor == Globals.PlaneColor.Red)
            currPlane = Red;
        else if (currentPlaneColor == Globals.PlaneColor.Orange)
            currPlane = Orange;
        else if (currentPlaneColor == Globals.PlaneColor.Blue)
            currPlane = Blue;
        else if (currentPlaneColor == Globals.PlaneColor.Pink)
            currPlane = Pink;
        else if (currentPlaneColor == Globals.PlaneColor.Berkeley)
            currPlane = Berkeley;
        else if (currentPlaneColor == Globals.PlaneColor.BombPop)
            currPlane = BombPop;
        else if (currentPlaneColor == Globals.PlaneColor.Burger)
            currPlane = Burger;
        else if (currentPlaneColor == Globals.PlaneColor.CandyCorn)
            currPlane = CandyCorn;
        else if (currentPlaneColor == Globals.PlaneColor.CheeseBurger)
            currPlane = CheeseBurger;
        else if (currentPlaneColor == Globals.PlaneColor.CottonCandy)
            currPlane = CottonCandy;
        else if (currentPlaneColor == Globals.PlaneColor.Creamsicle)
            currPlane = Creamsicle;
        else if (currentPlaneColor == Globals.PlaneColor.IceCreamSandwich)
            currPlane = IceCreamSandwich;
        else if (currentPlaneColor == Globals.PlaneColor.Lime)
            currPlane = Lime;
        else if (currentPlaneColor == Globals.PlaneColor.Pizza)
            currPlane = Pizza;
        else if (currentPlaneColor == Globals.PlaneColor.Pack)
            currPlane = Pack;
        else if (currentPlaneColor == Globals.PlaneColor.Shadow)
            currPlane = Shadow;
        else if (currentPlaneColor == Globals.PlaneColor.Smores)
            currPlane = Smores;
        else if (currentPlaneColor == Globals.PlaneColor.Snow)
            currPlane = Snow;
        else if (currentPlaneColor == Globals.PlaneColor.Teal)
            currPlane = Teal;
        else if (currentPlaneColor == Globals.PlaneColor.Watermelon)
            currPlane = Watermelon;
        else if (currentPlaneColor == Globals.PlaneColor.Christmas)
            currPlane = Christmas;
        else if (currentPlaneColor == Globals.PlaneColor.Tiger)
            currPlane = Tiger;
        else if (currentPlaneColor == Globals.PlaneColor.ApplePie)
            currPlane = ApplePie;
        else if (currentPlaneColor == Globals.PlaneColor.CherryPie)
            currPlane = CherryPie;
        else if (currentPlaneColor == Globals.PlaneColor.Zebra)
            currPlane = Zebra;
        else if (currentPlaneColor == Globals.PlaneColor.PumpkinPie)
            currPlane = PumpkinPie;
        else if (currentPlaneColor == Globals.PlaneColor.CandyCane)
            currPlane = CandyCane;
        else if (currentPlaneColor == Globals.PlaneColor.CheeseBroc)
            currPlane = CheeseBroc;
        else if (currentPlaneColor == Globals.PlaneColor.StrawberryBanana)
            currPlane = StrawberryBanana;
        else if (currentPlaneColor == Globals.PlaneColor.Pretzel)
            currPlane = Pretzel;
        else if (currentPlaneColor == Globals.PlaneColor.Sherbet)
            currPlane = Sherbet;
        else if (currentPlaneColor == Globals.PlaneColor.Rainbow)
            currPlane = Rainbow;
        else if (currentPlaneColor == Globals.PlaneColor.Latte)
            currPlane = Latte;
        else if (currentPlaneColor == Globals.PlaneColor.RootBeer)
            currPlane = RootBeer;
        else if (currentPlaneColor == Globals.PlaneColor.Twinkie)
            currPlane = Twinkie;
        else if (currentPlaneColor == Globals.PlaneColor.Neo)
            currPlane = Neo;
        else if (currentPlaneColor == Globals.PlaneColor.Cocoa)
            currPlane = Cocoa;
        else if (currentPlaneColor == Globals.PlaneColor.Grape)
            currPlane = Grape;
        else if (currentPlaneColor == Globals.PlaneColor.Pickle)
            currPlane = Pickle;

        return currPlane;
    }
}
