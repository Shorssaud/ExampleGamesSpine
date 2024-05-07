using UnrealBuildTool;

public class GravastralServerTarget : TargetRules
{
	public GravastralServerTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.V3;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Server;
		ExtraModuleNames.Add("Gravastral");
	}
}
