using UnityEngine;

public class BoostsReader : MonoBehaviour
{
    public TextAsset textBoostList;

    [System.Serializable]
    public class Boost
    {
        public int boostID;
        public string boostNome;
        public string categoria;
        public float boostValue;
        public string boostArea;
    }

    [System.Serializable]
    public class BoostList
    {
        public Boost[] boost;
    }

    public BoostList myBoostList = new BoostList();

    void Start()
    {
        myBoostList = JsonUtility.FromJson<BoostList>(textBoostList.text);
        
    }
}