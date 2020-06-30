using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace tgKlixxBot
{
    class Program
    {
        const string FISCHKARTE1 = "CAADAgADHQAD0OMSJfSJfsT8qWA8Ag";
        const string FISCHKARTE2 = "CAADAgADIgAD0OMSJd26KQVp04LxAg";
        const string FISCHKARTE3 = "CAADAgADIAAD0OMSJYaEC7hAqnKLAg";
        const string SENFKARTE = "CAACAgIAAx0CUJ0OhgACc41ec1zvc02ydg6UteC5hp2DU1CZ8QACFQEAAtDjEiWHoGfN1Vqe7RgE";
        const string TELEFON = "CAADAgADLwAD0OMSJVIqnEoF7YPMAg";
        const string MALZWEI = "CAADAgADGgAD0OMSJZWDWHnfH6HbAg";
        const string DEUTSCH = "CAADAgADGQAD0OMSJZit8V6tPHuLAg";
        const string TIMECODE = "CAADAgADGAAD0OMSJUaRH8dInLrkAg";
        const string VERFLIXXT = "CAADAgADHwAD0OMSJZk7KA8NijFnAg";
        const string LOGO_PFIFFZIFF = "CAACAgIAAx0CUJ0OhgACc4xec1zuz9DgWQ5vzPWC5vTDEuEsmgACFAEAAtDjEiVT_dggPx0EiRgE";
        const string DIEACHT = "CAADAgADNgAD0OMSJeeeTu0RCBK9Ag";
        const string KRONE = "CAADAgADHAAD0OMSJT9D6UXf";
        const string GEIERPUPPE = "CAADAgADIQAD0OMSJcqtZhKFb97GAg";
        const string DUEUMEL = "CAADAgADDgAD0OMSJRxsm1wJNpS2Ag";
        const string DREIDREIDREI = "CAADAgADMQAD0OMSJdEU84N8V8jkAg";
        const string MOBIZEN = "CAADAgADpQAD0OMSJWb1SN7DP5K2FgQ";
        const string GUNAKLIBO = "CAADAgADzgAD0OMSJUKuUKIAAV99qRYE";
        const string UNDERCOVER = "CAACAgIAAxkBAAIEIV5Fiuu_PfzSbsZLQqv17R4y86kBAAJFAANZELYID6d_L2SFIJQYBA";

        static string wochentag = "";

        static string[] WILLKOMMEN = {"Es ist schooooooon wieder {DAYOFWEEK}!",
                                     "Herzlich Willkommen zu einer neuen Folge Verflixxte Klixx!",
                                     "Wenn die Klixx wieder rollen und die Fischkarte zuckt, ja dann ist es wieder soweit, dann wird Verflixxte Klixx geguckt!",
                                     "Verflixxte Klixx! Verflixxte Klixx! Ver-flixx-te... Klixx!",
                                     "Leute, Leute, Leute, wer's jetzt noch nicht verstanden hat, gähn gähn Zwinkersmiley, Verflixxte Klixx ist die Show der Stunde.",
                                     "Laaarstag, es ist Laaarstag! Laaarstag, Ich-hab-Spaß-Tag!",
                                     "Wir brauchen ein neues Internet, alle Videos müssen gelöscht werden.",
                                     "Yeah, I can't help you, dude.",
                                     "Manchmal muss man mit dem Strudel gehen.",
                                     "Niemand: \n" +
                                     "Wirklich niemand: \n" +
                                     "LKW-Fahrer: *huscht über den Berg*"};

        static string[] WILLKOMMEN_ZIFF = {"PFIFFIGE ZIFFERN! PFIFFIGE ZIFFERN! PFIFF-I-GE... ZIFFERN!",
                                           "BWL, 1. Stunde: Plastik ist spottbillig und dumme Leute zahlen viel Geld. So, geht nach Hause.",
                                           "Es ist schoooooooooooooon wieder {DAYOFWEEK}!",
                                           "Freundschaft ist unbezahlbar. Was man kaufen kann, ist billiger Plastikschrott aus China und darum geht es in dieser Sendung.",
                                           "Die schwarze farbe ist jetzt heißer Verkauf.",
                                           "GOTT, ist das eine schreckliche Albtraumwelt."};

        static string[] HALLO = {"Krrrah, hallo {SPIELERNAME}!",
                                 "Was geeeeeeht, {SPIELERNAME}?",
                                 "{SPIELERNAME}! Mooin!",
                                 "Heeey, {SPIELERNAME} ist ja auch am Start! Krrraah!",
                                 "Woop woop! {SPIELERNAME} in the HOUSE!",
                                 "Oh, {SPIELERNAME}, ich hatte Sie gar nicht reinkommen sehen. Krrah, guten Abend, krrah krrah.",
                                 "Die Klixx werden mit dir sein, {SPIELERNAME}. Immer.",
                                 "Ja, moin!",
                                 "{SPIELERNAME}! Großartig!",
                                 "Halt die Ohren steif, {SPIELERNAME}!"};

        static string[] TSCHÜSS =
        {
            "GuNaKliFre!",
            "Sachtma, habt ihr eigentlich nen VÖLLIGEN SCHAADEN? LANGE MACH ICH DAS NICH MEHR MIT HIER IHR EU—",
            "War ne schöne Sendung heute!"
        };

        static string[] TSCHÜSS_ZIFF =
        {
            "Good buy!",
            "LB Klixxi"
        };

        static string[] QUATSCHKOMMANDO = {"Dieses Feature ist in der Testversion nicht enthalten. Möchten Sie 590 Plu ausgeben und auf die Premiumversion upgraden?", 
                                           "Quatschkommando.",
                                           "Hä?"};

        static string[] TU_ES = {"AAAAAAH Komm schon MATHEEEEE",
                                 "TU ES!"};

        static string[] FISCHKARTENBILDER = new string[3]{FISCHKARTE1, FISCHKARTE2, FISCHKARTE3};

        static string botcode = "";

        static void Main(string[] args)
        {
            Random r = new Random();
            bool running = false;
            bool mtelefon = false;
            bool mdeutsch = false;
            bool mtimecode = false;
            bool mMobizen = false;
            int multiplikator = 1;
            Dictionary<string, double> guesses = new Dictionary<string, double>();
            double florentin = double.NaN;
            double lars = double.NaN;
            string fischkarte_gesetzt = "";
            string fischkarten = "";
            string incognitokarte_gesetzt = "";
            string incognitokarten = "";
            Dictionary<string, long> scoreboard = new Dictionary<string, long>();
            Dictionary<string, long> florentin_punkte = new Dictionary<string, long>();
            Dictionary<string, long> lars_punkte = new Dictionary<string, long>();
            long offset = 0;
            Dictionary<string, int> Geierkandidaten = new Dictionary<string, int>();
            int video_nr = 1;
            List<string> players = new List<string>();
            List<string> players_getippt = new List<string>();
            Dictionary<string, long> kronenliste = new Dictionary<string, long>();
            Dictionary<string, Dictionary<double, int>> userstats = new Dictionary<string, Dictionary<double, int>>();
            string highscorefile = "error.json";
            string userstatsfile = "error.json";

            // Importing bot api identifier
            botcode = System.IO.File.ReadAllText("botcode.txt");

            // Getting day of week
            switch (System.DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday: 
                    wochentag = "Montag";
                    break;
                case DayOfWeek.Tuesday:
                    wochentag = "Dienstag";
                    break;
                case DayOfWeek.Wednesday:
                    wochentag = "Mittwoch";
                    break;
                case DayOfWeek.Thursday:
                    wochentag = "Donnerstag";
                    break;
                case DayOfWeek.Friday:
                    wochentag = "Freitag";
                    break;
                case DayOfWeek.Saturday:
                    wochentag = "Samstag";
                    break;
                case DayOfWeek.Sunday:
                    wochentag = "Sonntag";
                    break;
            }
            WILLKOMMEN[0] = WILLKOMMEN[0].Replace("{DAYOFWEEK}", wochentag);
            WILLKOMMEN_ZIFF[2] = WILLKOMMEN_ZIFF[2].Replace("{DAYOFWEEK}", wochentag);

            bool ziffern = false;
            string spielleiter = "";
            bool schon_gemeckert = false;
            bool playing = true;
            bool florentinkoenig_berechnen = false;
            bool larskoenig_berechnen = false;
            bool schon_vorgefreut = false;

            Console.WriteLine("Es ist schooooon wieder Donnerstag!");
            Console.WriteLine("Der KLIXXBOT ist am Start!");
            Console.WriteLine();

            var Client = new RestSharp.RestClient();

            while (playing)
            {
                // Console.WriteLine("Offset: " + offset.ToString());
                var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/getUpdates?offset=" + offset.ToString(), RestSharp.DataFormat.Json);
                Request.AddParameter("offset", offset.ToString());
                var Response = Client.Execute<Dictionary<string, string>>(Request);
                string result = Response.Data["result"];
                List<TgUpdate> updates = JsonConvert.DeserializeObject<List<TgUpdate>>(result);
                
                // Vorfreude
                TimeSpan zeit = System.DateTime.Now.TimeOfDay;
                if (zeit.Hours == 18 && zeit.Minutes == 45 && !schon_vorgefreut)
                {
                    sendMessage("-1001352470150", "Ooooh bald geht's los! Ich bin schon ganz aufgeregt, krrrah!");
                    schon_vorgefreut = true;
                }

                foreach (TgUpdate update in updates)
                {
                    try
                    {
                        bool command_detected = false;
                        offset = long.Parse(update.update_id) + 1;

                        // Skip empty messages
                        if (update.message == null) continue;
                        if (update.message.text == null) continue;

                        // Console log
                        Console.WriteLine("MESSAGE " + update.message.message_id);
                        Console.Write(update.message.from.first_name + " " + update.message.from.last_name + "(" + update.message.from.username + "): ");
                        Console.Write(update.message.text);
                        Console.Write(Environment.NewLine);
                        
                        // Set username to display name if there is no username
                        if (update.message.from.username == null) update.message.from.username = update.message.from.first_name + update.message.from.last_name;
                        else update.message.from.username = "@" + update.message.from.username;

                        // Ulk: Fischkarte = Senfkarte, wenn PfiffZiff gespielt wird
                        if (update.message.from.username == "Die Fischkarte" && ziffern)
                            update.message.from.username = "Die Senfkarte";

                        // Ulk: Wenn Nachricht von Kuchenfan ist: Kuchisch sprechen
                        bool kuchisch = false;
                        if (update.message.from.username == "@Kuchenfan")
                            kuchisch = true;

                        // Kompatibilität: Auch Befehle mit "!" erkennen
                        if (update.message.text.StartsWith("!"))
                            update.message.text = string.Concat("/", update.message.text.Substring(1));

                        if (update.message.text.StartsWith("/gunaklibo"))
                        {
                            if (ziffern)
                                sendMessage(update.message.chat.id, TSCHÜSS_ZIFF);
                            else
                                sendMessage(update.message.chat.id, TSCHÜSS);
                            sendSticker(update.message.chat.id, GUNAKLIBO);
                            command_detected = true;
                            var exit_request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/getUpdates?offset=" + offset.ToString(), RestSharp.DataFormat.Json);
                            Request.AddParameter("offset", (offset).ToString());
                            Client.Execute<Dictionary<string, string>>(exit_request);
                            Environment.Exit(0);
                        }

                        if (update.message.text.StartsWith("/pufoklixx"))
                        {
                            sendMessage(update.message.chat.id, "Krrrah, liebe Klixxfreunde es ist schoooooon wieder Donnerstag!\n" +
                                "Wir spielen heute mal wieder eine Runde Verflixxte Klixx. Ihr wollt dabei sein? Das ist ganz einfach!\n" +
                                "1. Geht auf https://rocketbeans.tv/randomvideo und gebt dort die Playlist-ID ein, die ihr gleich von einem Klixxfreund genannt bekommt.\n" +
                                "2. Gebt eure Tipps ab mit /klixx [Nummer]! Einmal pro Abend könnt ihr auch die /fischkarte ziehen.\n" +
                                "3. Wenn alle ihren Tipp abgegeben haben, geht der Spielleiter weiter zum nächsten Video. Ich rechne dann, und gebe entsprechend die Punkte - und sage euch Bescheid, dass ihr auf der Website weiter zum nächsten Video gehen könnt.", kuchisch: kuchisch);
                            sendMessage(update.message.chat.id, "(Und votet fleißig für den Geierkönig! (/vk [Name]))", kuchisch: kuchisch);
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/patchnotes"))
                        {
                            sendMessage(update.message.chat.id, "Krrraaah! @Imbecillus hat mich gerade auf Version Beta 1.4 gepatcht!\n" +
                                " - Klixxi versteht jetzt auch Befehle, die mit '!' beginnen.\n" +
                                " - Spieler können gekickt werden, wenn sie z.B. afk gegangen sind und Klixxi darum nicht mehr weiß, ob schon alle getippt haben.\n" +
                                " - Mit '/tipps' könnt ihr euch jetzt anzeigen lassen, was für Schätzungen bereits abgegeben wurden.\n" +
                                " - Ihr könnt jetzt mit '/stats' eure Stats sehen! (Oder mit '/stats [name]' die eines beliebigen Spielers.");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/patchnotes 1.3")) {
                            sendMessage(update.message.chat.id, "Krrraaah! @Imbecillus hat mich gerade auf Version Beta 1.3 gepatcht!\n" +
                                "1.3:\n" +
                                " - Der Kronencounter ist daaa!\n" +
                                "1.3.1:\n" +
                                " - Undercoverkarte implementiert.\n" +
                                "1.3.2:\n" +
                                " - Kuchisch hinzugefügt.\n" +
                                " - Fischkartenfluch entfernt.\n" +
                                "1.3.3:\n" +
                                " - Larskönig und Florentinkönig hinzugefügt.\n" +
                                " - Updates bei Begrüßungssprüchen.\n" +
                                " - Undercoverkartenfluch entfernt.\n" +
                                " - Sticker für Pfiffige Ziffern (Danke @Coldstand!)\n" +
                                "1.3.4:\n" +
                                " - Interne ultrafancy Codeverbesserungen.\n" +
                                " - Klixxi kann jetzt vernünftig Tschüss sagen.\n" +
                                "1.3.5:\n" +
                                " - Klixxi kann jetzt NOCH besser Hallo sagen! (Jetzt wirklich...)\n" +
                                " - Ein neuer Ulk.\n" +
                                "1.3.6:\n" +
                                " - Getrennte Kronen für PfiffZiff und Klixx. @Imbecillus hat die neuen Punktestände rekonstruiert und bestimmt alles falsch gemacht.");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/patchnotes 1.2")) {
                            sendMessage(update.message.chat.id, "PATCHNOTES 1.2.x\n" +
                                " - Für Runden ohne Live-VK von RBTV registrieren sich Spieler jetzt vorher.\n" +
                                " - Fischkartenfluch UND Herobrine entfernt.\n" +
                                " - Für Runden ohne Live-VK gibt es nun neu den Mobizen-Multiplikator.\n" +
                                " - Neues Alias für den generischen Multiplikator: /skip\n" +
                                "1.2.1:\n" +
                                " - Bei /telefon wurde fälschlicherweise der Timecode-Multiplikator aktiviert. Der Timecode-Multiplikator wurde dann aber nie zurückgesetzt. Das Problem mit den " +
                                "falschen Punktzahlen sollte damit behoben sein.\n" +
                                " - Fischkartenfluch entfernt. (Neue Methode, bereits gesetzte Fischkarten zu merken, wird getestet.)\n" +
                                "1.2.2:\n" +
                                " - Neues Kommando: /fix [Username] [Punkteanpassung], für Fälle in denen ich mich verrechne.\n" +
                                "1.2.3:\n" +
                                " - Neues Kommando: /nochfünf, sagt an, dass jetzt nur noch fünf Minuten sind. Duh.\n" +
                                "1.2.4:\n" +
                                " - Gags, Freunde. Gags!\n" +
                                "1.2.5:\n" + 
                                " - Neue Willkommenssprüche.\n" +
                                " - Winborders! (Braucht aber noch Spielleiterhilfe zum Senden...)\n" +
                                " - Klixxi reagiert nun auf Moin.\n" +
                                " - Klixxi markiert nun Spieler, die Usernames haben.\n" +
                                " - Der gleiche Tipp ist nicht mehr mehrmals erlaubt.\n" +
                                " - Klixxi spammt nicht mehr 'Auflösen?!'");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/patchnotes 1.1")) {
                            sendMessage(update.message.chat.id, "PATCHNOTES 1.1.x\n" +
                                " - Bei Ende einer Runde sage ich jetzt nicht nur wer Punkte bekommen hat, sondern auch was getippt wurde und was die tatsächliche Lösung war.\n" +
                                " - Befehle können nun auch groß geschrieben eingegeben werden. Zahlen werden mit Punkt oder Komma erkannt. Beides zusammen ist aber Quatsch.\n" +
                                " - Ich bin weniger aggro was Geier angeht bei Pfiffige Ziffern.\n" +
                                " - Bestimmte Dinge darf nur noch der Spielleiter machen (z.B. Geierpoll und Runde beenden), um doppelten Befehlen vorzubeugen.\n" +
                                " - Alias /senfkarte für /fischkarte hinzugefügt.\n" +
                                " - Uuuund Tim ist sich 85% sicher, dass er eventuell nebenbei den #Fischkartenfluch behoben hat, durch den @dieJulie letztes Mal fälschlicherweise einmal doppelte Punkte bekommen hat.\n" +
                                " - Formatierung von Tipp und #Wahrheit verbessert.\n");
                            command_detected = true;
                        }

                        if (update.message.text.StartsWith("/anmelden")) {
                            sendMessage(update.message.chat.id, "Krrah! Liebe Klixx-Freunde, gleich spielen wir wieder eine Runde Verflixxte Klixx ohne Lars und Florentin. Damit ich weiß, wenn alle getippt haben, und die anderen subtilen sozialen Druck ausüben können, meldet euch bitte alle bei mir mit /anmeld an!");
                            command_detected = true;
                        }
                        if (update.message.text.StartsWith("/nochfünf"))
                        {
                            sendMessage(update.message.chat.id, "Noch fünf Minuten.", kuchisch: kuchisch);
                            sendAudio(update.message.chat.id, "CQADAgADNQQAAgQ4-Eq5iPpKSt2ZAhYE");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/join") | update.message.text.ToLower().StartsWith("/anmeld"))
                        {
                            if (!players.Contains(update.message.from.username))
                                players.Add(update.message.from.username);
                            else
                                sendMessage(update.message.chat.id, "Du hast dich schon angemeldet, du EUMEL!", update.message.message_id, kuchisch: kuchisch);
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/start"))
                        {
                            Console.WriteLine("Command recognized (Start). Starting the game.");
                            if (update.message.text.Contains("ziffern"))
                            {
                                ziffern = true;
                                sendSticker(update.message.chat.id, LOGO_PFIFFZIFF);
                                sendMessage(update.message.chat.id, WILLKOMMEN_ZIFF, kuchisch: kuchisch);
                            }
                            else
                            {
                                sendSticker(update.message.chat.id, VERFLIXXT);
                                sendMessage(update.message.chat.id, WILLKOMMEN, kuchisch: kuchisch);
                            }
                            running = true;
                            scoreboard = new Dictionary<string, long>();
                            spielleiter = update.message.from.username;
                            command_detected = true;

                            // Importing highscore saves
                            if (ziffern)
                                highscorefile = "kronenliste_ziff.json";
                            else
                                highscorefile = "kronenliste_klixx.json";
                            string kronenimport = System.IO.File.ReadAllText(highscorefile);
                            kronenliste = JsonConvert.DeserializeObject<Dictionary<string, long>>(kronenimport);

                            // Importing saved userstats
                            if (ziffern)
                                userstatsfile = "userstats_ziff.json";
                            else
                                userstatsfile = "userstats_klixx.json";
                            string userstatimport = System.IO.File.ReadAllText(userstatsfile);
                            userstats = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<double, int>>>(userstatimport);
                        }

                        if (update.message.text.ToLower().Contains("hallo") | update.message.text.ToLower().Contains("huhu") | update.message.text.ToLower().Contains("hi ") | update.message.text.ToLower().StartsWith("hi ") | update.message.text.ToLower().Contains("hey") | update.message.text.ToLower() == "hi")
                        {
                            sendMessage(update.message.chat.id, HALLO, update.message.message_id, spielername: update.message.from.first_name, kuchisch: kuchisch);
                            Console.WriteLine("\"Hallo\" recognized. Replying.");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().Contains("servas"))
                        {
                            sendMessage(update.message.chat.id, "Griaß di, " + update.message.from.first_name, update.message.message_id);
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().Contains("hallu"))
                        {
                            sendMessage(update.message.chat.id, "Krruh, hallu " + update.message.from.first_name, update.message.message_id);
                            Console.WriteLine("Sonja hallo sagen.");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().Contains("hola") | update.message.text.ToLower().Contains("buen"))
                        {
                            sendMessage(update.message.chat.id, "la FUENTE della cocina del fuego de la noche!", update.message.message_id, kuchisch: kuchisch);
                            Console.WriteLine("La FUENTE.");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().Contains("Bonjour"))
                        {
                            sendMessage(update.message.chat.id, "Aaah, le Klixx c'est arrivé! Bon voyage, mes amis!");
                            Console.WriteLine("Französisch.");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().Contains("moin"))
                        {
                            string replytext = "Moin ";
                            string messagetext = update.message.text.ToLower();
                            do
                            {
                                replytext = replytext + "moin ";
                                messagetext = messagetext.Substring(messagetext.IndexOf("moin")+4);
                            } while (messagetext.Contains("moin"));

                            replytext = replytext[0].ToString().ToUpper() + replytext.Substring(1, replytext.Length - 2) + "!";
                            sendMessage(update.message.chat.id, replytext, update.message.message_id, kuchisch: kuchisch);
                            command_detected = true;
                        }

                        if (update.message.text.Contains("<3"))
                        {
                            sendSticker(update.message.chat.id, "CAADAgADOwADWRC2CDzVFOIKnVYpFgQ", update.message.message_id);
                            Console.WriteLine("PUFOLIEBE");
                            command_detected = true;
                        }

                        if (update.message.text.ToLower().StartsWith("/help"))
                        {
                            string helptext = "Krrah! Zum Spielen brauchst du folgende Befehle:\n" +
                                "/vk: Jemanden für den Geierkönig nominieren\n" +
                                "/geierpoll: Abstimmung für Geierkönig starten\n" +
                                "/klixx: Klixx des aktuellen Videos schätzen\n" +
                                "/fischkarte: Die Fischkarte ziehen!\n" +
                                "/undercover: Die Undercoverkarte ziehen!\n" +
                                "/scores: Zwischenstand anzeigen\n" +
                                "/tipps: Bisherige Tipps anzeigen\n" +
                                "/stats: Statistiken anzeigen";

                            sendMessage(update.message.chat.id, helptext, update.message.message_id, kuchisch: kuchisch);
                            command_detected = true;
                        }
                        if (update.message.text.ToLower().StartsWith("/help ziff"))
                        {
                            string helptext = "Krrah! Bei Pfiffige Ziffern geht auch:\n" +
                                "/ziff: Preis schätzen\n" +
                                "/preis: Preis schätzen\n" +
                                "/senfkarte: Die Senfkarte ziehen!";

                            sendMessage(update.message.chat.id, helptext, update.message.message_id);
                            command_detected = true;
                        }
                        if (update.message.text.ToLower().StartsWith("/help spielleiter"))
                        {
                            string helptext = "Als Spielleiter brauchst du außerdem:\n" +
                                "/start: Runde starten\n" +
                                "/stop: Runde beenden und Gewinner bekanntgeben\n" +
                                "/de: Video als deutsch markieren\n" +
                                "/nummer: Video mit Telefonnummer markieren\n" +
                                "/multi / /skip: Video mit Mal-Zwei-Multiplikator markieren\n" +
                                "/timecode: Video mit Timecode markieren\n" +
                                "/mobizen: Video mit Mobizen-Watermark markieren\n" +
                                "/wahr: Wahre Klixxzahl angeben und nächstes Video starten; '!' markiert das Undercovervideo.\n" +
                                "/fix [x] [Username (so wie er auch in der Highscoreliste steht)]";

                            sendMessage(update.message.chat.id, helptext, update.message.message_id);
                            command_detected = true;
                        }

                        if (running)
                        {
                            if (update.message.text == null) continue;

                            if (update.message.text.ToLower().Contains("selber"))
                            {
                                sendSticker(update.message.chat.id, DUEUMEL, update.message.message_id);
                                command_detected = true;
                            }

                            if (update.message.text.ToLower().Contains("/fix"))
                            {
                                string wertstring = update.message.text.Substring(update.message.text.IndexOf(' ') + 1);
                                string user = wertstring.Substring(wertstring.IndexOf(' ') + 1);
                                wertstring = wertstring.Substring(0, wertstring.IndexOf(' '));
                                long wert = long.Parse(wertstring);
                                Console.WriteLine("User: " + user);
                                scoreboard[user] = scoreboard[user] + wert;
                                command_detected = true;
                            }

                            if (update.message.text.ToLower().Contains("/kick"))
                            {
                                command_detected = true;
                                string user = update.message.text.Substring(update.message.text.IndexOf(' ') + 1);
                                Console.WriteLine("User: " + user);
                                scoreboard.Remove(user);
                                players.Remove(user);
                                sendMessage(update.message.chat.id, "Krrrah, tschüüüüss " + user + "! (hehhehe)");
                            }

                            if (update.message.text.ToLower().StartsWith("/vk"))
                            {
                                string geier = update.message.text.Substring(4);
                                if (Geierkandidaten.ContainsKey(geier))
                                {
                                    Geierkandidaten[geier] += 1;
                                }
                                else
                                {
                                    Geierkandidaten[geier] = 1;
                                }
                                command_detected = true;
                            }

                            if (update.message.text.ToLower().StartsWith("/geierpoll"))
                            {
                                command_detected = true;
                                if (update.message.from.username == spielleiter)
                                {
                                    List<string> Geiermenschen = new List<string>();
                                    foreach (KeyValuePair<string, int> geier in Geierkandidaten)
                                    {
                                        Geiermenschen.Add(geier.Key);
                                    }
                                    if (Geiermenschen.Count > 10)
                                    {
                                        sendMessage(update.message.chat.id, "Krrrah! Telegram erlaubt nicht, so viele Optionen zu einer Umfrage hinzuzufügen. Heute seid ihr ALLE Geier!");
                                        int most = -1;
                                        string geierking = "";
                                        foreach (KeyValuePair<string, int> geier in Geierkandidaten)
                                        {
                                            if (geier.Value > most)
                                            {
                                                most = geier.Value;
                                                geierking = geier.Key;
                                            }
                                        }
                                        if (most > 2)
                                            sendMessage(update.message.chat.id, "(aber am geierigsten war scheinbar " + geierking + ")");
                                    }
                                    sendSticker(update.message.chat.id, GEIERPUPPE);
                                    sendPoll(update.message.chat.id, "Wer war heute der Geierkönig?", Geiermenschen.ToArray());
                                }
                                else
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann die Geierpoll starten.", update.message.message_id);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/florentin"))
                            {
                                command_detected = true;
                                string tipp = update.message.text.Substring(update.message.text.IndexOf(' '));
                                tipp = tipp.Replace('.', ',');
                                florentin = double.Parse(tipp);
                                florentinkoenig_berechnen = true;
                            }

                            if (update.message.text.ToLower().StartsWith("/lars"))
                            {
                                command_detected = true;
                                string tipp = update.message.text.Substring(update.message.text.IndexOf(' '));
                                tipp = tipp.Replace('.', ',');
                                lars = double.Parse(tipp);
                                larskoenig_berechnen = true;
                            }

                            if (update.message.text.ToLower().StartsWith("/klixx") | update.message.text.ToLower().StartsWith("/preis") | update.message.text.ToLower().StartsWith("/ziff"))
                            {
                                command_detected = true;
                                if (players.Count != 0 && !players.Contains(update.message.from.username))
                                {
                                    players.Add(update.message.from.username);
                                    sendMessage(update.message.chat.id, "Krrrah, willkommen im Spiel, " + update.message.from.username + "!", update.message.message_id, kuchisch: kuchisch);
                                }

                                if (!System.IO.File.Exists(update.message.from.username + ".jpg"))
                                {
                                    getProfilePicture(update.message.from.id, update.message.from.username);
                                }

                                Console.WriteLine("Command recognized (Klixx).");
                                double newguess;
                                if (update.message.text.Contains("DIE ACHT"))
                                    newguess = 8;
                                else
                                {
                                    string tipp = update.message.text.Substring(update.message.text.IndexOf(' '));
                                    tipp = tipp.Replace('.', ',');
                                    newguess = double.Parse(tipp);
                                }

                                if (scoreboard.Keys.Contains(update.message.from.username) == false) scoreboard[update.message.from.username] = 0;

                                if (guesses.Values.Contains(newguess)) {
                                    sendMessage(update.message.chat.id, "Krraahh, das wurde schon getippt, du Eumel! Bitte gib einen neuen Tipp ab!", update.message.message_id, kuchisch: kuchisch);
                                }

                                if (newguess == 333 || newguess == 3.33)
                                    sendSticker(update.message.chat.id, DREIDREIDREI, update.message.message_id);

                                // Autogeier
                                foreach (KeyValuePair<string, double> guess in guesses)
                                {
                                    double difference = newguess - guess.Value;
                                    double range;
                                    if (ziffern) range = 100; else range = 10;
                                    if (difference < 0) difference *= -1;
                                    if (difference < newguess / range & guess.Key != update.message.from.username)
                                    {
                                        sendSticker(update.message.chat.id, GEIERPUPPE, update.message.message_id);
                                        sendMessage(update.message.chat.id, "/vk " + update.message.from.username, kuchisch: kuchisch);
                                        if (Geierkandidaten.ContainsKey(update.message.from.username))
                                        {
                                            Geierkandidaten[update.message.from.username] += 1;
                                        }
                                        else
                                        {
                                            Geierkandidaten[update.message.from.username] = 1;
                                        }
                                    }
                                }
                                guesses[update.message.from.username] = newguess;
                                Console.WriteLine(update.message.from.username + " : " + guesses[update.message.from.username].ToString());
                                if (!players_getippt.Contains(update.message.from.username))
                                    players_getippt.Add(update.message.from.username);
                            }

                            if (update.message.text.ToLower().StartsWith("/fischkarte") | update.message.text.ToLower().StartsWith("/senfkarte"))
                            {
                                command_detected = true;
                                Console.WriteLine(update.message.from.username + ": Command recognized (Fischkarte).");

                                if (fischkarte_gesetzt.Contains(update.message.from.username))
                                {
                                    sendMessage(update.message.chat.id, "Du hast die Fischkarte schonmal gesetzt.", update.message.message_id, kuchisch: kuchisch);
                                    sendSticker(update.message.chat.id, DUEUMEL, update.message.message_id);
                                }
                                else
                                {
                                    if (ziffern)
                                        sendSticker(update.message.chat.id, SENFKARTE, update.message.message_id);
                                    else
                                        sendSticker(update.message.chat.id, FISCHKARTENBILDER[r.Next(0, 2)], update.message.message_id);

                                    fischkarten += " " + update.message.from.username + " ";
                                    fischkarte_gesetzt += " " + update.message.from.username + " ";
                                    Console.WriteLine("Fischkarten bereits gesetzt: " + fischkarte_gesetzt);
                                    Console.WriteLine("Fischkarten diese Runde: " + fischkarten);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/undercover"))
                            {
                                command_detected = true;
                                Console.WriteLine(update.message.from.username + ": Command recognized (Incognito).");

                                if (incognitokarte_gesetzt.Contains(update.message.from.username))
                                {
                                    sendMessage(update.message.chat.id, "Du hast die Undercoverkarte schonmal gesetzt.", update.message.message_id, kuchisch: kuchisch);
                                    sendSticker(update.message.chat.id, DUEUMEL, update.message.message_id);
                                }
                                else
                                {
                                    sendSticker(update.message.chat.id, UNDERCOVER, update.message.message_id);
                                    incognitokarten += update.message.from.username + ";";
                                    incognitokarte_gesetzt += update.message.from.username + ";";
                                    Console.WriteLine("Incognitokarte bereits gesetzt: " + incognitokarte_gesetzt);
                                    Console.WriteLine("Incognitokarte diese Runde: " + incognitokarten);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/de"))
                            {
                                command_detected = true;
                                if (update.message.from.username == spielleiter)
                                {
                                    Console.Write("Command recognized (Deutsch).");
                                    mdeutsch = true;
                                    sendSticker(update.message.chat.id, DEUTSCH);
                                }
                                else
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann Multiplikatoren markieren.", update.message.message_id, kuchisch: kuchisch);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/mobizen"))
                            {
                                command_detected = true;
                                if (update.message.from.username == spielleiter)
                                {
                                    Console.Write("Command recognized (Mobizen).");
                                    mMobizen = true;
                                    sendSticker(update.message.chat.id, MOBIZEN);
                                }
                                else
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann Multiplikatoren markieren.", update.message.message_id, kuchisch: kuchisch);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/timecode"))
                            {
                                command_detected = true;
                                if (update.message.from.username == spielleiter)
                                {
                                    Console.Write("Command recognized (Timecode).");
                                    mtimecode = true;
                                    sendSticker(update.message.chat.id, TIMECODE);
                                }
                                else
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann Multiplikatoren markieren.", update.message.message_id, kuchisch: kuchisch);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/nummer"))
                            {
                                command_detected = true;
                                if (update.message.from.username == spielleiter)
                                {
                                    Console.Write("Command recognized (Nummer).");
                                    mtelefon = true;
                                    sendSticker(update.message.chat.id, TELEFON);
                                }
                                else
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann Multiplikatoren markieren.", update.message.message_id, kuchisch: kuchisch);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/multi") | update.message.text.ToLower().StartsWith("/multi"))
                            {
                                command_detected = true;
                                if (update.message.from.username == spielleiter)
                                {
                                    Console.Write("Command recognized (Multiplikator).");
                                    multiplikator *= 2;
                                    sendSticker(update.message.chat.id, MALZWEI);
                                }
                                else
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann Multiplikatoren markieren.", update.message.message_id, kuchisch: kuchisch);
                                }
                            }

                            if (update.message.text.ToLower().StartsWith("/scores"))
                            {
                                command_detected = true;
                                Console.WriteLine("Command recognized (Scores).");
                                string scores = "ZWISCHENSTAND\n";
                                foreach (KeyValuePair<string, long> entry in scoreboard)
                                {
                                    scores += entry.Key + ": " + entry.Value.ToString() + "\n";
                                }
                                sendMessage(update.message.chat.id, scores);
                            }

                            if (update.message.text.ToLower().StartsWith("/tipps"))
                            {
                                command_detected = true;
                                Console.WriteLine("Command recognized (Tipps).");
                                string tipps = "ABGEGEBENE TIPPS:\n";
                                foreach (KeyValuePair<string, double> entry in guesses)
                                {
                                    tipps += entry.Key + ": " + entry.Value.ToString() + "\n";
                                }
                                sendMessage(update.message.chat.id, tipps);
                            }

                            if (update.message.text.ToLower().StartsWith("/stats"))
                            {
                                command_detected = true;

                                string user;
                                if (update.message.text.Contains(" "))
                                    user = update.message.text.Substring(update.message.text.IndexOf(" "));
                                else
                                    user = update.message.from.username;

                                double avg_all = calculateAverage(userstats[user]);
                                double avg_today = calculateAverage(userstats[user], true);
                                sendMessage(update.message.chat.id, user + " liegt durchschnittlich " + avg_all.ToString() + " daneben. \n");
                                if (avg_today < avg_all)
                                    sendMessage(update.message.chat.id, "Heute ist " + user + " besser als sonst und liegt durchschnittlich " + avg_today.ToString() + " daneben.");
                                else
                                    sendMessage(update.message.chat.id, "Heute hat " + user + " einen Quatschtag und liegt durchschnittlich " + avg_today.ToString() + " daneben.");
                            }

                            if (update.message.text.ToLower().StartsWith("/kronen"))
                            {
                                command_detected = true;
                                Console.WriteLine("Showing the croooowns.");
                                string crowns = "DIE KRONEN";
                                foreach (string spieler in kronenliste.Keys) {
                                    string zeile = spieler + ":";
                                    for (int i = 1; i <= kronenliste[spieler]; i++)
                                        zeile = zeile + "👑";
                                    crowns = crowns + "\n" + zeile;
                                }
                                sendMessage(update.message.chat.id, crowns);
                            }

                            if (update.message.text.ToLower().StartsWith("/stop"))
                            {
                                command_detected = true;
                                running = false;

                                Console.WriteLine("Command recognized (Stop).");
                                sendSticker(update.message.chat.id, KRONE);
                                string scores = "ENDERGEBNIS\n";
                                long highscore = -1;
                                foreach (KeyValuePair<string, long> entry in scoreboard)
                                {
                                    scores += entry.Key + ": " + entry.Value.ToString() + "\n";
                                    if (entry.Value > highscore) highscore = entry.Value;
                                }
                                sendMessage(update.message.chat.id, scores);
                                List<string> gewinner = new List<string>();
                                foreach (KeyValuePair<string, long> entry in scoreboard)
                                {
                                    if (entry.Value == highscore) gewinner.Add(entry.Key);
                                }
                                sendSticker(update.message.chat.id, KRONE);
                                string winnerstring = "";
                                if (gewinner.Count > 1)
                                {
                                    winnerstring += "Die Gewinner sind: ";
                                    for (int i = 0; i < gewinner.Count; i++)
                                    {
                                        winnerstring += gewinner[i];
                                        if (i == gewinner.Count - 2) winnerstring += " und ";
                                        else
                                        {
                                            if (i == gewinner.Count - 1) winnerstring += ".";
                                            else winnerstring += ", ";
                                        }
                                    }
                                }
                                else winnerstring = gewinner[0] + " gewinnt!";

                                if (larskoenig_berechnen)
                                {
                                    Console.WriteLine("Lars berechnen");
                                    highscore = -1;
                                    foreach (KeyValuePair<string, long> entry in lars_punkte)
                                    {
                                        if (entry.Value > highscore) highscore = entry.Value;
                                    }
                                    List<string> larskoenig = new List<string>();
                                    foreach (KeyValuePair<string, long> entry in lars_punkte)
                                        if (entry.Value == highscore) larskoenig.Add(entry.Key);

                                    string larskoenigstring = "";
                                    if (larskoenig.Count > 1)
                                    {
                                        larskoenigstring += "Die Larskönige sind: ";
                                        for (int i = 0; i < larskoenig.Count; i++)
                                        {
                                            larskoenigstring += larskoenig[i];
                                            if (i == larskoenig.Count - 2) larskoenigstring += " und ";
                                            else
                                            {
                                                if (i == gewinner.Count - 1) larskoenigstring += ".";
                                                else larskoenigstring += ", ";
                                            }
                                        }
                                    }
                                    else larskoenigstring = larskoenig[0] + " ist Larskönig!";
                                    sendMessage(update.message.chat.id, larskoenigstring);
                                }
                                
                                if (florentinkoenig_berechnen)
                                {
                                    Console.WriteLine("Florentin berechnen");
                                    highscore = -1;
                                    foreach (KeyValuePair<string, long> entry in florentin_punkte)
                                    {
                                        if (entry.Value > highscore) highscore = entry.Value;
                                    }
                                    List<string> florentinkoenig = new List<string>();
                                    foreach (KeyValuePair<string, long> entry in florentin_punkte)
                                        if (entry.Value == highscore) florentinkoenig.Add(entry.Key);

                                    string florentinkoenigstring = "";
                                    if (florentinkoenig.Count > 1)
                                    {
                                        florentinkoenigstring += "Die Florentinkönige sind: ";
                                        for (int i = 0; i < florentinkoenig.Count; i++)
                                        {
                                            florentinkoenigstring += florentinkoenig[i];
                                            if (i == florentinkoenig.Count - 2) florentinkoenigstring += " und ";
                                            else
                                            {
                                                if (i == gewinner.Count - 1) florentinkoenigstring += ".";
                                                else florentinkoenigstring += ", ";
                                            }
                                        }
                                    }
                                    else florentinkoenigstring = florentinkoenig[0] + " ist Florentinkönig!";
                                    sendMessage(update.message.chat.id, florentinkoenigstring);
                                }

                                
                                foreach (string winnername in gewinner) {
                                    makeWinBorder(winnername);
                                    if (kronenliste.ContainsKey(winnername))
                                    {
                                        kronenliste[winnername] += 1;
                                    }
                                    else
                                    {
                                        kronenliste[winnername] = 1;
                                    }
                                }

                                // Kronen speichern
                                string json_export = JsonConvert.SerializeObject(kronenliste);
                                System.IO.File.WriteAllText(highscorefile, json_export);

                                // Userstats speichern (& komprimieren)
                                foreach (KeyValuePair<string, Dictionary<double, int>> paar in userstats)
                                {
                                    double avg = calculateAverage(paar.Value);
                                    int total = sumStats(paar.Value);
                                    userstats[paar.Key] = new Dictionary<double, int>();
                                    userstats[paar.Key][avg] = total;
                                }
                                json_export = JsonConvert.SerializeObject(userstats);
                                System.IO.File.WriteAllText(userstatsfile, json_export);

                                sendSticker(update.message.chat.id, KRONE);
                                sendMessage(update.message.chat.id, winnerstring);
                            }

                            if (update.message.text.ToLower().StartsWith("/wahr"))
                            {
                                if (update.message.text.EndsWith("!"))
                                {
                                    sendMessage(update.message.chat.id, "Krrrah! Das hier war das Undercovervideo!", kuchisch: kuchisch);
                                    Console.WriteLine(update.message.text);
                                    update.message.text = update.message.text.Substring(0, update.message.text.Length - 1);
                                    Console.WriteLine(update.message.text);
                                    string undercover_korrekt = "";
                                    string[] undercover_gesetzt = incognitokarten.Split(';');
                                    if (undercover_gesetzt.Length > 0)
                                    {
                                        foreach (string spieler in undercover_gesetzt) {
                                            if (spieler != "")
                                            {
                                                undercover_korrekt += spieler + " ";
                                                scoreboard[spieler] += 1;
                                            }
                                        }
                                    }
                                    sendMessage(update.message.chat.id, "Bonuspunkte gibt's für " + undercover_korrekt + "!", kuchisch: kuchisch);
                                }

                                command_detected = true;
                                if (update.message.from.username != spielleiter)
                                {
                                    sendMessage(update.message.chat.id, "Nur der Spielleiter kann eine Runde beenden, damit nicht versehentlich eine Runde geskippt wird.", update.message.message_id, kuchisch: kuchisch);
                                    continue;
                                }

                                Console.WriteLine("Command recognized (Wahrheit).");
                                double wahrheit = double.Parse(update.message.text.Substring(update.message.text.IndexOf(' ')));

                                if (wahrheit == 8) sendSticker(update.message.chat.id, DIEACHT);

                                if (r.NextDouble() < 0.1)
                                {
                                    Console.WriteLine("Zeit für GAGS LEUDE");
                                    sendMessage(update.message.chat.id, TU_ES);
                                    System.Threading.Thread.Sleep(2000);
                                }

                                // User Stats für Lars und Florentin
                                if (larskoenig_berechnen)
                                {
                                    double daneben = wahrheit - lars;
                                    if (userstats["Lars Paulsen"].ContainsKey(daneben))
                                        userstats["Lars Paulsen"][daneben] += 1;
                                    else
                                        userstats["Lars Paulsen"][daneben] = 1;
                                }
                                if (florentinkoenig_berechnen)
                                {
                                    double daneben = wahrheit - florentin;
                                    if (userstats["Florentin Will"].ContainsKey(daneben))
                                        userstats["Florentin Will"][daneben] += 1;
                                    else
                                        userstats["Florentin Will"][daneben] = 1;
                                }
                                
                                // Beste Distanz bestimmen
                                double distanz = -1;
                                double lars_distanz = -1;
                                double florentin_distanz = -1;

                                Dictionary<string, double> distanzen = new Dictionary<string, double>();
                                Dictionary<string, double> lars_distanzen = new Dictionary<string, double>();
                                Dictionary<string, double> florentin_distanzen = new Dictionary<string, double>();

                                foreach (KeyValuePair<string, double> tipp in guesses)
                                {
                                    double distanz_neu = wahrheit - tipp.Value;
                                    double distanz_neu_lars = lars - tipp.Value;
                                    double distanz_neu_florentin = florentin - tipp.Value;

                                    if (distanz_neu < 0) distanz_neu *= -1;
                                    if (distanz_neu_lars < 0) distanz_neu_lars *= -1;
                                    if (distanz_neu_florentin < 0) distanz_neu_florentin *= -1;

                                    distanzen[tipp.Key] = distanz_neu;
                                    lars_distanzen[tipp.Key] = distanz_neu_lars;
                                    florentin_distanzen[tipp.Key] = distanz_neu_florentin;

                                    if (distanz == -1 | distanz_neu < distanz)
                                    {
                                        distanz = distanz_neu;
                                    }
                                    Console.WriteLine("Distanz: " + distanz_neu.ToString());
                                    if (lars_distanz == -1 | distanz_neu_lars < lars_distanz)
                                    {
                                        lars_distanz = distanz_neu_lars;
                                    }
                                    if (florentin_distanz == -1 | distanz_neu_florentin < florentin_distanz)
                                    {
                                        florentin_distanz = distanz_neu_florentin;
                                    }
                                }

                                // Berechne Punkte für jeden Teilnehmer
                                if (lars != double.NaN)
                                    foreach (KeyValuePair<string, double> tipp in lars_distanzen)
                                    {
                                        if (tipp.Value == lars_distanz)
                                            if (!lars_punkte.ContainsKey(tipp.Key))
                                                lars_punkte[tipp.Key] = 1;
                                            else
                                                lars_punkte[tipp.Key] += 1;
                                    }


                                if (florentin != double.NaN)
                                    foreach (KeyValuePair<string, double> tipp in florentin_distanzen)
                                    {
                                        if (tipp.Value == florentin_distanz)
                                            if (!florentin_punkte.ContainsKey(tipp.Key))
                                                florentin_punkte[tipp.Key] = 1;
                                            else
                                                florentin_punkte[tipp.Key] += 1;
                                    }

                                foreach (KeyValuePair<string, double> tipp in distanzen)
                                {
                                    // In Userstats-Dict eintragen
                                    if (!userstats.ContainsKey(tipp.Key))
                                        userstats[tipp.Key] = new Dictionary<double, int>();

                                    if (userstats[tipp.Key].ContainsKey(tipp.Value))
                                        userstats[tipp.Key][tipp.Value] += 1;
                                    else
                                        userstats[tipp.Key][tipp.Value] = 1;

                                    // Punkte verteilen wenn niedrigste Distanz
                                    if (tipp.Value == distanz)
                                    {
                                        long punkte = 1;
                                        if (distanz == 0) punkte = (long)Math.Round(wahrheit);
                                        if (mdeutsch) punkte += 2;
                                        if (mtimecode) punkte += 1;
                                        if (mtelefon) punkte *= 2;
                                        if (mMobizen) punkte *= 2;
                                        try
                                        {
                                            if (fischkarten.Contains(tipp.Key))
                                            {
                                                punkte *= 2;
                                                Console.WriteLine(tipp.Key + " erhält Fischkartenmultiplikator.");
                                            }
                                            else
                                            {
                                                Console.WriteLine(tipp.Key + ": Keine Fischkarte.");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            sendMessage(update.message.chat.id, "Krrrah! " + e.Message, kuchisch: kuchisch);
                                        }
                                        punkte *= multiplikator;

                                        if (punkte != 1) sendMessage(update.message.chat.id, punkte.ToString() + " Punkte für " + tipp.Key + "!");
                                        else sendMessage(update.message.chat.id, punkte.ToString() + " Punkt für " + tipp.Key + "!");

                                        // Tipp und Wahrheit ausgeben.
                                        string str_tipp = guesses[tipp.Key].ToString();
                                        string str_wahr = wahrheit.ToString();

                                        string line2_spacer = "";
                                        Console.WriteLine("Spacing out line 2...");
                                        for (int i = 0; i < str_tipp.Length - str_wahr.Length; i++)
                                        {
                                            line2_spacer += " ";
                                            Console.WriteLine(i);
                                        }

                                        string line1_spacer = "";
                                        Console.WriteLine("Spacing out line 1...");
                                        for (int i = 0; i < str_wahr.Length - str_tipp.Length; i++)
                                        {
                                            line1_spacer += " ";
                                            Console.WriteLine(i);
                                        }

                                        string line1 = "Der Tipp:      " + line1_spacer + str_tipp;
                                        string line2 = "Die #Wahrheit: " + line2_spacer + str_wahr;
                                        sendMessage(update.message.chat.id, "<pre>" + line1 + "\n" + line2 + "</pre>");

                                        scoreboard[tipp.Key] += punkte;
                                    }

                                    // Reset Florentin's and Lars' guesses
                                    florentin = double.NaN;
                                    lars = double.NaN;
                                }

                                // Resetting multipliers
                                mtelefon = false;
                                mtimecode = false;
                                mdeutsch = false;
                                mMobizen = false;
                                multiplikator = 1;

                                fischkarten = "";

                                guesses = new Dictionary<string, double>();

                                players_getippt = new List<string>();
                                schon_gemeckert = false;

                                lars = double.NaN;
                                florentin = double.NaN;

                                video_nr++;
                                if (ziffern == false)
                                    sendMessage(update.message.chat.id, "Jetzt abstimmen für Video " + video_nr.ToString());
                                else
                                    sendMessage(update.message.chat.id, "Jetzt abstimmen für Produkt " + video_nr.ToString());
                            }

                            if (players.Count >= 1 & players_getippt.Count == players.Count & !schon_gemeckert)
                            {
                                sendMessage(update.message.chat.id, "Jeder hat getippt. Auflösen?");
                                schon_gemeckert = true;
                            }

                            if (update.message.text.StartsWith("/") & command_detected == false)
                            {
                                sendMessage(update.message.chat.id, QUATSCHKOMMANDO);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        sendMessage(update.message.chat.id, "Krraaah! " + e.Message.ToString(), update.message.message_id);
                    }
                    update.message.from.username = null;
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        static void getProfilePicture(string user_id, string filename = "test")
        {
            var Client = new RestSharp.RestClient();
            Console.WriteLine("Trying to download profile picture...");

            // Get List of Profile Photos and ID of current picture
            var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/getUserProfilePhotos", RestSharp.DataFormat.Json);
            Request.AddParameter("user_id", user_id);
            var Response = Client.Execute<Dictionary<string, string>>(Request);
            string result = Response.Data["result"];
            TgUserProfilePhotos photos = JsonConvert.DeserializeObject<TgUserProfilePhotos>(result);

            // Get link to current picture
            string photo_id = photos.photos[0][2].file_id;
            Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/getFile", RestSharp.DataFormat.Json);
            Request.AddParameter("file_id", photo_id);
            Response = Client.Execute<Dictionary<string, string>>(Request);
            result = Response.Data["result"];
            TgFile file = JsonConvert.DeserializeObject<TgFile>(result);

            // Download current picture
            string url_end = file.file_path;
            Console.WriteLine("https://api.telegram.org/file/" + botcode + "/" + url_end);
            Request = new RestSharp.RestRequest("https://api.telegram.org/file/" + botcode + "/" + url_end);
            byte[] photo = Client.DownloadData(Request);
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filename + ".jpg", System.IO.FileMode.Create));
            writer.Write(photo);
        }

        static void makeWinBorder(string winner_name)
        {
            Console.WriteLine("Starte Win Border für " + winner_name);

            System.Drawing.Bitmap border = new System.Drawing.Bitmap(System.Drawing.Image.FromFile("WinBorder_640.png"));
            Console.WriteLine("Winborder geladen.");
            System.Drawing.Bitmap winner = new System.Drawing.Bitmap(System.Drawing.Image.FromFile(winner_name + ".jpg"));
            Console.WriteLine("Winner geladen.");

            for (int x = 0; x < 640; x++)
            {
                for (int y = 0; y < 640; y++)
                {
                    if (border.GetPixel(x, y).A <= 100)
                        border.SetPixel(x, y, winner.GetPixel(x, y));
                }
            }

            Console.WriteLine("Rahmen gefüllt.");

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(border);
            System.Drawing.RectangleF rectf = new System.Drawing.RectangleF(175, 530, 290, 75);

            // Get fitting font size
            System.Drawing.Font font;
            System.Drawing.SizeF text_dim;
            int size = 50;

            do
            {
                size -= 2;
                font = new System.Drawing.Font("Impact", size);
                text_dim = g.MeasureString(winner_name, font);
            } while (text_dim.Width > 290);

            float air_h = rectf.Width - text_dim.Width;
            float air_v = rectf.Height - text_dim.Height;
            rectf = new System.Drawing.RectangleF(rectf.X + air_h/2, rectf.Y + air_v/2, text_dim.Width, text_dim.Height);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.DrawString(winner_name, font, System.Drawing.Brushes.White, rectf);
            g.Flush();

            Console.WriteLine("Name geschrieben.");

            border.Save("winner_pix.jpg");
            Console.WriteLine("Bild gespeichert.");
        }

        static void sendPhoto(string chat_id, string photo, long reply_to_message_id = -1)
        {
            var Client = new RestSharp.RestClient();
            var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/sendPhoto", RestSharp.DataFormat.Json);
            Request.AddParameter("chat_id", chat_id);
            Request.AddParameter("photo", photo);
            if (reply_to_message_id != -1)
            {
                Request.AddParameter("reply_to_message_id", reply_to_message_id.ToString());
            }
            Client.Execute(Request);
        }

        static void sendMessage(string chat_id, string[] message_array, long reply_to_message_id = -1, string spielername = "", bool kuchisch = false)
        {
            // Select a random string from message_array and send a message with that string
            Random r = new Random();

            string message = message_array[r.Next(0, message_array.Count())];
            message = message.Replace("{SPIELERNAME}", spielername);
            
            sendMessage(chat_id, message, reply_to_message_id, kuchisch);
        }

        static void sendMessage(string chat_id, string text, long reply_to_message_id = -1, bool kuchisch = false)
        {
            if (kuchisch)
            {
                // Kuchennachricht! Wir schieben nun die Buchstaben etwas hin und her...
                text = text.ToLower();
                string[] words = text.Split(' ');
                string new_text = "";
                for (int i = 0; i < words.Length; i++)
                {
                    // Select 1 - 5 random char pairs to switch
                    Random zufall = new Random();
                    int n_chars = zufall.Next(1, 3);
                    for (int p = 0; p < n_chars; p++)
                    {
                        int c1 = zufall.Next(0, words[i].Length - 1);
                        int c2 = zufall.Next(c1 - 2, c1 + 2);
                        if (c2 < 0)
                            c2 = 0;
                        if (c2 > words[i].Length - 1)
                            c2 = words[i].Length - 1;

                        string word_new = "";
                        for (int c = 0; c < words[i].Length; c++)
                        {
                            if (words[i][c] == 'c' && zufall.NextDouble() < 0.5)
                            {
                                word_new += 'v';
                                continue;
                            }

                            if (c == c1)
                                word_new += words[i][c2];
                            else if (c == c2)
                                word_new += words[i][c1];
                            else
                                word_new += words[i][c];
                        }
                        words[i] = word_new;
                    }
                    new_text += words[i] + " ";
                }

                text = new_text;
            }

            var Client = new RestSharp.RestClient();
            var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/sendMessage", RestSharp.DataFormat.Json);
            Request.AddParameter("chat_id", chat_id);
            Request.AddParameter("text", text);
            Request.AddParameter("parse_mode","HTML");
            if (reply_to_message_id != -1)
            {
                Request.AddParameter("reply_to_message_id", reply_to_message_id.ToString());
            }
            Client.Execute(Request);
        }

        static void sendAudio(string chat_id, string audio_url, long reply_to_message_id = -1)
        {
            var Client = new RestSharp.RestClient();
            var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/sendAudio", RestSharp.DataFormat.Json);
            Request.AddParameter("chat_id", chat_id);
            Request.AddParameter("audio", audio_url);
            if (reply_to_message_id != -1)
            {
                Request.AddParameter("reply_to_message_id", reply_to_message_id.ToString());
            }
            Client.Execute(Request);
        }

        static void sendSticker(string chat_id, string sticker_id, long reply_to_message_id = -1)
        {
            var Client = new RestSharp.RestClient();
            var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/sendSticker", RestSharp.DataFormat.Json);
            Request.AddParameter("chat_id", chat_id);
            Request.AddParameter("sticker", sticker_id);
            if (reply_to_message_id != -1)
            {
                Request.AddParameter("reply_to_message_id", reply_to_message_id.ToString());
            }
            Client.Execute(Request);
        }

        static void sendPoll(string chat_id, string question, string[] options)
        {
            var Client = new RestSharp.RestClient();
            var Request = new RestSharp.RestRequest("https://api.telegram.org/" + botcode + "/sendPoll", RestSharp.DataFormat.Json);
            Request.AddParameter("chat_id", chat_id);
            Request.AddParameter("question", question);
            string optionlist = "[ \"" + options[0] + "\", ";
            for (int i = 1; i < options.Count() - 1; i++)
            {
                optionlist += "\"" + options[i] + "\", ";
            }
            optionlist += "\"" + options[options.Count()-1] + "\" ]";
            Request.AddParameter("options", optionlist);
            Client.Execute(Request);
        }

        static double calculateAverage(Dictionary<double, int> liste, bool skip_first = false)
        {
            double total = 0.0;
            double number = 0;

            foreach (KeyValuePair<double, int> paar in liste)
            {
                if (skip_first) {
                    skip_first = false;
                    continue;
                }

                double value = paar.Value;

                if (value < 0)
                    value = value * -1;

                number += value;
                total += paar.Key * paar.Value;
            }

            return total / number;
        }

        static int sumStats(Dictionary<double, int> liste)
        {
            int number = 0;

            foreach (KeyValuePair<double, int> paar in liste)
            {
                number += paar.Value;
            }

            return number;
        }
    }
}

class TgUpdate
{
    public string update_id;
    public TgMessage message;
}

class TgMessage
{
    public long message_id;
    public TgFrom from;
    public TgChat chat;
    public string date;
    public string text;
}

class TgFrom
{
    public string id;
    public bool is_bot;
    public string first_name;
    public string last_name;
    public string username;
    public string language_code;
}

class TgChat
{
    public string id;
    public string first_name;
    public string last_name;
    public string username;
    public string type;
}

class TgUserProfilePhotos
{
    public int total_count;
    public List<List<TgPhotoSize>> photos;
}

class TgPhotoSize
{
    public string file_id;
    public int width;
    public int height;
    public int file_size;
}

class TgFile
{
    public string file_id;
    public int file_size;
    public string file_path;
}

class TgInputMediaPhoto
{
    public string type;
    public string media;
    public string caption;
    public string parse_mode;
}
