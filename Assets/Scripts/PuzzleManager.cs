using NUnit.Framework;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    [SerializeField] GameObject[] correctPieces;
    [SerializeField] GameObject[] allPieces;

    int filledPiece;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        
    }

    void FillPieces()
    {
        correctPieces[filledPiece].GetComponent<PuzzleElementBehavior>().FillSelf();
        if (filledPiece < correctPieces.Length - 1)
        {
            filledPiece++;
            Invoke("FillPieces", 0.5f);
        }
    }

    void DeactivatePieces()
    {
        for (int i = 0; i < allPieces.Length; i++)
        {
            allPieces[i].GetComponent<PuzzleElementBehavior>().DeactivateSelf();
        }
    }


}
