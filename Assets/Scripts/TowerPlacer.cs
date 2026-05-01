using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    public Camera mainCamera;

    private GameObject previewTower;
    private bool canPlace = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previewTower = Instantiate(towerPrefab);
            canPlace = false; // reset
        }

        if (Input.GetMouseButton(0) && previewTower != null)
        {
            MovePreview();
        }

        if (Input.GetMouseButtonUp(0) && previewTower != null)
        {
            if (canPlace)
            {
                Debug.Log("Placed successfully");
                previewTower = null; // keep it
            }
            else
            {
                Debug.Log("Invalid placement");
                Destroy(previewTower);
            }
        }
    }

    void MovePreview()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        int groundLayer = LayerMask.GetMask("Ground");

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
        {
            Vector3 pos = hit.point;

            pos.x = Mathf.Round(pos.x);
            pos.z = Mathf.Round(pos.z);

            previewTower.transform.position = pos;

            canPlace = true;
        }
        else
        {
            canPlace = false;
        }
    }
}