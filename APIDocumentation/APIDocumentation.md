# API Documentation

## Introduction

This API provides functionalities for managing game statistics, including adding new game sessions, retrieving existing game sessions, adding statistics, achievements, and errors to a game session, as well as deleting game sessions.

## Usage Instructions

To use this API, you need to send HTTP requests to the different routes specified below. Make sure to include the necessary data in the request body in JSON format and for all PUT and POST requests make sure to add the required headers `content-type application/json` and `x-api-key 'your api key'`.

## Routes

### Adding a New Game Session

- **Route**: `POST /statistics/newSession`
- **Description**: Creates a new game session.
- **Example Request Body**:
```json
{
    "gameId": "12345"
}
```
- **Successful Response (status 201)**:
```json
{
    "sessionId": "abcde12345"
}
```
### Retrieving a Game Session

- **Route**: `GET /statistics/gameSession/:uid`
- **Description**: Retrieves a game session based on the specified unique identifier (uid).
- **Successful Response (status 200)**: The response body contains the details of the game session.

### Retrieving All Game Sessions

- **Route**: `GET /statistics/gameSessions`
- **Description**: Retrieves all game sessions based on the specified query parameters.
- **Example Request Headers**: `?gameId=12345`
- **Successful Response (status 200)**: The response body contains an array of all matching game sessions.

### Adding a Statistic to a Game Session

- **Route**: `PUT /statistics/:uid/newStat`
- **Description**: Adds a new statistic to a game session specified by its unique identifier (uid).
- **Example Request Body**:
```json
{
    "title": "Score",
    "value": 1000
}
  ```
  - **Successful Response (status 201):**
```json 
{
    "message": "Statistic added successfully"
}
```
### Adding an Achievement to a Game Session

- **Route**: `PUT /statistics/:uid/newAchievement`
- **Description**: Adds an achievement to a game session specified by its unique identifier (uid).
- **Example Request Body**:

```json
{
    "title": "Première victoire",
    "description": "A remporté la première partie"
}
```
 - **Successful Response (status 201)**:

```json 
{
    "message": "Achievement added successfully"
}
```
### Adding an Error to a Game Session

- **Route**: `PUT /statistics/:uid/newError`
- **Description**: Adds a new error to a game session specified by its unique identifier (uid).
- **Example Request Body**:
```json
{
    "title": "Erreur critique",
    "description": "Erreur lors de la sauvegarde des données"
}
```
  - **Successful Response (status 201):**:
```json
{
    "message": "Error added successfully"
}
```
### Deleting a Game Session

- **Route**: `DELETE /statistics/:uid`
- **Description**: Deletes a game session specified by its unique identifier (uid).
- **Successful Response (status 200)**: The response body contains :
```json
{
    "message": "Game session deleted"
}
```
### Deleting Multiple Game Sessions

- **Route**: `DELETE /statistics`
- **Description**: Deletes multiple game sessions based on the specified query parameters.
- **Example Request Parameters**: `?gameId=12345`
- **Successful Response (status 200)**: The response body contains :
```json
{
    "message": "Game sessions deleted"
}
```
### Error Schema

- **title**: string (required)
- **description**: string
- **log**: string
- **timestamp**: string (format: date-time, default: current date and time)

### Achievement Schema

- **title**: string (required)
- **description**: string
- **timestamp**: string (format: date-time, default: current date and time)

### Statistic Schema

- **title**: string (required)
- **description**: string
- **value**: number or string (required)
- **timestamp**: string (format: date-time, default: current date and time)

### Game Session Schema

- **gameId**: string (required)
- **statistics**: array of objects (elements following the statistic schema)
- **achievements**: array of objects (elements following the achievement schema)
- **errors**: array of objects (elements following the error schema)
___
