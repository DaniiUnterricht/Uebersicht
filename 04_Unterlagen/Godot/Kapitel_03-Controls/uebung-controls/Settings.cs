using Godot;


public partial class Settings : Control
{
	#region 2. CheckBox
	private CheckBox _fullscreenCheckBox = null!;
	#endregion


	#region 4. CheckButton
	private CheckButton _musicCheckButton = null!;
	#endregion


	#region 6. HSlider
	private HSlider _volumeSlider = null!;
	private Label _volumeValueLabel = null!;
	#endregion


	#region 9. OptionButton
	private OptionButton _resolutionOptionButton = null!;
	#endregion


	#region 13. LineEdit
	private LineEdit _playerNameLineEdit = null!;
	#endregion


	#region 15. ApplyButton
	private Button _applyButton = null!;
	private Label _statusLabel = null!;
    #endregion


    #region 19. Miniübung - Helligkeit
    private HSlider _brightnessSlider = null!;
    private Label _brightnessValueLabel = null!;
    #endregion


    #region 20. Zusatzaufgabe - Sprache
    private OptionButton _languageOptionButton = null!;
    #endregion

    public override void _Ready()
	{
		#region 2. CheckBox
		_fullscreenCheckBox = GetNode<CheckBox>("VBoxContainer/FullscreenCheckBox");
		#endregion


		#region 3. Toggled-Signal
		_fullscreenCheckBox.Toggled += OnFullscreenToggled;
		#endregion


		#region 4. CheckButton
		_musicCheckButton = GetNode<CheckButton>("VBoxContainer/MusicCheckButton");

		_musicCheckButton.Toggled += OnMusicToggled;
		#endregion


		#region 6. HSlider
		_volumeSlider = GetNode<HSlider>("VBoxContainer/VolumeSlider");

		_volumeValueLabel = GetNode<Label>("VBoxContainer/VolumeValueLabel");
		#endregion


		#region 7. ValueChanged-Signal
		_volumeSlider.ValueChanged += OnVolumeChanged;
		#endregion


		#region 9. OptionButton
		_resolutionOptionButton = GetNode<OptionButton>("VBoxContainer/ResolutionOptionButton");
		#endregion


		#region 10. Einträge hinzufügen
		_resolutionOptionButton.AddItem("1280 x 720");

		_resolutionOptionButton.AddItem("1920 x 1080");

		_resolutionOptionButton.AddItem("2560 x 1440");
		#endregion


		#region 11. ItemSelected-Signal
		_resolutionOptionButton.ItemSelected += OnResolutionSelected;
		#endregion


		#region 13. LineEdit
		_playerNameLineEdit = GetNode<LineEdit>("VBoxContainer/PlayerNameLineEdit");
		#endregion


		#region 14. TextChanged-Signal
		_playerNameLineEdit.TextChanged += OnPlayerNameChanged;
		#endregion


		#region 15. ApplyButton
		_applyButton = GetNode<Button>("VBoxContainer/ApplyButton");

		_statusLabel = GetNode<Label>("VBoxContainer/StatusLabel");

		_applyButton.Pressed += OnApplyButtonPressed;
		#endregion


		#region 19. Miniübung - Helligkeit
		_brightnessSlider = GetNode <HSlider> ("VBoxContainer/BrightnessSlider");

		_brightnessValueLabel = GetNode<Label>("VBoxContainer/BrightnessValueLabel");

        _brightnessSlider.ValueChanged += OnBrightnessChanged;
		#endregion


		#region 20. Zusatzaufgabe - Sprache

		_languageOptionButton = GetNode<OptionButton>("VBoxContainer/LanguageOptionButton");
        _languageOptionButton.AddItem("Deutsch");
        _languageOptionButton.AddItem("English");
        _languageOptionButton.ItemSelected += OnLanguageSelected;
        #endregion
    }


    #region 3. Toggled-Signal
    private void OnFullscreenToggled(bool toggledOn)
	{
		GD.Print($"Vollbild: {toggledOn}");
	}
	#endregion


	#region 4. CheckButton
	private void OnMusicToggled(bool toggledOn)
	{
		GD.Print($"Musik: {toggledOn}");
	}
	#endregion


	#region 7. ValueChanged-Signal
	private void OnVolumeChanged(double value)
	{
		_volumeValueLabel.Text = $"Lautstärke: {(int)value}";
	}
	#endregion


	#region 11. ItemSelected-Signal
	private void OnResolutionSelected(long index)
	{
		string resolution = _resolutionOptionButton.GetItemText((int)index);

        GD.Print($"Auflösung Index: {index}");
        GD.Print($"Auflösung: {resolution}");
	}
	#endregion


	#region 14. TextChanged-Signal
	private void OnPlayerNameChanged(string newText)
	{
		GD.Print($"Spielername: {newText}");
	}
	#endregion


	#region 16. Werte aus Controls auslesen
	private void OnApplyButtonPressed()
	{
		bool fullscreen = _fullscreenCheckBox.ButtonPressed;

		bool music = _musicCheckButton.ButtonPressed;

		int volume = (int)_volumeSlider.Value;

		string playerName = _playerNameLineEdit.Text;

		string resolution = _resolutionOptionButton.GetItemText(_resolutionOptionButton.Selected);

        #region Zusatzaufgaben
        int brightness = (int)_brightnessSlider.Value;

        string language = _languageOptionButton.GetItemText(_languageOptionButton.Selected);
        #endregion

        _statusLabel.Text =
			$"Name: {playerName}\n" +
			$"Vollbild: {fullscreen}\n" +
			$"Musik: {music}\n" +
			$"Lautstärke: {volume}\n" +
			$"Auflösung: {resolution}\n" +
            $"Helligkeit: {brightness}\n" +
            $"Sprache: {language}";
	}
	#endregion


	#region 19. Miniübung - Helligkeit
	private void OnBrightnessChanged(double value)
	{
		_brightnessValueLabel.Text = $"Helligkeit: {(int)value}";
	}
	#endregion


	#region 20. Zusatzaufgabe - Sprache
	private void OnLanguageSelected(long index)
	{
		string resolution = _languageOptionButton.GetItemText((int)index);
        GD.Print($"Sprache Index: {index}");
        GD.Print($"Sprache: {resolution}");
    }
    #endregion
}
