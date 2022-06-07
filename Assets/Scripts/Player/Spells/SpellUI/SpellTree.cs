using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellTree : SpellHolder
{
    [SerializeField] private Image[] icons;
    [SerializeField] private Image[] activeSkills;
    [SerializeField] private GameObject descriptionBox;
    [SerializeField] private GameObject skillBox;
    [SerializeField] private TMP_InputField slot;
    [SerializeField] private TextMeshProUGUI spellName;
    [SerializeField] private TextMeshProUGUI description;  
    private static int selectedSkill;
    private bool changed = true;
    
    

    // Start is called before the first frame update
    protected void Start()
    {
       
        
        for (int i = 0; i < spells.Length; i++)
        {
            icons[i].sprite = spells[i].GetComponent<SpriteRenderer>().sprite;
        }

        UpdateSkills();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        UpdateSkills();
    }

    void UpdateSkills()
    {
        if (changed)
        {
            for (int i = 0; i < activeSpells.Length; i++)
            {
                activeSkills[i].GetComponent<Image>().enabled = true;
                if (activeSpells[i] != null)
                {
                    activeSkills[i].sprite = activeSpells[i].GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    activeSkills[i].GetComponent<Image>().enabled = false;
                }
            }
            changed = false;
        }
    }

    private string SkillDescription(int num) 
    {
        Spell spellParent = spells[num];
        string description = "";
        description += spellParent.spell.description + "\nStats:\nDamage: " + spellParent.spell.damage + 
            "\nActive: " + spellParent.spell.activeTime + "\nCooldown: " + spellParent.spell.cooldownTime
            + "\nSpeed: " + spellParent.spell.speed + "\nPrerequisite: " + spellParent.spell.prerequisite;
        return description;
    }
    public void ShowDescription(int num)
    {
        if (!skillBox.activeInHierarchy)
        {
            descriptionBox.SetActive(true);
        }
             
        
        if (!IsUnlocked(num))
        {
            spellName.color = Color.red;
            spellName.text = spells[num].spell.spellName + " (locked)";
        } else
        {
            spellName.text = spells[num].spell.spellName;
        }
        description.text = SkillDescription(num);
    }

    public void CloseDescription()
    {
        descriptionBox.SetActive(false);
    }

    public void ShowSkillSelection(int num)
    {
        
        selectedSkill = num;
        if (IsUnlocked(selectedSkill))
        {
            descriptionBox.SetActive(false);
            skillBox.SetActive(true);           
        }
    }

    public void CloseSkillSelection()
    {
        skillBox.SetActive(false);
        selectedSkill = -1;
    }

    public void SelectSkill()
    {
        if (SetActiveSpell(int.Parse(slot.text), selectedSkill))
        {
            changed = true;
        }
    }

    public void RemoveSkill()
    {
        if (RemoveActiveSpell(selectedSkill))
        {
            changed = true;
        }
    }
}