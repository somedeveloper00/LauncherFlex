static class GlobalInput
{
	public static MainNav mainNav = new MainNav();

	public static void EnableOverlay()
	{
		mainNav.Overlay.Enable();
		mainNav.Main.Disable();
	}
	public static void DisableOverlay()
	{
		mainNav.Overlay.Disable();
		mainNav.Main.Enable();
	}
}