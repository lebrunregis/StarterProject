using Facts.Runtime;
using SaveSystem.Runtime;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    #region Publics
    #endregion

    #region Unity Api

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnEnable()
    {
        Fact<bool> bite = new(true);
        Fact<string> nom = new("John");
        GameFactsStorage.booleans.CreateFact(0, bite);
        GameFactsStorage.strings.CreateFact(0, nom);
        string json = JsonUtility.ToJson(GameFactsStorage.booleans);
    }

    private void OnDisable()
    {

    }

    #endregion


    #region Main Methods

    #endregion


    #region Utils

    #endregion


    #region Private and Protected

    #endregion


}
