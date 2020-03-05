# What is this?
**tgKlixxBot** is a C# program which uses the Telegram API to enable playing live with *Verflixxte Klixx* on Rocket Beans TV. Feel free to drop in when it's Thursday yet again: @KlixxChat. Currently, multiple parallel matches are not supported, but this is planned for the future.

# Okay, so what do I do?
Watch Verflixxte Klixx and instead (or in addition to) entering your guesses on rocketbeans.tv, enter them into your Telegram chat with KlixxBot. There's a only a few commands you need:
## As a player...
 - /klixx <NUMBER>: Guess the Klixx.
 - /fischkarte: Place your Fischkarte. You can do this once per match for double points.
 - /undercover: Place your Undercoverkarte. One video per match is sent in by RBTV fans. If you guess correctly, you get 1 point bonus, whether you guessed besser or not.
 - /vk <PLAYER>: Nominate a player for Geierkönig. KlixxBot does this automatically if someone's guess is too similar to another person's.
 - /scores: Print the current scoreboard.
 - /kronen: Print the current crown standings.
 - /help: Print info on commands (in German. The whole thing is in German, I don't know why this readme isn't.)
 - /patchnotes: Print patchnotes for the current patch.
 - /patchnotes <PATCH>: Print notes for <PATCH>
 
## As gamemaster...
One player is the gamemaster. This player has a few additional duties, such as entering the truth, modifiers and making sure everything runs smoothly.
 - /start: Start the game.
 - /stop: End the game.
 - /wahr <NUMBER>: Enter the true view count.
 - /fix <NUMBER> <PLAYER>: Adjust <PLAYER>'s score by <NUMBER>.
 - /geierpoll: Start the poll for Geierkönig.
 - /florentin <NUMBER>: Enter Florentin's guess.
 - /lars <NUMBER>: Enter Lars' guess.
 - /de, /timecode, /nummer, /multi: Set modifiers.

# I want to compile this myself!
For tgKlixxBot to run, you'll need:
 - Newtonsoft.Json 12.0.2
 - RestSharp 106.6.9

Also, in the directory you compile tgKlixxBot into, you'll need two files:
 - kronenliste.json, where tgKlixxBot saves the highscore list.
 - botcode.txt, a text file containing the Telegram API code.