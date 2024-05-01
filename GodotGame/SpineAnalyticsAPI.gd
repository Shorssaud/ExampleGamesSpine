extends Node

# Define custom data structures
class_name SpineAnalyticsAPI

# Define ErrorData structure
class ErrorData:
	var title: String
	var description: String
	var log: String
	var timestamp: String

	func _init():
		timestamp = OS.get_datetime().to_string()

# Define AchievementData structure
class AchievementData:
	var title: String
	var description: String
	var timestamp: String

	func _init():
		timestamp = OS.get_datetime().to_string()

# Define StatisticData structure
class StatisticData:
	var title: String
	var description: String
	var value: Variant # Accepts either string or number
	var timestamp: String

	func _init():
		timestamp = OS.get_datetime().to_string()

# Define GameSessionData structure
class GameSessionData:
	var gameId: String
	var statistics: Array
	var achievements: Array
	var errors: Array

	func _init():
		statistics = []
		achievements = []
		errors = []

# Define SpineAnalyticsAPI class
class SpineAnalyticsAPI:
	var baseUrl: String = "https://app-ekrmeoi24a-uc.a.run.app"
	var apiKey: String
	var gameId: String
	var gameSessionData: GameSessionData

	func initialize(_apiKey: String, _gameId: String) -> void:
		apiKey = _apiKey
		gameId = _gameId
		gameSessionData = GameSessionData.new()

	func send_session(data: GameSessionData) -> void:
		var url := "%s/statistics/newSession" % baseUrl
		data.gameId = gameId

		var request := HTTPRequest.new()
		request.connect("request_completed", self, "_on_request_completed")
		request.request(url, [], true, HTTPClient.METHOD_POST, JSON.print(data))
		await(request, "completed")

		if request.get_response_code() == 200:
			var responseText := request.get_response_body_as_text()
			print(responseText)
		else:
			print("Error: ", request.get_error())
