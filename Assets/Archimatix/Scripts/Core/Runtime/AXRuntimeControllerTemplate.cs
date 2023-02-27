﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using AX;


public class AXRuntimeControllerTemplate : AXRuntimeControllerBase {


	// Interface between AXParameters and dynamic variables visible 
	// to runtime systems such as Unities UI and PlayMaker, etc.

	// This code features a section that is automatically generated byt a button in the Inspector for an AXModel.
	// The code will:
	//     1. Define AXParameter references
	//     2. Define Dynamic Variables.
	//     3. Create an initialization function to set references to the AXParameters, 
	//        which are used by the Dynamic variables. 




	// Do not edit the code in the following region by hand. 

	#region AUTO_GENERATED AX BINDINGS

	// *** PARAMETER_REFERENCES_DEFINITION *** //

	// *** PARAMETER_REFERENCES_DEFINITION *** //



	// *** DYNAMIC_VARIABLES *** //

	// *** DYNAMIC_VARIABLES *** //



	// *** PARAMETER_REFERENCE_INIT *** //

	protected override void InitializeParameterReferences()
	{
	}

	// *** PARAMETER_REFERENCE_INIT *** //


	#endregion

	// Outside of the above automatically generated region, you can add any code you like.





	// The Start function must be present and 
	// must call the base class InitializeController function
	// for this controller to work properly.
	void Start()
	{
		InitializeController();

		// Other optional initializatin code here...

	}


	// Update is called once per frame.
	// Here you can simply call out any of the dynamic variables defined above.

	void Update () {

		// Any game specific code that sets or gets the width in the course of player events.



		// Final step in Update: Let the model know if a parameter has been reset
		if (parameterWasAltered)
		{
			parameterWasAltered = false;
			if (model != null)
				model.isAltered();
		}

	}



}