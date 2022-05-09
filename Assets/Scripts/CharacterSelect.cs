using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    SceneManager sceneManager;

    [SerializeField]
    GameObject[] Planes = new GameObject[30];
    [SerializeField]
    Image CurrentPlane;
    [SerializeField]
    TextMeshProUGUI PlaneName;

    [SerializeField]
    Transform DragContainer;

    float minX = 0;
    float maxX = 0;
    int maxItems = 30;
    int currentPlane = 0;
    float planeInstanceXInterval = 250f;
    private float lastDragPos;
    float scaleFactor;

    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        scaleFactor = this.GetComponent<Canvas>().scaleFactor;
        maxX = Camera.main.scaledPixelWidth / 2 - planeInstanceXInterval / 2;
        minX = maxX - planeInstanceXInterval * scaleFactor * (maxItems - 1);
        DragContainer.position = new Vector3(maxX, DragContainer.position.y, DragContainer.position.z);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPos = eventData.position.x;
    }

    // Drag the selected item.
    public void OnDrag(PointerEventData data)
    {
        float dragOffset = lastDragPos - data.position.x;
        lastDragPos = data.position.x;
        float newX = DragContainer.position.x - dragOffset;
        newX = Mathf.Max(minX, newX);
        newX = Mathf.Min(maxX, newX);
        DragContainer.position = new Vector3(newX, DragContainer.position.y, DragContainer.position.z);

        float indexDelta = maxX + planeInstanceXInterval / 2 - newX;
        int newPlaneIndex = (int)Mathf.Floor(indexDelta / (planeInstanceXInterval * scaleFactor));
        updateCurrentPlane(newPlaneIndex);
    }

    void updateCurrentPlane(int newPlaneIndex)
    {
        if (newPlaneIndex != currentPlane && newPlaneIndex < Planes.Length)
        {
            Planes[currentPlane].SetActive(true);
            currentPlane = newPlaneIndex;
            Planes[currentPlane].SetActive(false);
            CurrentPlane.sprite = Planes[currentPlane].GetComponent<Image>().sprite;
            PlaneName.text = Globals.GetPlaneNameFromColor((Globals.PlaneColor)currentPlane);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag: " + eventData.position.x);
    }

    public void SelectCurrentPlane()
    {
        sceneManager.SelectPlaneButton(currentPlane);
    }
}
