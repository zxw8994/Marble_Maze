using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUIManager : MonoBehaviour {

    public EditorControl editorControl;

    public GameObject tileButtonPanel;

    private Animator anim;

    private bool tilePanelUp;

	void Start () {
        anim = tileButtonPanel.GetComponent<Animator>();

        //anim.enabled = false;

        tilePanelUp = anim.GetBool("open");
	}

    public void TransitionTilePanel()
    {
        if (!tilePanelUp)
        {
            tilePanelUp = true;
            //anim.SetBool("open", tilePanelUp);
            //anim.enabled = true;

            //anim.Play("TileButtonSlideOut");
        } else if (tilePanelUp)
        {
            tilePanelUp = false;
            
            //anim.Play("TileButtonSlideIn");
        }

        anim.SetBool("open", tilePanelUp);
    }

}
