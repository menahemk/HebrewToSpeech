using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int IndWord = 0;
        static bool SvaNa = true;

        const char GERSIIM = '\u0022';

        const char SHEVA = '\u05B0';
        const char HATAF_SEGOL = '\u05B1';
        const char HATAF_PATAH = '\u05B2';
        const char HATAF_QAMATS = '\u05B3';
        const char HIRIQ = '\u05B4';
        const char TSERE = '\u05B5';
        const char SEGOL = '\u05B6';
        const char PATAH = '\u05B7';
        const char KAMAZ = '\u05B8';
        const char HOLAM = '\u05B9';
        const char HOLAM_HASER = '\u05BA';
        const char QUBUTS = '\u05BB';
        const char DAGES = '\u05BC';
        const char SHIN_RIGHT = '\u05C1';
        const char SHIN_LEFT = '\u05C2';
        const char QAMATS_QATAN = '\u05C7';

        const char ALEF = '\u05D0';
        const char BEIT = '\u05D1';
        const char GIMEL = '\u05D2';
        const char DALET = '\u05D3';
        const char HE = '\u05D4';
        const char VAV = '\u05D5';
        const char ZAIN = '\u05D6';
        const char HEIT = '\u05D7';
        const char TEIT = '\u05D8';
        const char YOD = '\u05D9';
        const char KAF_SOFIT = '\u05DA';
        const char KAF = '\u05DB';
        const char LAMED = '\u05DC';
        const char MEM_SOFIT = '\u05DD';
        const char MEM = '\u05DE';
        const char NON_SOFIT = '\u05DF';
        const char NON = '\u05E0';
        const char SAMEH = '\u05E1';
        const char AYIN = '\u05E2';
        const char PE_SOFIT = '\u05E3';
        const char PE = '\u05E4';
        const char TSADI_SOFIT = '\u05E5';
        const char TSADI = '\u05E6';
        const char KOF = '\u05E7';
        const char RISH = '\u05E8';
        const char SHIN = '\u05E9';
        const char THAF = '\u05EA';
        static SortedDictionary<String,Tirgum> FoundDup;
        static char[] allNikud = {SHEVA,
        HATAF_SEGOL,
        HATAF_PATAH,
        HATAF_QAMATS,
        HIRIQ,
        TSERE,
        SEGOL,
        PATAH,
        KAMAZ,
        HOLAM,
        HOLAM_HASER,
        QUBUTS,
        DAGES,
        SHIN_RIGHT,
        SHIN_LEFT,
        QAMATS_QATAN
    };
        static Regex pattern;

    static void Main(string[] args)
        {

            string ff = new string(allNikud);
            pattern = new Regex("[" + ff + "]");
            FoundDup = new SortedDictionary<string, Tirgum>();

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@" "))
            {

                file.Write("{");
                addTextFile(file);
                addDB(file);
                WriteDup(file);
                file.Write("}");
            }
        }

        private static void WriteDup(StreamWriter file)
        {
            string toAdd = "";
            string toWitre = "";

            foreach (string key in FoundDup.Keys)
            {
                toAdd = FoundDup[key].FoundProb();

                toWitre += "," + GERSIIM + key + GERSIIM + ":" + GERSIIM + returnLatin(toAdd) + GERSIIM;
            }

            toWitre = toWitre.Substring(1);
            file.Write(toWitre);
        }

        private static void addTextFile(StreamWriter file)
        {
            string text = System.IO.File.ReadAllText(@" ");
           
            string[] splitOne = text.Replace('\r',' ').Replace('\t',' ').Replace('\n',' ').Split(' ');

            int last = splitOne.Length;

            for (int i = 0; i < last; i++)
            {
                if (splitOne[i].IndexOfAny(allNikud) > 0)
                {
                    string BliNikud = pattern.Replace(splitOne[i], "");

                    //string BliNikud = splitOne[i].tolowerca(allNikud, "");

                    if (FoundDup.ContainsKey(BliNikud))
                        FoundDup[BliNikud].add(splitOne[i]);
                    else
                        FoundDup.Add(BliNikud, new Tirgum(splitOne[i]));
                }
            }
        }
        //add words from NIKUDA DB
        private static void addDB(System.IO.StreamWriter file)
        {
            
            string text = System.IO.File.ReadAllText(@" ");
            string[] splitOne = text.Split('(');
            int last = splitOne.Length;

                string[] split2 = splitOne[1].Split(',');
            
                
                for (int i = 0; i < last; i++)
                {
                    if (splitOne[i] != "")
                    {
                        split2 = splitOne[i].Split(',');

                        if (!FoundDup.ContainsKey(split2[1]))
                        {

                        string TheKey = split2[1].Substring(1, split2[1].Length - 2);// Replace("'", "").Replace(")", "");
                        if (FoundDup.ContainsKey(TheKey))
                            FoundDup[TheKey].add(split2[2].Substring(1, split2[2].Length - 2));
                        else
                            FoundDup.Add(TheKey, new Tirgum(split2[2].Substring(1, split2[2].Length - 2)));
                        }
                    }
                }
            }
    
        private static string returnLatin(string v)
        {
            char[] any = v.ToArray();
            string build = "";
            SvaNa = true;

            for (IndWord = 0; IndWord < any.Length; IndWord++)
            {
                //if (IndWord == any.Length - 1)
                //    return build;

                //have tnoha or dagesh
                if (IndWord + 1 < any.Length && any[IndWord + 1] == DAGES)
                {
                    switch (any[IndWord])
                    {
                        case ALEF:
                            build += ""; break;
                        case BEIT:
                            build += "b"; break;
                        case GIMEL:
                            build += "g"; break;
                        case DALET:
                            build += "d"; break;
                        case HE:
                            build += ""; break;
                        case VAV:
                            build += "v"; break;
                        case ZAIN:
                            build += "z"; break;
                        case HEIT:
                            build += "h"; break;
                        case TEIT:
                            build += "t"; break;
                        case YOD:
                            build += ""; break;
                        case KAF:
                            build += "K"; break;
                        case LAMED:
                            build += "l"; break;
                        case MEM:
                            build += "m"; break;
                        case NON:
                            build += "n"; break;
                        case SAMEH:
                            build += "s"; break;
                        case PE:
                            build += "p"; break;
                        case TSADI:
                            build += "ts"; break;
                        case RISH:
                            build += "r"; break;
                        case SHIN:
                            build += "sh"; break;
                        case THAF:
                            build += "t"; break;
                    }
                    ++IndWord;
                }
                //bli dages
                else
                {
                    switch (any[IndWord])
                    {
                        case ALEF:
                            build += ""; break;
                        case BEIT:
                            build += "v"; break;
                        case GIMEL:
                            build += "g"; break;
                        case DALET:
                            build += "d"; break;
                        case HE:
                            build += ""; break;
                        case VAV:
                            build += "v"; break;
                        case ZAIN:
                            build += "z"; break;
                        case HEIT:
                            build += "h"; break;
                        case TEIT:
                            build += "t"; break;
                        case YOD:
                            if (IndWord < any.Length - 1 && CheckNikod(any[IndWord + 1]))
                                build += "Y";
                            else
                                build += "";
                            break;
                        case KAF:
                            build += "h"; break;
                        case KAF_SOFIT:
                            build += "h"; break;
                        case LAMED:
                            build += "l"; break;
                        case MEM:
                            build += "m"; break;
                        case MEM_SOFIT:
                            build += "m"; break;
                        case NON:
                            build += "n"; break;
                        case NON_SOFIT:
                            build += "n"; break;
                        case SAMEH:
                            build += "s"; break;
                        case AYIN:
                            build += ""; break;
                        case PE:
                            build += "p"; break;
                        case PE_SOFIT:
                            build += "f"; break;
                        case TSADI:
                            build += "ts"; break;
                        case TSADI_SOFIT:
                            build += "ts"; break;
                        case KOF:
                            build += "k"; break;
                        case RISH:
                            build += "r"; break;
                        case SHIN:
                            IndWord++;
                            if (IndWord < any.Length && any[IndWord] == SHIN_LEFT)
                                build += "s";
                            else if (IndWord < any.Length && any[IndWord] == SHIN_RIGHT)
                                build += "sh";
                            //no any sign
                            else
                            {
                                build += "sh";
                                IndWord--;
                            }      

                            //for DAGESH in shin
                            if (IndWord < any.Length - 1 && any[IndWord + 1] == DAGES)
                                IndWord++;
                            break;
                        case THAF:
                            build += "t"; break;
                    }
                }

                if (IndWord + 1 < any.Length && CheckNikod(any[IndWord + 1]))
                {
                    build += addNikud(any[++IndWord]);
 
                    //If holam male
                    if (any[IndWord] == VAV)
                        IndWord++;
                }
           }

            return build;
        }


        private static bool CheckNikod(char PozNikud)
        {
            switch (PozNikud)
            {
                case KAMAZ:
                    return true;
                case HATAF_QAMATS:
                    return true;
                case PATAH:
                    return true;
                case HATAF_PATAH:
                    return true;
                case SEGOL:
                    return true;
                case HATAF_SEGOL:
                    return true;
                case TSERE:
                    return true;
                case HIRIQ:
                    return true;
                case QUBUTS:
                    return true;
                case HOLAM_HASER:
                    return true;
                case HOLAM:
                    return true;
                case SHEVA:
                    return true;
                case VAV:
                    return true;
                case DAGES: // for mistake
                    return true;
                default:
                    return false;
            }
        }

        private static string addNikud(char nikud)
        {
            switch (nikud)
            {
                case KAMAZ:
                    SvaNa = false;
                    return "a";
                case HATAF_QAMATS:
                    SvaNa = false;
                    return "o";
                case PATAH:
                    SvaNa = false;
                    return "a";
                case HATAF_PATAH:
                    SvaNa = false;
                    return "a";
                case SEGOL:
                    SvaNa = false;
                    return "e";
                case HATAF_SEGOL:
                    SvaNa = false;
                    return "e";
                case TSERE:
                    SvaNa = false;
                    return "e";
                case HIRIQ:
                    SvaNa = false;
                    return "i";
                case QUBUTS:
                    SvaNa = false;
                    return "u";
                case HOLAM_HASER:
                    SvaNa = false;
                    return "o";
                case HOLAM:
                    SvaNa = false;
                    return "o";
                case VAV:
                    SvaNa = false;
                    return "o";
                case DAGES: // for mistake
                    return "u";
                case SHEVA:
                    if (SvaNa)
                    {
                        SvaNa = false;
                        return "e";
                    }
                    else
                    {
                        SvaNa = true;
                        return "";
                    }
            }
            return "";
        }

        private static string AlfHeEin(char Ot, char Nikud)
        {
            switch (Nikud)
            {
                case '\u05B8':
                    return "";
            }

            return "";
        }
    }
}

