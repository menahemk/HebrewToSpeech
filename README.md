# HebrewToSpeech
Simple javascript library for speech Hebrew text  

This javascript can sound hebrew texts in very simple way.  

This project based on corpus of dotted words in open corpus in the web (such http://benyehuda.org , https://he.wikisource.org/wiki , www.sefaria.org and the DB of nikuda: http://www.nikuda.co.il), the target of .cs files (c# files) is to create JSON file where for each word un-dotted word (the key) builded a polish transliteration (the value) according to dotted word (in case of some dotted option for one word, the most common dotted was chosen).

the javascript code used mespeak.js for speeach the polish transliteration of any un-dotted input hebrew text.

words that not found in the JSON file not sounded at all.

Thanks to nikuda team about the inspiration and the permission to use in the nikuda DB.
