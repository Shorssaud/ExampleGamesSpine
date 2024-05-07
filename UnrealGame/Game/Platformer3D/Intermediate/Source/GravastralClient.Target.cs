using UnrealBuildTool;

public class GravastralClientTarget : TargetRules
{
	public GravastralClientTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.V3;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Client;
		ExtraModuleNames.Add("Gravastral");
	}
}
