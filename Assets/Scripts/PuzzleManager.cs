using NUnit.Framework;
using UnityEngine;
using Unity.Cinemachine;

public class PuzzleManager : MonoBehaviour
{

    [SerializeField] GameObject[] correctPieces;
    [SerializeField] GameObject[] allPieces;
    [SerializeField] GameObject outPiece;
    [SerializeField] Material outPieceMaterial;
    [SerializeField] GameObject pieceHighlight;
    [SerializeField] GameObject player;
    [SerializeField] CinemachineCamera puzzleCamera;
    [SerializeField] GameObject PuzzleStarter;

    int filledPiece;
    int pieceHighlightX;
    int pieceHighlightY;
    GameObject[,] gridPieces = new GameObject[3,3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player.SetActive(false);

        int columnNum = 0;
        for(int i = 0; i < allPieces.Length; i++)
        {
            gridPieces[columnNum, i % 3] = allPieces[i];
            if (i == 2 || i == 4) columnNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0)) {

            int correctCount = 0;
            for (int i = 0; i < correctPieces.Length; i++)
            {
                if (correctPieces[i].GetComponent<PuzzleElementBehavior>().currentPosition == correctPieces[i].GetComponent<PuzzleElementBehavior>().correctPosition) {
                    correctCount++;
                }
            }
            if (correctCount == correctPieces.Length) {
                DeactivatePieces();
                FillPieces();
            }
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            pieceHighlightY += 1;
            if(pieceHighlightY > 2) pieceHighlightY = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            pieceHighlightY -= 1;
            if (pieceHighlightY < 0) pieceHighlightY = 2;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pieceHighlightX += 1;
            if (pieceHighlightX > 2) pieceHighlightX = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            pieceHighlightX -= 1;
            if (pieceHighlightX < 0) pieceHighlightX = 2;
        }

        pieceHighlight.transform.position = gridPieces[pieceHighlightX, pieceHighlightY].transform.position;

    }

    void FillPieces()
    {
        correctPieces[filledPiece].GetComponent<PuzzleElementBehavior>().FillSelf();
        if (filledPiece < correctPieces.Length - 1)
        {
            filledPiece++;
            Invoke("FillPieces", 0.5f);
        } else
        {
            Invoke("EndPuzzle", 0.5f);
        }
    }

    void DeactivatePieces()
    {
        for (int i = 0; i < allPieces.Length; i++)
        {
            allPieces[i].GetComponent<PuzzleElementBehavior>().DeactivateSelf();
        }
    }

    void EndPuzzle()
    {
        outPiece.GetComponent<MeshRenderer>().material = outPieceMaterial;
        puzzleCamera.Priority = 0;
        PuzzleStarter.SetActive(false);
        player.SetActive(true);
    }


}
