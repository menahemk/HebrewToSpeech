# HebrewToSpeech
Simple javascript library for speech Hebrew text  

This javascript can sound hebrew texts in very simple way.  

This project based on courposes of dottes words in open courpos in the web (such http://benyehuda.org/ , https://he.wikisource.org/wiki/ , www.sefaria.org and the DB of nikuda: http://www.nikuda.co.il/), the next step is create JSON file where for each word non-dottes word (the key) builded a latin transliteration (the value) according to dottes word (in case of some dottes option for one word, the most common dottes was chosed).
the javascript code used in mespeak.js for speeach the latin transliteration oof any input hebrew text.

words that not found in the JSON file notsounded at all.

Thanks to nikuda team about the inspiration and the permission to use in the nikuda DB.
