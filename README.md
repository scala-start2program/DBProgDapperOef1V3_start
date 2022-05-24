# DB Programmeren - DAPPER   
  
# Oefening geszelschapsspelen Versie 3   
  
## Voorbereiding    
  
Je hoeft aan je database niets te wijzigen.
  
## Opdracht   
  
De starterscode is identiek aan de oplossing van versie 2.  
Het enige wat je in deze versie moet doen is zorgen voor data encapsulatie binnen de klasse **Spel** :   
 * **Titel** mag niet leeg zijn : je gooit een fout op indien nodig  
 * **MinimumLeeftijd** mag niet kleiner zijn dan 0 : je wijzigt een negatieve waarde naar 0  
 * **MaximumSpelers** mag niet kleiner zijn dan 0 : je wijzigt een negatieve waarde naar 0  
 * **Spelduur** mag niet kleiner zijn dan 0 en niet groter dan 500 : je past foutieve waarden zelf aan naar 0 of 500  

Pas uiteraard ook je Code Behind aan zodat rekening gehouden wordt met deze data encapsulatie.  
Zorg er zeker ook voor dat de gebruiker, wanneer een nieuw spel toevoegt, zeker een categorie moet kiezen.  
