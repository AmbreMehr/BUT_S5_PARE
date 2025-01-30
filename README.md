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
  - Etudiants : alerte orange à moins de 30h/semaine, alerte rouge à 35h/semaine
- Assignation d'une ressource à un enseignant -> devient responsable de la ressource
- Autorisation de visualisation différentes selon les rôles attribués
- Ajout d'un enseignant sur une ressource (avec ses heures assignés)
  
## Fonctionnalité implémenté au sprint 1 (alpha)
- Visualisation des ressources (modules) sur un planning

## Fonctionnalités implémentés au sprint 2 (beta)
- Positionnement des ressources sur le planning
- Assignation d'une ressource à un enseignant -> devient responsable de la ressource
- Ajout d'un enseignant sur une ressource (avec ses heures assignés) + suppression et mise à jour

##  Fonctionnalités implémentés au sprint 3 (release)
- Visualisation de la charge étudiante par semaine
- Bilan des alertes : visualisation de la charge des enseignants (heures réelles) par rapport à leurs heures totales assignées + alertes pour les étudiants ayant plus de 35h/semaine ou moins de 30h/semaine.
- Ajustements des fonctionnalités de la beta :
  - Modification des textes de bouton de la plupart des fenêtres "Quitter" "Sauvegarder" et modification de la redirection, sauvegarder reste sur la fenêtre actuelle et quitter ferme sans enregistrer
  - Modification des boutons de paramètres : avant 2 boutons, maintenant plus que le bouton "Quitter" les modifications sont automatiquement sauvegardé
  - Prise en compte du changement de semaine selon le semestre (+ les semaines sont ajoutés dynamiquement côté IHM)
  - Sur l'édition de module (assignation d'un module à un/des enseignant(s)) : ajout d'une indication pour savoir si toutes les heures au programme ont été attribué (couleur sur les heures au programme)

## Technologies utilisés
Le client est fait en C# et WPF. 
Le serveur est une API Rest faite en C# avec ASP.NET CORE.
La base de données est en SQLite.
Un SDK 8.0 est utilisé.
Les packages installés sont :
- Microsoft.Data.Sqlite
- Microsoft.EntityFrameworkCore.Sqlite
