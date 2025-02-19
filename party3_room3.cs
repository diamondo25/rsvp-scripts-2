using WvsBeta.Game;
using WvsBeta.Game.GameObjects;
using WvsBeta.Common;

public class Portal : IScriptV2
{
	private PartyData Party => PartyData.Parties[chr.PartyID];
	private FieldSet FieldSet => chr.Field.ParentFieldSet;
	private bool IsLeader => Party.Leader == chr.ID;
	
	public override void Run()
	{
		if (GetFieldsetVar("Party5", "stage4") == "clear")
		{
			Message("There is nothing left to do in this room.");
			return;
		}
		
		if (IsLeader)
		{
			FieldSet.Characters.ForEach(character =>
			{
				Message(character, "The party leader entered the <Lobby>.");
			});
			
			MapPacket.PlayPortalSE(chr);
			ChangeMap(920010400, "st00");
		}
		else
		{
			if (UserCount(920010400) >= 1)
			{
				MapPacket.PlayPortalSE(chr);
				ChangeMap(920010400, "st00");
			}
			else
			{
				Message("You can only enter locations where you'll find the party leader.");
			}
		}
	}
}