using WvsBeta.Game;

// 2040026 Third Eos Rock, 41st Floor
public class NpcScript : IScriptV2
{
	private void Teleport(int npc, int map, string floor)
	{
		bool teleport = AskYesNo($"You can use the #b#t4001020##k to activate the #b#p2040026##k. Will you teleport to #b#p{npc}##k on the {floor} floor?");
		
		if (teleport)
		{
			if (!Exchange(0, 4001020, -1))
			{
				self.say("You cannot activate the #b#p2040026##k without #b#t4001020##k.");
				return;
			}
			
			ChangeMap(map, "go00");
		}
	}
	
	public override void Run()
	{
		if (ItemCount(4001020) < 1)
		{
			self.say("There's a rock that allows you to teleport to #b#p2040025# or #p2040027##k, but it cannot be activated without the scroll.");
			return;
		}
		
		int option = AskMenu("You can use the #b#t4001020##k to activate the #b#p2040026##k. Which of these rocks would you like to teleport to?#b",
			(0, " #p2040025#(71st floor)"),
			(1, " #p2040027#(1st floor)"));
		
		switch(option)
		{
			case 0: Teleport(2040025, 221022900, "71st"); break;
			case 1: Teleport(2040027, 221020000, "1st"); break;
		}
	}
}