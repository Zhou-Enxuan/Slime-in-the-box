using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackNumber : MonoBehaviour
{
    public MonsterBehaviour monster;

    private Player player;

    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CalculateSize()
    {
        if (player.size >= monster.data.size)
            textMesh.text = "+" + (player.size - monster.data.size).ToString();
        else
            textMesh.text = "-" + (monster.data.size - player.size).ToString();
    }
}
