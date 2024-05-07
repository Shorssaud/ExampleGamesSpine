# Documentation de l'API

## Introduction

Cette API fournit des fonctionnalités pour gérer les statistiques de jeux, y compris l'ajout de nouvelles sessions de jeu, la récupération de sessions de jeu existantes, l'ajout de statistiques, achievment et erreurs à une session de jeu, ainsi que la suppression de sessions de jeu.

## Instructions d'utilisation

Pour utiliser cette API, vous devez envoyer des requêtes HTTP aux différentes routes spécifiées ci-dessous. Assurez-vous d'inclure les données nécessaires dans le corps de la requête au format JSON et pour toute les requetes put et post assurez vous d'ajouter les headers nécessaire `content-type application/json` et `x-api-key 'your api key'`.

## Routes

### Ajout d'une nouvelle session de jeu

- **Route**: `POST /statistics/newSession`
- **Description**: creation d'une nouvelle session de jeu.
- **Exemple de corps de requête**:
```json
  {
    "gameId": "12345"
  }
```
- **Réponse réussie (status 201)**:
```json
{
    "sessionId": "abcde12345"
}
```
### Récupération d'une session de jeu

- **Route**: `GET /statistics/gameSession/:uid`
- **Description**: Récupère une session de jeu à partir de l'identifiant unique (uid) spécifié.
- **Réponse réussie (status 200)**: Le corps de la réponse contient les détails de la session de jeu.

### Récupération de toutes les sessions de jeu

- **Route**: `GET /statistics/gameSessions`
- **Description**: Récupère toutes les sessions de jeu en fonction des paramètres de requête spécifiés.
- **Exemple de paramètres de requête**: `?gameId=12345`
- **Réponse réussie (status 200)**: Le corps de la réponse contient un tableau de toutes les sessions de jeu correspondantes.

### Ajout d'une statistique à une session de jeu

- **Route**: `PUT /statistics/:uid/newStat`
- **Description**: Ajoute une nouvelle statistique à une session de jeu spécifiée par son identifiant unique (uid).
- **Exemple de corps de requête**:
```json
{
    "title": "Score",
    "value": 1000
}
  ```
  - **Réponse réussie (status 201):**
```json 
{
    "message": "Statistic added successfully"
}
```
### Ajout d'un Achievement à une session de jeu

- **Route**: `PUT /statistics/:uid/newAchievement`
- **Description**: Ajoute un Achievement à une session de jeu spécifiée par son identifiant unique (uid).
- **Exemple de corps de requête**:

```json
{
    "title": "Première victoire",
    "description": "A remporté la première partie"
}
```
 - **Réponse réussie (status 201)**:

```json 
{
    "message": "Achievement added successfully"
}
```
### Ajout d'une erreur à une session de jeu

- **Route**: `PUT /statistics/:uid/newError`
- **Description**: Ajoute une nouvelle erreur à une session de jeu spécifiée par son identifiant unique (uid).
- **Exemple de corps de requête**:
```json
{
    "title": "Erreur critique",
    "description": "Erreur lors de la sauvegarde des données"
}
```
### Réponse réussie (status 201):
```json
{
    "message": "Error added successfully"
}
```
### Suppression d'une session de jeu

- **Route**: `DELETE /statistics/:uid`
- **Description**: Supprime une session de jeu spécifiée par son identifiant unique (uid).
- **Réponse réussie (status 200)**: Le corps de la réponse contient :
```json
{
    "message": "Game session deleted"
}
```
### Suppression de plusieurs sessions de jeu

- **Route**: `DELETE /statistics`
- **Description**: Supprime plusieurs sessions de jeu en fonction des paramètres de requête spécifiés.
- **Exemple de paramètres de requête**: `?gameId=12345`
- **Réponse réussie (status 200)**: Le corps de la réponse contient :
```json
{
    "message": "Game sessions deleted"
}
```
### Schéma d'erreur

- **title**: string (obligatoire)
- **description**: string
- **log**: string
- **timestamp**: string (format: date-time, par défaut: date et heure actuelles)

### Schéma de réalisation

- **title**: string (obligatoire)
- **description**: string
- **timestamp**: string (format: date-time, par défaut: date et heure actuelles)

### Schéma de statistique

- **title**: string (obligatoire)
- **description**: string
- **value**: number or string (obligatoire)
- **timestamp**: string (format: date-time, par défaut: date et heure actuelles)

### Schéma de session de jeu

- **gameId**: string (obligatoire)
- **statistics**: tableau d'objets (éléments suivant le schéma de statistique)
- **achievements**: tableau d'objets (éléments suivant le schéma de réalisation)
- **errors**: tableau d'objets (éléments suivant le schéma d'erreur)