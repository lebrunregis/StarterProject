using Facts.Runtime;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    #region Publics
        
    #endregion
        
        
    #region Unity Api
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
		
        void OnEnable()
        {
        Fact<bool> bite = new(true);
        Fact<string> nom = new("John");
        GameManager.m_gameFactsBoolean.CreateOrUpdateFact("bite", bite);
        GameManager.m_gameFactsStrings.CreateOrUpdateFact(name,nom);
        string json = JsonUtility.ToJson(GameManager.m_gameFactsBoolean);
    }
		
        void OnDisable()
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
