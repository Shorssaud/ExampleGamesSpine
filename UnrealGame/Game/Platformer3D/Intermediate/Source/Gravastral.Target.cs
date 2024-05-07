using UnrealBuildTool;

public class GravastralTarget : TargetRules
{
	public GravastralTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.V3;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Game;
		ExtraModuleNames.Add("Gravastral");
	}
}
