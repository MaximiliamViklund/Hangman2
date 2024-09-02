using System.Transactions;


//-----------------------------------------------Underscore Function----------------------------------------------------------
static string[] MakeUnderscores(string word){
    string[] underscores=new string[word.Length];
    for (int i = 0; i < underscores.Length; i++){
        underscores[i]="_";
        
    }
    return underscores; 
}


//----------------------------------------------------Variables----------------------------------------------------------------
List<char> wrongGuesses=new();
List<string> wordList=new();
int lives=5;
string word;
Random gen=new();


//--------------------------------------------------Add words here-------------------------------------------------------------
wordList.Add("flaggstångsknoppsmålarlärlingskolelevsmösstillverkarmaskinerireperatörsfackförbundsflagga");
wordList.Add("pneumonoultramicroscopicsilicovolcanoconiosis");
wordList.Add("fuck");
wordList.Add("motherfucker");
wordList.Add("dumbass");
wordList.Add("brainfuck");


//-----------------------------------------------Random Word Generator----------------------------------------------------------
word=wordList[gen.Next(0,wordList.Count)];
string[] hiddenWord=MakeUnderscores(word);


//-----------------------------------------------------The Game-----------------------------------------------------------------
Console.WriteLine("Välkomen till Hangman!");
Console.WriteLine("Gissa en bokstav!");
while(wrongGuesses.Count<lives&& string.Join("",hiddenWord)!=word){
    Console.WriteLine(string.Join(" ",hiddenWord));
    Console.Write("Wrong Guesses: ");
    Console.WriteLine("Lives left: "+lives);
    Console.WriteLine(string.Join(" ",wrongGuesses));
    string guess=Console.ReadLine().ToLower();
    if(guess==""){
        Console.WriteLine("You need to enter a guess.");
    }
    else if (guess!=null){
        if(word.Contains(guess[0])){
            Console.WriteLine("Yay");
            for (int i = 0; i < word.Length; i++){
                if(word[i]==guess[0]){
                hiddenWord[i]=guess[0].ToString();
                }
            }
        }
        else{
            Console.WriteLine("Wrong");
            wrongGuesses.Add(guess[0]);
        }
    }
}
if(wrongGuesses.Count>=lives){
    Console.WriteLine();
    Console.WriteLine("Game Over");
    Console.WriteLine("The word was "+word);
    Console.ReadLine();
}
else if(string.Join("",hiddenWord)==word){
    Console.WriteLine();
    Console.WriteLine("Congrats you won!");
    Console.WriteLine("The word was "+word);
    Console.ReadLine();
}