using UnityEngine;

public class NodeClickDetector : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Assume que existe apenas uma c�mera principal
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 � o bot�o esquerdo do mouse
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Node>() != null)
            {
                // Obt�m o componente Node do objeto clicado
                Node clickedNode = hit.collider.gameObject.GetComponent<Node>();
                // Chama o m�todo que lida com o clique no Node
                FindObjectOfType<UIController>().NodeClicked(clickedNode);
            }
        }
    }
}
