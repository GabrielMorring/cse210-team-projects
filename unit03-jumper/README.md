# Design
Classes:
    Terminal Service 
    Director
    Jumper
    Word

Terminal Service Responsibilities:
    get input from user
    Show outputs from the game
Terminal Service Method GetInput(string prompt) returns string
Terminal Service Method WriteText(string text) returns void


Director Responsibilities:
    Control game play by
    uses word to get a randomm word and stores it
    uses terminal service to get user guesses
    compares guess to secret word
    if it's wrong it updates the Jumper to lose a cord
    if it is right it update a user guess variable
    
Jumper responsibilities:
    Keep track of parachute
    Keep track of if person is alive
Jumper Attribute of parchuteLives int
Jumper Method of checkAlive() returns bool
Jumper UpdateLives() return void subtracts one live from parachuteLives
Jumper method GetParachuteLives() retuns int parachuteLives

Word responsibilities:
    return a random word    
Word Method GetRandomWord() Returns string

    