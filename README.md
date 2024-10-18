# S5_C2_BPM²
Création d'une application client-serveur permettant la répartition des enseignements entre les enseignants et dans le temps pour aider à la réalisation du planning.

## Nom de l'application 
PARE : Programme d'Aide à la Répartition des Enseignements

## Fonctionnalités prévues
- Visualisation des ressources (modules) sur un planning 
- Visualisation des ressources non positionnés 
- Attribution de profil type, qui permet d'attribuer des heures de services (heures prévues) à des enseignants
- Positionnement des ressources sur le planning 
- Visualisation d'alerte : 
  - Enseignants : alerte si 2x plus d'heures que prévues ; alerte si moins d'heures que prévues
  - Etudiants : alerte orange à 30h/semaine, alerte rouge à 35h/semaine
- Assignation d'une ressource à un enseignant -> devient responsable de la ressource
- Autorisation de visualisation différentes selon les rôles attribués

## Technologies utilisés
Le client est fait en C# et WPF. 
Le serveur est une API Rest faite en C# avec ASP.NET CORE.
La base de données est en SQLite.