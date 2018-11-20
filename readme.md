# rot8000

**rot8000** solves the burning question of the day: how to de-spoilerize text containing non-Western characters, in a universal way. Rot13, which rotates any text 13 characters through the alphabet, was great for Usenet days, so long as you only use the English alphabet. This is rot13 for the Unicode generation.

Rot8000 only works in the Basic Multilingual Plane, which covers languages in use today, including the commonly used CJK characters. If you want to write spoilers in Linear B, you might need another system. It rotates by 0x8000 or half the BMP (actually a bit less than 8000, as it leaves alone whitespace and surrogates). 

See it in action: [rot8000.com](http://rot8000.com )
