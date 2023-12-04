/****************************************
* eternal quest -- set and complete goals *
* Author: Bobby Hamblin			*
*   <hamblingreen@hotmail.com>		*
* Purpose: Demonstate an application of	*
*   polymorphism			*
* Usage: Select option at menu		*
****************************************/

using System;

class Program
{
	static void Main(string[] args)
	{
		// Create new Goal Manager
		GoalManager goalManager = new GoalManager();

		// Run program
		goalManager.Start();
	}
}
