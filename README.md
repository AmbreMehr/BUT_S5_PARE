# S5_C2_BPM²
Création d'une application client-serveur permettant la répartition des enseignements entre les enseignants et dans le temps pour aider à la réalisation du planning.

## Nom de l'application 
PARE : Programme d'Aide à la Répartition des Enseignements

## Fonctionnalités prévues
- Visualisation des ressources (modules) sur un planning 
- Attribution de profil type, qui permet d'attribuer des heures de services (heures prévues) à des enseignants
- Positionnement des ressources sur le planning 
- Visualisation d'alerte : 
  - Enseignants : alerte si 2x plus d'heures que prévues ; alerte si moins d'heures que prévues
  - Etudiants : alerte orange à 30h/semaine, alerte rouge à 35h/semaine
- Assignation d'une ressource à un enseignant -> devient responsable de la ressource
- Autorisation de visualisation différentes selon les rôles attribués
- Ajout d'un enseignant sur une ressource (avec ses heures assignés)
  
## Fonctionnalité implémenté au sprint 1 (alpha)
- Visualisation des ressources (modules) sur un planning

## Fonctionnalités implémentés au sprint 2 (beta)
- Positionnement des ressources sur le planning
- Assignation d'une ressource à un enseignant -> devient responsable de la ressource
- Ajout d'un enseignant sur une ressource (avec ses heures assignés) + suppression et mise à jour

## Technologies utilisés
Le client est fait en C# et WPF. 
Le serveur est une API Rest faite en C# avec ASP.NET CORE.
La base de données est en SQLite.
Un SDK 8.0 est utilisé.
Les packages installés sont :
- Microsoft.Data.Sqlite
- Microsoft.EntityFrameworkCore.Sqlite

## Version alpha - déployé
Lien vers le Serveur : https://10.128.207.64:8081/ 
Lien vers le Client : https://nextcloud.noctabou.win/index.php/s/xpgB3iijmpHiYG5 

## Version beta - déployé
Lien vers le Serveur : https://10.128.207.64:8081/ 
Lien vers le Client : https://nextcloud.noctabou.win/index.php/s/WGXZRByJRqDL962 