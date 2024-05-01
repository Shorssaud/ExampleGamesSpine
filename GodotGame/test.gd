extends Node

var spineAnalyticsAPI: SpineAnalyticsAPI

func _ready():
	spineAnalyticsAPI = SpineAnalyticsAPI.new()
	spineAnalyticsAPI.initialize("your_api_key", "2")

func _process(_delta: float):
	if Input.is_action_pressed("ui_accept"):
		add_error_to_game_session()

func add_error_to_game_session() -> void:
	var errorData := ErrorData.new()
	errorData.title = "Error Title"
	errorData.description = "Error Description"
	errorData.log = "Error Log"

	spineAnalyticsAPI.gameSessionData.errors.append(errorData)
	spineAnalyticsAPI.send_session(spineAnalyticsAPI.gameSessionData)
