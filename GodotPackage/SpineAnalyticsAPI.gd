extends Node
class ErrorData:
	var title: String
	var description: String
	var log: String
	var timestamp: String

	# Class method to return dictionary of class properties
	func get_serializable_properties() -> Dictionary:
		var properties = {
			"title": title,
			"description": description,
			"log": log,
			"timestamp": timestamp
		}
		return properties

class AchievementData:
	var title: String
	var description: String
	var timestamp: String

	# Class method to return dictionary of class properties
	func get_serializable_properties() -> Dictionary:
		var properties = {
			"title": title,
			"description": description,
			"timestamp": timestamp
		}
		return properties

class StatisticData:
	var title: String
	var description: String
	var value: String
	var timestamp: String

	# Class method to return dictionary of class properties
	func get_serializable_properties() -> Dictionary:
		var properties = {
			"title": title,
			"description": description,
			"value": value,
			"timestamp": timestamp
		}
		return properties

class GameSessionData:
	var gameId: String
	var statistics: Array = []
	var achievements: Array = []
	var errors: Array = []

	# Class method to return dictionary of class properties
	func get_serializable_properties() -> Dictionary:
		var properties = {
			"gameId": gameId,
			"statistics": statistics,
			"achievements": achievements,
			"errors": errors
		}
		return properties

class SessionResponse:
	var sessionId: String

var baseUrl: String = "https://app-ekrmeoi24a-uc.a.run.app"
var apiKey: String
var devId: String
var sessionId: String
var gameSessionData: GameSessionData = GameSessionData.new()

func initialize(_ApiKey: String, _gameId: String, _devId) -> void:
	apiKey = _ApiKey
	gameSessionData.gameId = _gameId
	devId = _devId

# Method to add a game session
func send_session() -> void:
	var url: String = "%s/statistics/newSession" % baseUrl
	var headers: PackedStringArray = (["dev-api-key: " + apiKey, "content-type: application/json", "user-id: " + devId])
	var body = JSON.stringify(gameSessionData.get_serializable_properties())
	var request = HTTPRequest.new()
	add_child(request)
	request.request_completed.connect(self._http_request_completed)
	
	var error = request.request(url, headers, HTTPClient.METHOD_POST, body)
	if error != OK:
		push_error("An error occurred in the HTTP request. " + str(error))


func _http_request_completed(result, response_code, headers, body):
	if response_code != HTTPRequest.RESULT_SUCCESS:
		push_error("Error: " + body.get_string_from_utf8())
		return

	var response_data = JSON.parse_string(body.get_string_from_utf8())
	sessionId = response_data.sessionId

